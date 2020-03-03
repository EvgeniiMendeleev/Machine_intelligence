#pragma once
#include <string>

using namespace std;

class Composer final
{
	string firstName;
	string lastName;
public:
	explicit Composer(string& firstName, string& lastName);
	~Composer() = default;

#pragma region Getters
	const string get_firstName() const;
	const string get_lasName() const;
#pragma endregion The functions for to get values
};