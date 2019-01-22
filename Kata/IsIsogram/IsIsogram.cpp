#include "stdafx.h"
#include "CppUnitTest.h"
#include <set>

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace IsIsogram
{
	TEST_CLASS(IsIsogram)
	{
	public:

		TEST_METHOD(SampleTest)
		{
			Assert().AreEqual(true, is_isogram("abcd"));
			Assert().AreEqual(false, is_isogram("aabcd"));
		}

		bool is_isogram(std::string str) {
			std::set<char> charset;
			for (char letter : str)
			{
				if (letter>'Z') letter -= 32;
				if (charset.count(letter) == 0)
					charset.insert(letter);
			}
			return charset.size() == str.length();
		}
	};
}
