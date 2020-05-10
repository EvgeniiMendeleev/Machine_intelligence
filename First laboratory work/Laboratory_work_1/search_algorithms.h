#pragma once
#include <vector>
#include <queue>
#include <stack>
#include <iostream>
#include "State.h"

using namespace std;

void fullSearch(vector<unsigned>& numbers, unsigned N, unsigned sum, unsigned lastNumber, vector<vector<unsigned>>& results, vector<unsigned>& sequence, double& countAll);
void pointerAlgorithm(vector<unsigned> numbers, unsigned N, unsigned sum, size_t countNumbers, vector<vector<unsigned>>& results, vector<unsigned>& sequence, double& countAll);
void searchInDepth(vector<unsigned>& numbers, unsigned N, vector<vector<unsigned>>& results, double& countAll);


#pragma region Algorithm
void searchInWidth(vector<unsigned>& numbers, unsigned N, vector<vector<unsigned>>& results, double& countAll);
#pragma endregion Full search algorithm