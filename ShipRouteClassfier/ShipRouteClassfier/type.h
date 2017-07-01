#pragma  once

#include <vector>
#include <map>
#include <limits>
#include <set>

class CPos
{
public:
	CPos(const int & _x, const int & _y) : x(_x), y(_y) {}
	CPos() : x(-1), y(-1) {}
	int x;
	int y;

public:
	CPos & operator + (const CPos & rhs)
	{
		this->x += rhs.x;
		this->y += rhs.y;
		return *this;
	}
	bool operator < (const CPos & rhs) const
	{
		if (y < rhs.y)	return true;
		else if (y == rhs.y && x < rhs.x) return true;
		else return false;
	}

	bool operator == (const CPos & rhs) const
	{
		return (this->x == rhs.x) && (this->y == rhs.y);
	}

	CPos & operator = (const CPos & rhs){
		if (this == &rhs)	return *this;
		else
			this->x = rhs.x; this->y = rhs.y;
		return *this;
	}

	bool isEmpty() const  { return this->x < 0; }
};

typedef std::vector<CPos> WayPoints;
typedef std::set<int> MultiIndex;

class WPPattern
{
public:
	int patternID;
	std::vector<int> wpIDs;
	std::map<CPos, double> PosWeightMap;
};

class CorrInfo
{
public: 
	CorrInfo() : patternID(-1), corrVal(std::numeric_limits<double>::max()) {} 
	bool isEmtpy() const { return  patternID < 0; }

public:
	int			patternID;
	double		corrVal;
};