// Laboratory_work_1.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
#include <fstream>
#include <vector>
#include <queue>
#include <stack>
#include <string>
#include <chrono>
#include "search_algorithms.h"

using namespace std;
using namespace chrono;

size_t countAll = 0;
size_t countWay = 0;

#pragma region My own functions
vector<string> split(string& text, char delim)
{
	vector<string> result(1);
	size_t pos = 0;

	bool isResize = false;

	for (size_t i = 0; i < text.size(); i++)
	{
		if (text[i] != delim)
		{
			result[pos].push_back(text[i]);
			isResize = true;
		}
		else
		{
			if (isResize)
			{
				result.resize(result.size() + 1);
				++pos;
				isResize = false;
			}
		}
	}

	for (size_t i = 0; i < result.size(); i++)
	{
		if (result[i] == "")
		{
			result.erase(result.begin() + i);
		}
	}

	return result;
}
#pragma endregion

#pragma region Result of algorithms functions
void algorithmOfFullSearch(vector<unsigned>& numbers, unsigned N)
{
	ofstream fout("full.txt");
	vector<vector<unsigned>> results;
	vector<unsigned> sequence;
	vector<double> p;
	double countAll = 0;

	time_point<system_clock> start = system_clock::now();
	fullSearch(numbers, N, 0, 0, results, sequence, countAll);
	time_point<system_clock> end = system_clock::now();

	double avgP = 0;
	double maxP;
	double minP;

	for (size_t i = 0; i < results.size(); i++)
	{
		p.push_back(results[i].size() / countAll);
		avgP += p[i];
	}
	avgP /= results.size();

	minP = p[0];
	for (size_t i = 0; i < p.size(); i++)
	{
		if (minP > p[i])
		{
			minP = p[i];
		}
	}

	maxP = p[0];
	for (size_t i = 0; i < p.size(); i++)
	{
		if (maxP < p[i])
		{
			maxP = p[i];
		}
	}

	cout << "Full search: Elapsed time (microseconds): " << duration_cast<microseconds>(end - start).count() << endl;

	if (results.size() > 0)
	{
		fout << "Full search's sequences:" << endl;
		for (size_t i = 0; i < results.size(); i++)
		{
			fout << " * ";
			for (size_t j = 0; j < results[i].size(); j++)
			{
				fout << results[i][j] << " ";
			}
			fout << endl;
		}
	}
	else
	{
		fout << "Full search: A such sequence isn't exists" << endl;
	}
	fout << "The bad P: " << minP << endl;
	fout << "The best P: " << maxP << endl;
	fout << "Average P: " << avgP << endl;
}

/*void algorithmOfSearchInWidth(vector<unsigned>& numbers, unsigned N)
{
	ofstream fout("width.txt");
	vector<vector<unsigned>> results;
	double countAll = 0;

	time_point<system_clock> start = system_clock::now();
	searchInWidth(numbers, N, results, countAll);
	time_point<system_clock> end = system_clock::now();

	vector<double> p;
	double avgP = 0;
	double maxP;
	double minP;

	for (size_t i = 0; i < results.size(); i++)
	{
		p.push_back(results[i].size() / countAll);
		avgP += p[i];
	}
	avgP /= results.size();

	minP = p[0];
	for (size_t i = 0; i < p.size(); i++)
	{
		if (minP > p[i])
		{
			minP = p[i];
		}
	}

	maxP = p[0];
	for (size_t i = 0; i < p.size(); i++)
	{
		if (maxP < p[i])
		{
			maxP = p[i];
		}
	}

	cout << "Search in width: Elapsed time (microseconds): " << chrono::duration_cast<microseconds>(end - start).count() << endl;

	if (results.size() > 0)
	{
		fout << "Search in width's sequences:" << endl;
		for (size_t i = 0; i < results.size(); i++)
		{
			fout << " * ";
			for (size_t j = 0; j < results[i].size(); j++)
			{
				fout << results[i][j] << " ";
			}
			fout << endl;
		}
	}
	else
	{
		fout << "Search in width: A such sequence isn't exists" << endl;
	}
	fout << "The bad P: " << minP << endl;
	fout << "The best P: " << maxP << endl;
	fout << "Average P: " << avgP << endl;
}*/

void algorithmOfSearchInDepth(vector<unsigned>& numbers, unsigned N)
{
	ofstream fout("depth.txt");
	vector<vector<unsigned>> results;
	double countAll = 0;
	double sum = 0;

	time_point<system_clock> start = system_clock::now();
	searchInDepth(numbers, N, results, countAll);
	time_point<system_clock> end = system_clock::now();

	vector<double> p;
	double avgP = 0;
	double maxP;
	double minP;

	for (size_t i = 0; i < results.size(); i++)
	{
		p.push_back(results[i].size() / countAll);
		avgP += p[i];
	}
	avgP /= results.size();

	minP = p[0];
	for (size_t i = 0; i < p.size(); i++)
	{
		if (minP > p[i])
		{
			minP = p[i];
		}
	}

	maxP = p[0];
	for (size_t i = 0; i < p.size(); i++)
	{
		if (maxP < p[i])
		{
			maxP = p[i];
		}
	}

	for (size_t i = 0; i < results.size(); i++)
	{
		p.push_back(results[i].size() / countAll);
	}

	cout << "Search in depth: Elapsed time (microseconds): " << chrono::duration_cast<microseconds>(end - start).count() << endl;

	if (results.size() > 0)
	{
		fout << "Search in depth's sequences:" << endl;
		for (size_t i = 0; i < results.size(); i++)
		{
			fout << " * ";
			for (size_t j = 0; j < results[i].size(); j++)
			{
				fout << results[i][j] << " ";
			}
			fout << endl;
		}
	}
	else
	{
		fout << "Search in depth: A such sequence isn't exists" << endl;
	}
	fout << "The bad P: " << minP << endl;
	fout << "The best P: " << maxP << endl;
	fout << "Average P: " << avgP << endl;
}

void algorithmOfPointerSearch(vector<unsigned>& vec, unsigned N)
{
	ofstream fout("Pointer_Search.txt");
	vector<vector<unsigned>> results;
	double countAll = 0;
	unsigned sum = 0;
	vector<unsigned> sequence;

	time_point<system_clock> start = system_clock::now();
	pointerAlgorithm(vec, N, 0, 0, results, sequence, countAll);
	time_point<system_clock> end = system_clock::now();

	vector<double> p;
	double avgP = 0;
	double maxP;
	double minP;

	for (size_t i = 0; i < results.size(); i++)
	{
		p.push_back(results[i].size() / countAll);
		avgP += p[i];
	}
	avgP /= results.size();

	minP = p[0];
	for (size_t i = 0; i < p.size(); i++)
	{
		if (minP > p[i])
		{
			minP = p[i];
		}
	}

	maxP = p[0];
	for (size_t i = 0; i < p.size(); i++)
	{
		if (maxP < p[i])
		{
			maxP = p[i];
		}
	}

	for (size_t i = 0; i < results.size(); i++)
	{
		p.push_back(results[i].size() / countAll);
	}

	cout << "Pointer search: Elapsed time (microseconds): " << chrono::duration_cast<microseconds>(end - start).count() << endl;

	if (results.size() > 0)
	{
		fout << "Pointer search's sequences:" << endl;
		for (size_t i = 0; i < results.size(); i++)
		{
			fout << " * ";
			for (size_t j = 0; j < results[i].size(); j++)
			{
				fout << results[i][j] << " ";
			}
			fout << endl;
		}
	}
	else
	{
		fout << "Pointer search: A such sequence isn't exists" << endl;
	}

	fout << "The bad P: " << minP << endl;
	fout << "The best P: " << maxP << endl;
	fout << "Average P: " << avgP << endl;
}
#pragma endregion

int main()
{
	srand(time(NULL));
	vector<unsigned> items;
	unsigned sizeOfBag;

	string userData;
	getline(cin, userData);

	vector<string> numbers = split(userData, ' ');

	for (size_t i = 0; i < numbers.size(); i++)
	{
		items.push_back(atoi(numbers[i].c_str()));
	}

	cin >> sizeOfBag;

	algorithmOfFullSearch(items, sizeOfBag);
	algorithmOfSearchInDepth(items, sizeOfBag);
	
	for (size_t i = 0; i < items.size(); i++)
	{
		for (size_t j = 0; j < items.size(); j++)
		{
			if (items[i] > items[j])
			{
				unsigned t = items[j];
				items[j] = items[i];
				items[i] = t;
			}
		}
	}
	
	algorithmOfPointerSearch(items, sizeOfBag);

	system("Pause");
	exit(0);
}

