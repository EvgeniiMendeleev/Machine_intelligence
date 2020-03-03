#pragma once
#include <string>

using namespace std;

class Instrument final
{
	string name;
	float difficultRank;

public:
	explicit Instrument(string& name, float difficultRank);
	~Instrument() = default;

#pragma region Getters
	const string get_name() const;
	const float get_level() const;
#pragma endregion The functions fot to get values
};