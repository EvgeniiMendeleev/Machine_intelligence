#include "stdafx.h"
#include "search_algorithms.h"

void fullSearch(vector<unsigned>& numbers, unsigned N, unsigned sum, unsigned lastNumber, vector<vector<unsigned>>& results, vector<unsigned>& sequence, double& countAll)
{
	if (sum == N)
	{
		++countAll;
		results.push_back(sequence);
		return;
	}

	for (size_t i = lastNumber; i < numbers.size(); i++)
	{
		if (sum + numbers[i] <= N)
		{
			++countAll;
			sequence.push_back(numbers[i]);
			fullSearch(numbers, N, sum + numbers[i], i + 1, results, sequence, countAll);
			sequence.resize(sequence.size() - 1);
		}
	}
}

void searchInDepth(vector<unsigned>& numbers, unsigned N, vector<vector<unsigned>>& results, double& countAll)
{
	for (size_t i = 0; i < numbers.size(); i++)
	{
		stack<State> vertexs;
		vertexs.push(State(numbers[i], i));

		while (!vertexs.empty())
		{
			State state = vertexs.top();
			vertexs.pop();

			for (size_t j = state.get_last_pos() + 1; j < numbers.size(); j++)
			{
				if (state.get_summ() + numbers[j] < N)
				{
					++countAll;
					size_t lastPos = state.get_last_pos();

					state.push_number(numbers[j]);
					state.set_last_pos(j);

					vertexs.push(state);

					state.pop_back();
					state.set_last_pos(lastPos);
				}
				else if (state.get_summ() + numbers[j] == N)
				{
					++countAll;
					state.push_number(numbers[j]);
					results.push_back(state.get_numbers());
					state.pop_back();
				}
			}
		}
	}
}

void pointerAlgorithm(vector<unsigned>& numbers, unsigned N, unsigned sum, unsigned lastNumber, vector<vector<unsigned>>& results, vector<unsigned>& sequence, double& countAll)
{
	if (sum == N)
	{
		++countAll;
		results.push_back(sequence);
		return;
	}

	for (size_t i = lastNumber; i < numbers.size(); i++)
	{
		if (sum + numbers[i] <= N)
		{
			++countAll;
			sequence.push_back(numbers[i]);
			fullSearch(numbers, N, sum + numbers[i], i + 1, results, sequence, countAll);
			sequence.resize(sequence.size() - 1);
		}
	}
}

/*void pointerAlgorithm(vector<unsigned>& numbers, unsigned N, vector<vector<unsigned>>& results, vector<unsigned>& sequence)
{
	if (sum == N)
	{
		results.push_back(sequence);
		return;
	}

	unsigned minNumber = numbers.front();

	for (size_t i = 0; i < numbers.size(); i++)
	{
		if (minNumber > numbers[i])
		{
			minNumber = numbers[i];
			j = i;
		}
	}

	if (sum + numbers[j] <= N)
	{
		sequence.push_back(numbers[j]);
		numbers.erase(numbers.begin() + j);

		pointerAlgorithm(numbers, N, sum + numbers[j], j, results, sequence, wasTaked);
		
		numbers.insert(numbers.begin() + j, sequence.back());
		sequence.pop_back();
	}
}*/

#pragma region Algorithm
void searchInWidth(vector<unsigned>& numbers, unsigned N, vector<vector<unsigned>>& results, double& countAll)
{
	for (size_t i = 0; i < numbers.size(); i++)
	{
		queue<State> vertexs;
		vertexs.push(State(numbers[i], i));

		while (!vertexs.empty())
		{
			State state = vertexs.front();
			vertexs.pop();

			for (size_t j = state.get_last_pos() + 1; j < numbers.size(); j++)
			{
				if (state.get_summ() + numbers[j] < N)
				{
					size_t lastPos = state.get_last_pos();

					++countAll;
					state.push_number(numbers[j]);
					state.set_last_pos(j);

					vertexs.push(state);

					state.pop_back();
					state.set_last_pos(lastPos);
				}
				else if (state.get_summ() + numbers[j] == N)
				{
					++countAll;
					state.push_number(numbers[j]);
					results.push_back(state.get_numbers());
					state.pop_back();
				}
			}
		}
	}
}
#pragma endregion Full search algorithm