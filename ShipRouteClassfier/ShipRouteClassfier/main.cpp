#include "Classifier.h"

void PrintNextPos(const WayPoints & pos)
{
	for (auto iter = pos.begin(); iter != pos.end(); ++iter)
	{ 
		std::cout << "Next Pos = ( " << iter->x << "," << iter->y << ")" << std::endl; 
	}
}

WayPoints testVector()
{
	WayPoints retVec;
	retVec.push_back(CPos(334,435));
	retVec.push_back(CPos(335,408));
	retVec.push_back(CPos(335,380));
	retVec.push_back(CPos(352,380));

	return retVec;
}


WayPoints testVector1()
{
	WayPoints retVec;
	retVec.push_back(CPos(352,380));
	retVec.push_back(CPos(335,380));
	retVec.push_back(CPos(335,408));
	retVec.push_back(CPos(334,435));

	return retVec;
}


WayPoints testVector2()
{
	WayPoints retVec;
	retVec.push_back(CPos(150,152));
	retVec.push_back(CPos(164,158));
	retVec.push_back(CPos(175,162));
	retVec.push_back(CPos(176,163));

	return retVec;
}

int main()
{
	Classifier::getInstancePtr()->addWayPoints("abnormal1.xml", NORMAL);
	Classifier::getInstancePtr()->addWayPoints("abnormal2.xml", NORMAL);
	Classifier::getInstancePtr()->addWayPoints("abnormal3.xml", NORMAL);

	std::vector<WayPoints> nextPointsCandidate;
	WayPoints parialVec = testVector();

	nextPointsCandidate = Classifier::getInstancePtr()->getNextPoints(parialVec, 6);

	for (auto iter = nextPointsCandidate.begin(); iter != nextPointsCandidate.end(); ++iter)
	{ 
		std::cout << "------------------------" << std::endl;
		PrintNextPos(*iter);
	}

	parialVec = testVector1();

	nextPointsCandidate = Classifier::getInstancePtr()->getNextPoints(parialVec, 6);

	for (auto iter = nextPointsCandidate.begin(); iter != nextPointsCandidate.end(); ++iter)
	{ 
		std::cout << "------------------------" << std::endl;
		PrintNextPos(*iter);
	}

	parialVec = testVector2();

	nextPointsCandidate = Classifier::getInstancePtr()->getNextPoints(parialVec, 6);

	for (auto iter = nextPointsCandidate.begin(); iter != nextPointsCandidate.end(); ++iter)
	{ 
		std::cout << "------------------------" << std::endl;
		PrintNextPos(*iter);
	}

	return 0; 
}