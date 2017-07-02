#include "Classifier.h"

#include <fstream>
#include <sstream>
#include <iostream>

#include <algorithm>
#include <vector>
#include <string>

#include <cmath>
#include <set>

std::map<int, std::vector<CPos>*> Classifier::trajectoryMap = std::map<int, std::vector<CPos>*>();

Classifier::Classifier()
: resolPerCell(1)
, radius(3)
{
	maxVariance = 36;
	searchingRange = radius * 3; 
	minusWeight = -1.7;
	minusRadius = 2;
	numCandidate = 3;
}

Classifier * Classifier::pInstance = NULL;
const CPos	 moveArray[4] = { CPos(-1, 0), CPos(1, 0), CPos(0, -1), CPos(0, 1) };

bool Classifier::addWayPoints(const std::string &file, const MoveType & moveType) 
{
	std::ifstream fin(file.c_str());
	std::vector<CPos> curWayPoints;

	if (!fin.is_open())
	{
		throw nodeInfoException("topology xml file is not loaded for parsing");
		return false;
	}

	std::ostringstream sstr;
	sstr << fin.rdbuf();

	sstr.flush();
	fin.close();

	std::string xmlData = sstr.str();
	rapidxml::xml_document<> doc;
	doc.parse<0>(&xmlData[0]);

	rapidxml::xml_node<> *rootNode = doc.first_node("ObjectList");
	if (!rootNode)
		return false;

	//set map size
	rapidxml::xml_attribute<> *attr = rootNode->first_attribute("MapSizeX");
	mapSizeX = atoi(attr->value());
	attr = rootNode->first_attribute("MapSizeY");
	mapSizeY = atoi(attr->value());


	while (1)
	{
		rapidxml::xml_node<> *curShipNode = rootNode->first_node("ShipList")->first_node("Ship");
		addShipWaypoints(curShipNode, curWayPoints, moveType);
		curShipNode = curShipNode->next_sibling("Ship");
		if (curShipNode == NULL)
			break;
	}

	return true;
}

int Classifier::addShipWaypoints(rapidxml::xml_node<> * curShipNode, std::vector<CPos> &curWayPoints, const MoveType & moveType)
{
	//set map size
	rapidxml::xml_node<> * curNode = curShipNode;
	rapidxml::xml_attribute<> * attr = curNode->first_attribute("id");
	int shipID = atoi(attr->value());

	//Add waypoints
	curNode = curNode->first_node("Waypoints")->first_node("Waypoint");

	while (curNode) {
		//Get waypoint
		attr = curNode->first_attribute("x");
		double x = std::stod(attr->value());
		attr = curNode->first_attribute("y");
		double y = std::stod(attr->value());
		CPos curPos = getPos(x, y);

		if (curWayPoints.empty())
		{
			curWayPoints.push_back(curPos);
		}
		else {
			addIntermediatePos(curWayPoints, curPos);
		}

		//next sibling
		curNode = curNode->next_sibling("Waypoint");
	}

	std::vector<int> matchingGroups;
	std::vector<double> corrVec;
	std::vector<WPPattern>	* localWPPatterns;

	if (moveType == NORMAL)
	{
		localWPPatterns = &normalWPPatterns;
	}
	else
	{
		localWPPatterns = &abnormalWPPatterns;
	}

	getPatternCandidates(*localWPPatterns, curWayPoints);

	//Add current position
	int curWPIndex = prevWPPoints.size();
	prevWPPoints.push_back(curWayPoints);

	int _patternID;

	//Sort compare 
	if (!matchingGroups.empty())
	{
		int minindex = std::min_element(corrVec.begin(), corrVec.end()) - corrVec.begin();
		_patternID = matchingGroups.at(minindex);

		localWPPatterns->at(_patternID).wpIDs.push_back(curWPIndex);
		addWeights(localWPPatterns->at(_patternID).PosWeightMap, curWayPoints);
	}
	else
	{
		WPPattern _pattern;
		if (localWPPatterns->empty())
			_patternID = 0;
		else
			_patternID = localWPPatterns->back().patternID + 1;

		_pattern.patternID = _patternID;
		_pattern.wpIDs.push_back(curWPIndex);
		addWeights(_pattern.PosWeightMap, curWayPoints);

		localWPPatterns->push_back(_pattern);
	}

	return 0;
}

std::vector<CorrInfo> Classifier::getPatternCandidates(std::vector<WPPattern> & wpPatterns, const std::vector<CPos> & curWayPoints)
{
	std::vector<CorrInfo> retInfo; 

	for (auto iter = wpPatterns.begin(); iter != wpPatterns.end(); ++iter)
	{
		std::vector<int> & wpGroupIndexes = iter->wpIDs;

		for (size_t i = 0; i < wpGroupIndexes.size(); ++i)
		{
			WayPoints & eachWPs = prevWPPoints.at(wpGroupIndexes[i]);

			WayPoints reverseWPs = curWayPoints;
			double _corrVal1 = getCorrelationBtwWPs(eachWPs, curWayPoints);

			std::reverse(reverseWPs.begin(), reverseWPs.end());
			double _corrVal2 = getCorrelationBtwWPs(eachWPs, reverseWPs);

			double _corrVal = std::min(_corrVal1, _corrVal2);

			if (_corrVal < maxVariance)
			{
				CorrInfo _info;
				_info.patternID = (iter->patternID);
				_info.corrVal = _corrVal;

				retInfo.push_back(_info);
			}
		}
	}

	return retInfo;
}

std::vector<WayPoints> Classifier::getNextPoints(const WayPoints & partialWPs, const int & depth)
{
	std::vector<CorrInfo> matchingNormalGroup;
	std::vector<CorrInfo> matchingAbnormalGroup;
	WPPattern * targetPattern;
	CorrInfo normalMinCorrInfo, abnormalMinCorrInfo;
	std::vector<WayPoints> retWPsCandidates;
	WayPoints sourceFullWPs;

	getFullPath(sourceFullWPs, partialWPs);

	matchingNormalGroup = getPatternCandidates(normalWPPatterns, sourceFullWPs);
	matchingAbnormalGroup = getPatternCandidates(abnormalWPPatterns, sourceFullWPs);

	if (! matchingNormalGroup.empty())
	{ 
		normalMinCorrInfo = *std::min_element(matchingNormalGroup.begin(), matchingNormalGroup.end(),
			[](const CorrInfo & lhs, const CorrInfo & rhs) { return lhs.corrVal < rhs.corrVal; });
	}

	if (! matchingAbnormalGroup.empty())
	{ 
		abnormalMinCorrInfo = *std::min_element(matchingAbnormalGroup.begin(), matchingAbnormalGroup.end(),
			[](const CorrInfo & lhs, const CorrInfo & rhs) { return lhs.corrVal < rhs.corrVal; });
	}

	if (normalMinCorrInfo.isEmtpy() && abnormalMinCorrInfo.isEmtpy())
	{ 
		std::cout << "No matching patterns" << std::endl;
		return retWPsCandidates;
	}else if (normalMinCorrInfo.corrVal < abnormalMinCorrInfo.corrVal)
	{ 
		targetPattern = &normalWPPatterns[normalMinCorrInfo.patternID];
	}
	else 
	{
		targetPattern = &abnormalWPPatterns[normalMinCorrInfo.patternID];
	}

	retWPsCandidates = getWPsFromWeightSum(targetPattern->PosWeightMap, partialWPs, depth);

	return retWPsCandidates;
}

std::vector<int> Classifier::getMoveSequence(const int & num, int depth)
{
	int targetNum = num;
	std::vector<int> retVec;

	for (int i = 0; i < depth; ++i)
	{
		int remain = targetNum % 4;
		retVec.push_back(remain);
		targetNum = (targetNum - remain) / 4;
	} 

	return retVec;
}

double Classifier::getSumWeight(const std::map<CPos, double> & PosWeightMap, std::vector<int> Vec, const CPos & curPos)
{
	double sumWeight = 0.0;
	std::map<CPos, double> copiedPosWeigtMap; 
	CPos nextPos = curPos;

	for (auto iter = Vec.begin(); iter != Vec.end(); ++iter)
	{ 
		nextPos = nextPos + moveArray[*iter];
		sumWeight += copiedPosWeigtMap[nextPos];
		copiedPosWeigtMap[nextPos] -= 2;
	}

	return sumWeight;

}

CPos Classifier::getFinalPos(const std::vector<int> moveIndexes, const CPos & curPos)
{
	CPos nextPos = curPos;

	for (auto iter = moveIndexes.begin(); iter != moveIndexes.end(); ++iter)
	{ 
		nextPos = nextPos + moveArray[*iter];
	}

	return nextPos;
}

double Classifier::getCorrelationBtwWPs(const WayPoints & lhs, const WayPoints & rhs)
{
	const WayPoints * bigWPs, *smallWPs; 
	int diffSize = lhs.size() - rhs.size(); 

	std::vector<double> multipleVarince;
	 
	if (diffSize >= 0 ) 
	{
		bigWPs = &lhs;
		smallWPs = &rhs;
	}
	else 
	{
		bigWPs = & rhs;
		smallWPs = & lhs;
		diffSize *= -1;
	}

	std::set<int> diffSizeSet = getNearestPointIndex(lhs, rhs);
	std::vector<double>  corrValCandidates; 

	for (auto iter = diffSizeSet.begin(); iter != diffSizeSet.end(); ++iter ) 
	{ 
		corrValCandidates.push_back(getCorrelation(*bigWPs, *smallWPs, *iter));
	}

	if (corrValCandidates.empty())
	{ 
		return std::numeric_limits<double>::infinity();
	}
	else
	{
		return *std::min_element(corrValCandidates.begin(), corrValCandidates.end());
	}
}

MultiIndex Classifier::getNearestPointIndex(const WayPoints & lhs, const WayPoints & rhs)
{
	double diffSquare;
	std::set<int> mulipleIndex; 

	for (auto iterRhs = rhs.begin(); iterRhs != rhs.end(); ++iterRhs)
	{ 
		int index = 0; 

		for (auto iterLhs = lhs.begin(); iterLhs != lhs.end(); ++iterLhs, ++index)
		{ 

			diffSquare = getSquareDistance(*iterLhs, *iterRhs);
			if (diffSquare <= maxVariance)
			{ 
				mulipleIndex.insert(index);
			}
		}
	}

	return mulipleIndex;
}

double Classifier::getSquareDistance(const CPos & lhs, const CPos & rhs)
{
	double diffX = lhs.x - rhs.x;
	double diffY = lhs.y - rhs.y;

	return (diffX * diffX) + (diffY * diffY);
}

CPos Classifier::getPos(const double & x, const double & y)
{
	int _x = static_cast<int>(ceil(x * resolPerCell));
	int _y = static_cast<int>(ceil(y * resolPerCell));

	return CPos(_x, _y);
}

int Classifier::getFullPath(WayPoints & points, const WayPoints & sourceWPs)
{
	//Add first element
	auto iter = sourceWPs.begin();
	points.push_back(*iter);
	++iter;
	
	for (; iter != sourceWPs.end(); ++iter)
	{ 
		addIntermediatePos(points, *iter);
	}

	return 0;
}

int Classifier::addWeights(std::map<CPos, double> & PosWeightMap, const WayPoints & points)
{
	std::vector<int> moveSequence; 
	std::set<CPos> weightPointCandidates;

	for (auto iter = points.begin(); iter != points.end(); ++iter)
	{ 
		CPos curPos(iter->x, iter->y);

		for (int tmp = 0; tmp <= radius; ++tmp)
		{ 
			int totalNum = static_cast<int>(pow(4, tmp));
			CPos nextPos = curPos; 

			for (int i = 0; i < totalNum; ++i)
			{ 
				moveSequence = getMoveSequence(i, tmp);
				nextPos = getFinalPos(moveSequence, curPos);
				weightPointCandidates.insert(nextPos);
			}
		}


		for (auto iter = weightPointCandidates.begin(); iter != weightPointCandidates.end(); ++iter)
		{ 

			if (iter->x < 0 || iter->x  >= mapSizeX * resolPerCell)
				continue;

			if (iter->y < 0 || iter->y  >= mapSizeY * resolPerCell)
				continue;

			double squareDistance = getSquareDistance(curPos, *iter);
			PosWeightMap[*iter] += getProbDesity(sqrt(squareDistance));
		}
	}

	return 0;
}

std::vector<WayPoints> Classifier::getWPsFromWeightSum(const std::map<CPos, double> & _PosWeightMap, const WayPoints & partialWPs, int depth)
{
	std::vector<int> moveSequence; 
	std::vector<std::pair<int,double>> weightSumVec;
	CPos curPos = partialWPs.back(); 
	std::map<CPos, double> PosWeightMap = _PosWeightMap; 
	std::vector<WayPoints> retWPVec;

	if (PosWeightMap.empty())
	{ 
		throw nodeInfoException("Serious errors during processing WP points");
		return retWPVec;
	}

	removeWeightsAlongPath(PosWeightMap, partialWPs, depth);

	int totalNum = static_cast<int>(pow(4, depth));

	for (int i = 0; i < totalNum; ++i)
	{ 
		moveSequence = getMoveSequence(i, depth);

		CPos finalPos = getFinalPos(moveSequence, curPos);
		int _distance = static_cast<int> (std::abs(finalPos.x - curPos.x) + std::abs(finalPos.y - curPos.y));

		if ( _distance != depth)
			continue;

		double _weightSum = getSumWeight(PosWeightMap, moveSequence, curPos);
		weightSumVec.push_back(std::make_pair(i,_weightSum));
	}

	//Find min working pattern
	for (int i = 0; i < numCandidate; ++i)
	{ 
		if (weightSumVec.empty())
			break;

		auto maxIter = std::max_element(weightSumVec.begin(), weightSumVec.end(),
			[](const std::pair<int, double> & lhs, const std::pair<int, double> & rhs) { return lhs.second < rhs.second; });

		moveSequence = getMoveSequence(maxIter->first, depth);

		CPos nextPos = curPos;
		WayPoints _tmpWPs;

		for (int j = 0; j < depth; j++)
		{ 
			int moveIndex = moveSequence[j];
			nextPos = nextPos + moveArray[moveIndex];
			_tmpWPs.push_back(nextPos);
		}

		retWPVec.push_back(_tmpWPs);
		weightSumVec.erase(maxIter);
	}

	return retWPVec;
}

double Classifier::getProbDesity(const double & gridDiff)
{
	double ret = 1 / (radius*sqrt(2 * 3.141592))* exp(-1 / 2 * (gridDiff / radius) * (gridDiff / radius));
	return ret;
}

int Classifier::addIntermediatePos(WayPoints & prevPoints, const CPos & destPos)
{
	CPos lastPos = prevPoints.back(); 
	CPos bridge = getNextPossiblePos(lastPos, destPos);

	while (! bridge.isEmpty())
	{ 
		prevPoints.push_back(bridge);
		bridge = getNextPossiblePos(bridge, destPos);
	}

	return 0; 
}

CPos  Classifier::getNextPossiblePos(const CPos & srcPos, const CPos & destPos)
{
	CPos bridge; 

	int diffX = destPos.x -  srcPos.x; 
	int diffY = destPos.y - srcPos.y; 

	if (diffX == 0 && diffY == 0)
	{ 

	}
	else if (std::abs(diffX) == 1 && std::abs(diffY) == 1)
	{ 
	}
	else
	{
		int x = srcPos.x , y = srcPos.y;

		if (diffX < 0)
			x = srcPos.x - 1;
		else if (diffX > 0)
			x = srcPos.x + 1;
		
		if (diffY < 0)
			y = srcPos.y - 1;
		else if (diffY > 0)
			y = srcPos.y + 1;

		bridge.x = x;
		bridge.y = y;
	} 

	return bridge;
}

double Classifier::getCorrelation(const WayPoints & largeWPs, 
	const WayPoints & smallWPs, const int & index)
{
	if (smallWPs.size() == 1 ) 
	{ 
		throw nodeInfoException("Small number of vector point");
		return 0.0;
	}

	double diffx, diffy, diffSquare = 0.0;

	for (size_t i = 0; i < smallWPs.size(); ++i)
	{ 
		if (i + index >= largeWPs.size())
			break;

		diffx = largeWPs.at(i+index).x-smallWPs.at(i).x;
		diffy = largeWPs.at(i+index).y-smallWPs.at(i).y;
		diffSquare += diffx * diffx + diffy * diffy;
	}

	return diffSquare / (smallWPs.size()-1);
}

int Classifier::removeWeightsAlongPath(std::map<CPos, double> & PosWeightMap, const WayPoints & points, int depth)
{
	std::vector<int> moveSequence; 
	std::set<CPos> weightPointCandidates;

	for (auto iter = points.begin(); iter != points.end(); ++iter)
	{ 
		CPos curPos(iter->x, iter->y);

		for (int tmp = 0; tmp <= minusRadius; ++tmp)
		{ 
			int totalNum = static_cast<int>(pow(4, tmp));
			CPos nextPos = curPos; 

			for (int i = 0; i < totalNum; ++i)
			{ 
				moveSequence = getMoveSequence(i, tmp);
				nextPos = getFinalPos(moveSequence, curPos);
				weightPointCandidates.insert(nextPos);
			}
		}

		for (auto iter = weightPointCandidates.begin(); iter != weightPointCandidates.end(); ++iter)
		{ 

			if (iter->x < 0 || iter->x  >= mapSizeX * resolPerCell)
				continue;

			if (iter->y < 0 || iter->y  >= mapSizeY * resolPerCell)
				continue;

			double squareDistance = getSquareDistance(curPos, *iter);
			PosWeightMap[*iter] += minusWeight * getProbDesity(sqrt(squareDistance));
		}
	}

	return 0;

}


std::map<int, std::vector<CPos>*>& Classifier::GetTrajectoryMap()
{
	return trajectoryMap;
}

