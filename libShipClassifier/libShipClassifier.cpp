#include "libShipClassifier.h"
#include "Classifier.h"
#include "Windows.h"
#include <fstream>

//Classifier * pInstance = NULL;
void createInstrance(char* path)
{
	std::ifstream fin("outPatter1.xml");
	/*if(fin.good())
	{
		fin.close();
		Classifier::getInstancePtr()->loadWayPointPatter("outPatter1.xml");
	}
	else*/
	{
		Classifier::getInstancePtr()->addWayPoints(path, NORMAL);
	}
}

void releaseInstance()
{
	Classifier::releasePtr();
}

void setExistingWaypoint(int _id, int x, int y)
{
	if(Classifier::GetTrajectoryMap().find(_id) != Classifier::GetTrajectoryMap().end())
	{
		Classifier::GetTrajectoryMap()[_id]->push_back(CPos(x, y));
	}
	else
	{
		Classifier::GetTrajectoryMap().insert(std::pair<int, std::vector<CPos>* >(_id, new std::vector<CPos>()));
		Classifier::GetTrajectoryMap()[_id]->push_back(CPos(x, y));
	}
	
}

void setNextWaypoint(int _id, int x, int y)
{
	Classifier::GetTrajectoryMap()[_id]->push_back(CPos(x, y));
}

char* getNextPoint(int _id)
{
	std::vector<WayPoints > nextPointsCandidate = Classifier::getInstancePtr()->getNextPoints(*(Classifier::GetTrajectoryMap()[_id]), 6);
	std::stringstream sstream;
	
	if (!nextPointsCandidate.empty())
	{
		sstream << (nextPointsCandidate[0][0].x+1) << "," << nextPointsCandidate[0][0].y;
	}
	else
	{
		sstream << "no matching";
	}

	std::string temp = sstream.str();
	const char* temp_c = temp.c_str();
	char* result = (char*)LocalAlloc(LPTR, temp.length() + 1);
	for (int i = 0; i < temp.length(); i++)
		result[i] = temp_c[i];
	
	result[temp.length() + 1] = '\0';

	return result;
}