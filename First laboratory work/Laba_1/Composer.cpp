#include "stdafx.h"
#include "Composer.h"

Composer::Composer(string & firstName, string & lastName)
{
	this->firstName = firstName;
	this->lastName = lastName;
}

const string Composer::get_firstName() const
{
	return this->firstName;
}

const string Composer::get_lasName() const
{
	return this->lastName;
}
