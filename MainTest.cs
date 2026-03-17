using ECS_OOP_CompareTEST.TEST.ECS_OOP_TEST.ECSCore.ECSDomain;
using ECS_OOP_CompareTEST.TEST.ECS_OOP_TEST.OOPCore.OOPDomain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_OOP_CompareTEST.TEST.ECS_OOP_TEST
{
	internal class MainTest
	{
		public static void Main()
		{
			TestResult[] testResult = new TestResult[2];

			testResult[0] = RunTest(new ECS_Main());
			testResult[1] = RunTest(new OOP_Main());

		}

		public static TestResult RunTest(ITest testTarget)
		{
			TestResult result = new TestResult();
			testTarget.Init(100000);
			testTarget.Run();
			GC.Collect();




			return result;
		}



	}

	public class TestResult
	{ 
	
	}




}
