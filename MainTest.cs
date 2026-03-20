using ECS_OOP_CompareTEST.TEST.ECS_OOP_TEST.ECSCore.ECSDomain;
using ECS_OOP_CompareTEST.TEST.ECS_OOP_TEST.OOPCore.OOPDomain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ECS_OOP_CompareTEST.TEST.ECS_OOP_TEST
{
	internal class MainTest
	{
		public static void Main()
		{
			const int TestRepeat = 5;

			TestResult ECSresult = new TestResult();
			TestResult OOPresult = new TestResult();

			TestResult[] ECSRepeatTestResult = new TestResult[TestRepeat];
			TestResult[] OOPRepeatTestResult = new TestResult[TestRepeat];



			for (int ECSTestRepeat = 0; ECSTestRepeat < TestRepeat; ECSTestRepeat++)
			{
				ECSRepeatTestResult[ECSTestRepeat] = RunTest(new ECS_Main());
				Console.WriteLine($"=====================ECSTest _ Unit {ECSTestRepeat}===================================");
				Console.WriteLine($" Sequential	: {ECSRepeatTestResult[ECSTestRepeat].Sequential_Time:F2}ms | GC0 : {ECSRepeatTestResult[ECSTestRepeat].GC0[0]} , GC1 : {ECSRepeatTestResult[ECSTestRepeat].GC1[0]} , GC2 : {ECSRepeatTestResult[ECSTestRepeat].GC2[0]}");
			}
			ECSresult = AVGResult(ECSRepeatTestResult);
			for (int OOPTestRepeat = 0; OOPTestRepeat < TestRepeat; OOPTestRepeat++)
				OOPRepeatTestResult[OOPTestRepeat] = RunTest(new OOP_Main());
			OOPresult = AVGResult(OOPRepeatTestResult);

			for (int i = 0; i < 5; i++)
			{

			}
			Console.WriteLine("$=====================ECSTest _ AVG===================================");
			Console.WriteLine($" Sequential	: {ECSresult.Sequential_Time:F2}ms | GC0 : {ECSresult.GC0[0]} , GC1 : {ECSresult.GC1[0]} , GC2 : {ECSresult.GC2[0]}");
			Console.WriteLine($" Conditional	: {ECSresult.Sequential_Time:F2}ms | GC0 : {ECSresult.GC0[1]} , GC1 : {ECSresult.GC1[1]} , GC2 : {ECSresult.GC2[1]}");
			Console.WriteLine($" Random		: {ECSresult.Sequential_Time:F2}ms | GC0 : {ECSresult.GC0[2]} , GC1 : {ECSresult.GC1[2]} , GC2 : {ECSresult.GC2[2]}");
			Console.WriteLine($" MultiComponent : {ECSresult.Sequential_Time:F2}ms | GC0 : {ECSresult.GC0[3]} , GC1 : {ECSresult.GC1[3]} , GC2 : {ECSresult.GC2[3]}");
			Console.WriteLine($" Calculation	: {ECSresult.Sequential_Time:F2}ms | GC0 : {ECSresult.GC0[4]} , GC1 : {ECSresult.GC1[4]} , GC2 : {ECSresult.GC2[4]}");

			Console.WriteLine("=====================OOPTest _ AVG===================================");
			Console.WriteLine($" Sequential	: {OOPresult.Sequential_Time:F2}ms | GC0 : {OOPresult.GC0[0]} , GC1 : {OOPresult.GC1[0]} , GC2 : {OOPresult.GC2[0]}");
			Console.WriteLine($" Conditional	: {OOPresult.Sequential_Time:F2}ms | GC0 : {OOPresult.GC0[1]} , GC1 : {OOPresult.GC1[1]} , GC2 : {OOPresult.GC2[1]}");
			Console.WriteLine($" Random		: {OOPresult.Sequential_Time:F2}ms | GC0 : {OOPresult.GC0[2]} , GC1 : {OOPresult.GC1[2]} , GC2 : {OOPresult.GC2[2]}");
			Console.WriteLine($" MultiComponent : {OOPresult.Sequential_Time:F2}ms | GC0 : {OOPresult.GC0[3]} , GC1 : {OOPresult.GC1[3]} , GC2 : {OOPresult.GC2[3]}");
			Console.WriteLine($" Calculation	: {OOPresult.Sequential_Time:F2}ms | GC0 : {OOPresult.GC0[4]} , GC1 : {OOPresult.GC1[4]} , GC2 : {OOPresult.GC2[4]}");


		}

		public static TestResult RunTest(ITest testTarget)
		{
			int Objectcount = 1000000;
			int MaxRepeat = 10000;
			int warmUpRepeat = 10;
			//Stopwatch
			Stopwatch sw = new Stopwatch();
			// Result
			TestResult testResult = new TestResult();
			//GC
			GC.Collect();
			int GC0before;
			int GC1before;
			int GC2before;


			//RunSequential
			testTarget.Init(Objectcount);
			GC0before = GC.CollectionCount(0);
			GC1before = GC.CollectionCount(1);
			GC2before = GC.CollectionCount(2);
			for (int repeat = 0; repeat < warmUpRepeat; repeat++)
				testTarget.RunSequential();
			sw.Restart();
			for (int repeat = 0; repeat < MaxRepeat; repeat++)
				testTarget.RunSequential();
			sw.Stop();
			testResult.Sequential_Time = sw.Elapsed.TotalMilliseconds;
			testResult.GC0[0] = GC.CollectionCount(0) - GC0before;
			testResult.GC1[0] = GC.CollectionCount(1) - GC1before;
			testResult.GC2[0] = GC.CollectionCount(2) - GC2before;


			//RunConditional
			testTarget.Init(Objectcount);
			for (int repeat = 0; repeat < warmUpRepeat; repeat++)
				testTarget.RunConditional();

			GC0before = GC.CollectionCount(0);
			GC1before = GC.CollectionCount(1);
			GC2before = GC.CollectionCount(2);
			sw.Restart();
			for (int repeat = 0; repeat < MaxRepeat; repeat++)
				testTarget.RunConditional();
			sw.Stop();
			testResult.Sequential_Time = sw.Elapsed.TotalMilliseconds;
			testResult.GC0[1] = GC.CollectionCount(0) - GC0before;
			testResult.GC1[1] = GC.CollectionCount(1) - GC1before;
			testResult.GC2[1] = GC.CollectionCount(2) - GC2before;

			//RunRandom
			testTarget.Init(Objectcount);
			for (int repeat = 0; repeat < warmUpRepeat; repeat++)
				testTarget.RunRandom();

			GC0before = GC.CollectionCount(0);
			GC1before = GC.CollectionCount(1);
			GC2before = GC.CollectionCount(2);
			sw.Restart();
			for (int repeat = 0; repeat < MaxRepeat; repeat++)
				testTarget.RunRandom();
			sw.Stop();
			testResult.Sequential_Time = sw.Elapsed.TotalMilliseconds;
			testResult.GC0[2] = GC.CollectionCount(0) - GC0before;
			testResult.GC1[2] = GC.CollectionCount(1) - GC1before;
			testResult.GC2[2] = GC.CollectionCount(2) - GC2before;

			//RunMultiComponent
			testTarget.Init(Objectcount);
			for (int repeat = 0; repeat < warmUpRepeat; repeat++)
				testTarget.RunMultiComponent();

			GC0before = GC.CollectionCount(0);
			GC1before = GC.CollectionCount(1);
			GC2before = GC.CollectionCount(2);
			sw.Restart();
			for (int repeat = 0; repeat < MaxRepeat; repeat++)
				testTarget.RunMultiComponent();
			sw.Stop();
			testResult.Sequential_Time = sw.Elapsed.TotalMilliseconds;
			testResult.GC0[3] = GC.CollectionCount(0) - GC0before;
			testResult.GC1[3] = GC.CollectionCount(1) - GC1before;
			testResult.GC2[3] = GC.CollectionCount(2) - GC2before;

			//RunCalculation
			testTarget.Init(Objectcount);
			for (int repeat = 0; repeat < warmUpRepeat; repeat++)
				testTarget.RunCalculation();

			GC0before = GC.CollectionCount(0);
			GC1before = GC.CollectionCount(1);
			GC2before = GC.CollectionCount(2);
			sw.Restart();
			for (int repeat = 0; repeat < MaxRepeat; repeat++)
				testTarget.RunCalculation();
			sw.Stop();
			testResult.Sequential_Time = sw.Elapsed.TotalMilliseconds;
			testResult.GC0[4] = GC.CollectionCount(0) - GC0before;
			testResult.GC1[4] = GC.CollectionCount(1) - GC1before;
			testResult.GC2[4] = GC.CollectionCount(2) - GC2before;

			return testResult;
		}
		private static TestResult AVGResult(TestResult[] testresults)
		{
			TestResult AVGResult = new TestResult();
			for (int i = 0; i < testresults.Length; i++)
			{
				AVGResult.Sequential_Time += testresults[i].Sequential_Time;
				AVGResult.Conditional_Time += testresults[i].Conditional_Time;
				AVGResult.Random_Time += testresults[i].Random_Time;
				AVGResult.MultiComponent_Time += testresults[i].MultiComponent_Time;
				AVGResult.Calculation_Time += testresults[i].Calculation_Time;

				for (int j = 0; j < 5; j++)
				{
					AVGResult.GC0[i] += testresults[j].GC0[i];
					AVGResult.GC1[i] += testresults[j].GC1[i];
					AVGResult.GC2[i] += testresults[j].GC2[i];
				}
				AVGResult.GC0[i] /= 5;
				AVGResult.GC1[i] /= 5;
				AVGResult.GC2[i] /= 5;
			}

			AVGResult.Sequential_Time /= testresults.Length;
			AVGResult.Conditional_Time /= testresults.Length;
			AVGResult.Random_Time /= testresults.Length;
			AVGResult.MultiComponent_Time /= testresults.Length;
			AVGResult.Calculation_Time /= testresults.Length;

			return AVGResult;
		}


	}
	// 한번의 테스트가 갖게되는 결과값
	public class TestResult
	{
		// Time
		public double Sequential_Time;      //GC0[0] , GC1[0] , GC2[0]
		public double Conditional_Time;     //GC0[1] , GC1[1] , GC2[1]
		public double Random_Time;          //GC0[2] , GC1[2] , GC2[2]
		public double MultiComponent_Time;  //GC0[3] , GC1[3] , GC2[3]
		public double Calculation_Time;     //GC0[4] , GC1[4] , GC2[4]
											// GC
		public int[] GC0 = new int[5];
		public int[] GC1 = new int[5];
		public int[] GC2 = new int[5];
	}


}
