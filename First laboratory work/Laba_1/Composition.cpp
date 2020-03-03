#include "stdafx.h"
#include "Composition.h"

Composition::Composition(string& title, string& genre, vector<Composer>& authors, float difficultRank)
{
	this->title = title;
	this->genre = genre;

	for (unsigned short i = 0; i < authors.size(); i++)
	{
		this->authors.push_back(authors[i]);
	}

	this->difficultRank = difficultRank;
}

const string Composition::get_title() const
{
	return this->title;
}

const string Composition::get_genre() const
{
	return this->genre;
}

const float Composition::get_level() const
{
	return this->difficultRank;
}
