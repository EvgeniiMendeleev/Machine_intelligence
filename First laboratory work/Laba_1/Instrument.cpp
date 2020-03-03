#include "stdafx.h"
#include "Instrument.h"

Instrument::Instrument(string& name, float difficultRank)
{
	this->name = name;
	this->difficultRank = difficultRank;
}

const string Instrument::get_name() const
{
	return this->name;
}

const float Instrument::get_level() const
{
	return this->difficultRank;
}
