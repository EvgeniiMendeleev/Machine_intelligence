#pragma region The libraries of system
#include "stdafx.h"
#include <Windows.h>
#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <clocale>
#include "conio.h"
#include <algorithm>
#pragma endregion 

#pragma region The libraries of mine
#include "Composer.h"
#include "Composition.h"
#include "Student.h"
#include "Instrument.h"
#pragma endregion The libraries for help to write an expert system for teacher of music

using namespace std;

#pragma region Functions
void clearConsole()
{
	system("cls");
}

//The function splits string to substrings.
vector<string> split(string& text, char delim)
{
	vector<string> result(1);
	size_t pos = 0;

	for (size_t i = 0; i < text.size(); i++)
	{
		if (text[i] != delim)
		{
			result[pos].push_back(text[i]);
		}
		else
		{
			result.resize(result.size() + 1);
			++pos;
		}
	}

	return result;
}

//The function loads database with musics from stream.
vector<string> loadingOfDatabase(istream& stream)
{
	vector<string> downloadedDatas;				//The data downloaded from a file.
	string dataFromFile;						//The data from the input file.

	while (getline(stream, dataFromFile))
	{
		vector<string> cutStrings = split(dataFromFile, '\"');		//Spliting string to substrings.

		//Cleaning unnecessary characters.
		cutStrings[0].erase(cutStrings[0].find(' ', 0));
		cutStrings[cutStrings.size() - 1].erase(cutStrings[cutStrings.size() - 1].find(' ', 0), 1);

		//Loading the data to buffer.
		for (unsigned short i = 0; i < cutStrings.size(); i++)
		{
			downloadedDatas.push_back(cutStrings[i]);
		}
	}

	return downloadedDatas;
}

//The function returns vector of musical instruments from the user who wants to learn how to play them.
vector<Instrument*> enterInstrumentsFromUser()
{
	string userDatas = "";
	vector<Instrument*> instruments;
	cout << "***********************************************************" << endl;
	cout << "*     EXPERT SYSTEM FOR MUSIC STUDY v1.0 by Mr.Spooky     *" << endl;
	cout << "***********************************************************" << endl;
	cout << "\nСписок инструментов, на которых хочется научиться играть:" << endl;
	cout << "(Чтобы завершить нажмите Ctrl+Z, а затем Enter)\n" << endl;

	do{
		if (strcmp(userDatas.c_str(), string("").c_str()))
		{
			instruments.push_back(new Instrument(userDatas, 0.0f));
		}
		cout << " * ";
	} while (getline(cin, userDatas));

	return instruments;
}

//Main menu of programm.
bool mainMenu()
{
	bool isExit = false;

	cout << "***********************************************************" << endl;
	cout << "*     EXPERT SYSTEM FOR MUSIC STUDY v1.0 by Mr.Spooky     *" << endl;
	cout << "***********************************************************" << endl;
	cout << "*                    Выберите команду                     *" << endl;
	cout << "* 1. Начать работу. <---                                  *" << endl;
	cout << "* 2. Выход из программы.                                  *" << endl;
	cout << "***********************************************************" << endl;

	while (true)
	{
		if (_kbhit())
		{
			switch (_getch())
			{
				case 'w':
					system("cls");
					cout << "***********************************************************" << endl;
					cout << "*     EXPERT SYSTEM FOR MUSIC STUDY v1.0 by Mr.Spooky     *" << endl;
					cout << "***********************************************************" << endl;
					cout << "*                    Выберите команду                     *" << endl;
					cout << "* 1. Начать работу. <---                                  *" << endl;
					cout << "* 2. Выход из программы.                                  *" << endl;
					cout << "***********************************************************" << endl;
					
					isExit = false;
					break;
				case 's':
					system("cls");
					cout << "***********************************************************" << endl;
					cout << "*     EXPERT SYSTEM FOR MUSIC STUDY v1.0 by Mr.Spooky     *" << endl;
					cout << "***********************************************************" << endl;
					cout << "*                    Выберите команду                     *" << endl;
					cout << "* 1. Начать работу.                                       *" << endl;
					cout << "* 2. Выход из программы. <---                             *" << endl;
					cout << "***********************************************************" << endl;

					isExit = true;
					break;
				case '\r':
					return isExit;
					break;
			}
		}
	}
}

vector<double> enterDifficultRank(vector<Instrument*> instruments)
{
	vector<double> ranks;

	unsigned short countOfInstruments = instruments.size();
	cout << "***********************************************************" << endl;
	cout << "*     EXPERT SYSTEM FOR MUSIC STUDY v1.0 by Mr.Spooky     *" << endl;
	cout << "***********************************************************" << endl;
	cout << "На сколько бы Вы оценили свой уровень игры на:" << endl;
	cout << " * ";

	for (size_t i = 0; i < instruments.size(); i++)
	{
		if (i == (instruments.size() - 1))
		{
			cout << instruments[i]->get_name() << endl;
			continue;
		}
		cout << instruments[i]->get_name() << ", ";
	}
	cout << "\nВведите последовательно уровень игры на каждом из них:" << endl;
}
#pragma endregion The mine own functions

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	ifstream fin("Input files/Input.txt");		//The input file in directory "Input file".
	const size_t COUNT_OF_ATTRIBUTES = 3;		//The count of datas into the each string in the input file.
	
	cout << "Loading of database..." << endl;
	vector<string> downloadedDatas = loadingOfDatabase(fin);			//The data downloaded from the stream.
	clearConsole();

	if (mainMenu()) return 0;
	clearConsole();

	vector<Instrument*> instruments = enterInstrumentsFromUser(); 	//Entering musical instruments from the user who wants to learn how to play them.
	clearConsole();

	float difficultRank ;
	enterDifficultRank(instruments);

	system("Pause");
	return 0;
}