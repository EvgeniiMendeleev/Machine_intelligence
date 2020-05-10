#pragma once
#include <vector>

using namespace std;

typedef unsigned Data;

class State final
{
	vector<Data> datas;
	size_t lastPos;

public:
	explicit State(Data number, size_t lastPos);
	~State() = default;

	void push_number(Data data);
	void pop_back();

	vector<Data> get_numbers();
	size_t get_last_pos();
	void set_last_pos(size_t lastPos);
	Data get_number(unsigned pos);
	unsigned get_summ();
};