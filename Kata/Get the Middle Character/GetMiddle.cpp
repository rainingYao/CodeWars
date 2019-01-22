#include "stdafx.h"
#include "CppUnitTest.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace GetMiddle
{
	TEST_CLASS(GetMiddle)
	{
	public:

		TEST_METHOD(SampleTest)
		{
			Assert().AreEqual(std::string("es"), get_middle("test"));
			Assert().AreEqual(std::string("t"), get_middle("testing"));
		}

		std::string get_middle(std::string input)
		{
			int len = input.length() - 1;
			return input.substr(len / 2, len % 2 + 1);
		}
	};
}