#pragma once
#include <string>
#include <vector>
#include "Composer.h"

using namespace std;

class Composition final
{
	string title;
	string genre;
	vector<Composer> authors;
	float difficultRank;

public:
	explicit Composition(string& title, string& genre, vector<Composer>& authors, float difficultRank);
	~Composition() = default;

#pragma region Getters
	const string get_title() const;
	const string get_genre() const;
	const float get_level() const;
#pragma endregion The functions for to get values
};