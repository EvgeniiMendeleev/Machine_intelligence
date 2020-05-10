#include "stdafx.h"
#include "State.h"


State::State(Data number, size_t lastPos)
{
	this->datas.push_back(number);
	this->lastPos = lastPos;
}

void State::push_number(Data data)
{
	this->datas.push_back(data);
}

void State::pop_back()
{
	this->datas.resize(this->datas.size() - 1);
}

vector<Data> State::get_numbers()
{
	return this->datas;
}

size_t State::get_last_pos()
{
	return this->lastPos;
}

void State::set_last_pos(size_t lastPos)
{
	this->lastPos = lastPos;
}

Data State::get_number(unsigned pos)
{
	return this->datas[pos];
}

unsigned State::get_summ()
{
	unsigned sum = 0;
	for (size_t i = 0; i < this->datas.size(); i++)
	{
		sum += datas[i];
	}

	return sum;
}
