#pragma once
#include <string>
#include <vector>
#include "Instrument.h"

using namespace std;

class Student final
{
	float difficultRank;
	vector<Instrument> instruments;

public:
	explicit Student(float difficultRank, vector<Instrument>& instruments);
	~Student() = default;

#pragma region Getters
	const float get_level() const;
#pragma endregion The functions for to get values
};