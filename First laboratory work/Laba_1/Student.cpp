#include "stdafx.h"
#include "Student.h"

Student::Student(float difficultRank, vector<Instrument>& instruments)
{
	this->difficultRank = difficultRank;
	for (unsigned short i = 0; i < instruments.size(); i++)
	{
		this->instruments.push_back(instruments[i]);
	}
}

const float Student::get_level() const
{
	return this->difficultRank;
}
