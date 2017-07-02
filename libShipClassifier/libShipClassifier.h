#pragma once

#include "Classifier.h"

extern "C" __declspec(dllexport) void createInstrance(char* path);
extern "C" __declspec(dllexport) void releaseInstance();

extern "C" __declspec(dllexport) void setExistingWaypoint(int _id, int x, int y);
extern "C" __declspec(dllexport) void setNextWaypoint(int _id, int x, int y);

extern "C" __declspec(dllexport) char* getNextPoint(int _id);