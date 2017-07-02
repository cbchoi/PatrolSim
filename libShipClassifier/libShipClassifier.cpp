#include "libShipClassifier.h"
#include "Classifier.h"
#include "Windows.h"

void createInstrance(char* path)
{
	Classifier::getInstancePtr()->addWayPoints(path, NORMAL);
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
	std::vector<WayPoints> nextPointsCandidate = Classifier::getInstancePtr()->getNextPoints(*(Classifier::GetTrajectoryMap()[_id]), 6);
	std::stringstream sstream;
	
	if (!nextPointsCandidate.empty())
	{
		sstream << nextPointsCandidate[0][0].x << "," << nextPointsCandidate[0][0].y;
	}
	else
	{
		sstream << "no matching";
	}

	int size = sstream.str().length();
	char* result = (char*)LocalAlloc(LPTR, size + 1);

	strcpy_s(result, sstream.str().length(), sstream.str().c_str());
	
	result[size + 1] = '\0';

	return result;
}