#include "stdafx.h"
#include "CppUnitTest.h"
#include <vector>

using namespace std;
using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace CodeWarsCpp
{
	TEST_CLASS(tickets_test)
	{
	public:

		TEST_METHOD(Sample_Test)
		{
			string yes = "YES";
			string no = "NO";
			vector<int> v1 = { 25,25,50,50 };
			vector<int> v2 = { 25,100 };
			Assert().AreEqual(yes, tickets(v1));
			Assert().AreEqual(no, tickets(v2));
		}

		std::string tickets(const vector<int> peopleInLine)
		{
			int i25 = 0;
			int i50 = 0;
			int i100 = 0;
			for (int i = 0; i < peopleInLine.size(); i++)
			{
				if (25 == peopleInLine[i]) i25 += 25;
				else if (50 == peopleInLine[i])
				{
					if (i25 == 0)return"NO";
					i25 -= 25;
					i50 += 50;
				}
				else
				{
					if (i25 <= 25 || i25 + i50 < 75) return"NO";
					i25 -= 25;
					if (i50 >= 50)i50 -= 50;
					else if (i25 >= 50)i25 -= 50;
					else return "NO";
				}
			}
			return "YES";
		}
	};
}
