#ifndef PARSER_H
#define PARSER_H

#include <iostream>
#include <string>
#include <utility>
#include <sstream>
#include <exception>

#include "rapidxml.hpp"
#include "rapidxml_print.hpp"
#include "type.h"


enum MoveType{
	NORMAL,
	ABNORMAL,
};

class Classifier
{
public:
	bool			addWayPoints(const std::string &file, const MoveType & moveType);
	std::vector<WayPoints>	getNextPoints(const WayPoints & partialWPs, const int & depth);
	bool			writeWayPointPattern(const std::string & file);
	bool			loadWayPointPatter(const std::string & file);


public: 
	int			addShipWaypoints(rapidxml::xml_node<> * rootNode, std::vector<CPos> &curWayPoints, const MoveType & moveType);
	std::vector<CorrInfo> getPatternCandidates(std::vector<WPPattern> & wpPatterns, const std::vector<CPos> & curWayPoints);
	int			removeWeightsAlongPath(std::map<CPos, double> & PosWeightMap, const WayPoints & points, int depth);
	int			addWeights(std::map<CPos, double> & PosWeightMap, const WayPoints & points);
	CPos			getPos(const double & x, const double & y);
	int			getFullPath(WayPoints & points, const WayPoints & sourceWPs);
	int			initMovingPoints();


private: 
	double		getCorrelationBtwWPs(const WayPoints & lhs, const WayPoints & rhs);
	double		getSquareDistance(const CPos & lhs, const CPos & rhs);
	std::vector<	WayPoints> getWPsFromWeightSum(const std::map<CPos, double> & PosWeightMap, 
				const WayPoints & partialWPs, int depth);
	double		getProbDesity(const double & celldistance);

private:
	MultiIndex	getNearestPointIndex(const WayPoints & lhs, const WayPoints & rhs);
	int			addIntermediatePos(WayPoints & points, const CPos & pos);
	CPos			getNextPossiblePos(const CPos & lPos, const CPos & rPos);
	double		getCorrelation(const WayPoints & largeWPs, const WayPoints & smallWPs, const int & index);
	std::vector<int> getMoveSequence(const int & num, int depth);
	double		getSumWeight(const std::map<CPos, double> & PosWeightMap, std::vector<int> Vec, const CPos & curPos);
	CPos			getFinalPos(const std::vector<int> moveIndexes, const CPos & curPos);

public: 
	int			mapSizeX;
	int			mapSizeY;
	int			resolPerCell; 
	int			radius;
	double		minusWeight;
	int			minusRadius;
	double		maxVariance;
	int			searchingRange;
	int			numCandidate;

	std::vector<WPPattern>	normalWPPatterns;
	std::vector<WPPattern>	abnormalWPPatterns;
	std::vector<WayPoints>	prevWPPoints;
	std::set<CPos>			movingWPforAdding;
	std::set<CPos>			movingWPforRemoving;

public:
	static Classifier * getInstancePtr() 
	{
		if( pInstance == NULL)	 pInstance = new Classifier(); 
		return pInstance; 
	}

	static void releasePtr()
	{ 
		if ( pInstance != NULL  ) delete pInstance ; 
	}

	class nodeInfoException : public std::exception {
	public:
		nodeInfoException(const std::string & str) throw() {
			std::stringstream ss;
			ss<<"Error in parsing Node : " << str;
			this->exceptionStr = ss.str();
		}

		~nodeInfoException() throw() {
		}

		const char* what() const throw() {
			return this->exceptionStr.c_str();
		}

	private:
		std::string exceptionStr;
	};

private: 
	Classifier(); 
	~Classifier() {} 
	static Classifier * pInstance;

private:
	static std::map<int, std::vector<CPos>*> trajectoryMap;
public:
	static std::map<int, std::vector<CPos>*>& GetTrajectoryMap();
};



#endif //PARSER_H
