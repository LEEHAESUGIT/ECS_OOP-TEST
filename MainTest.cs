using ECS_OOP_CompareTEST;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ECS_OOP_CompareTEST
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

			// ECS
			// 개별 테스트
			for (int ECSTestRepeat = 0; ECSTestRepeat < TestRepeat; ECSTestRepeat++)
			{
				ECSRepeatTestResult[ECSTestRepeat] = RunTest(new ECS_Main());
				Console.WriteLine($"=====================ECSTest _ Unit {ECSTestRepeat}===================================");
				Console.WriteLine($" Sequential	: {ECSRepeatTestResult[ECSTestRepeat].Sequential_Time:F2}ms | GC0 : {ECSRepeatTestResult[ECSTestRepeat].GC0[0]:F1} , GC1 : {ECSRepeatTestResult[ECSTestRepeat].GC1[0]:F1} , GC2 : {ECSRepeatTestResult[ECSTestRepeat].GC2[0]:F1}");
				Console.WriteLine($" Conditional	: {ECSRepeatTestResult[ECSTestRepeat].Conditional_Time:F2}ms | GC0 : {ECSRepeatTestResult[ECSTestRepeat].GC0[1]:F1} , GC1 : {ECSRepeatTestResult[ECSTestRepeat].GC1[1]:F1} , GC2 : {ECSRepeatTestResult[ECSTestRepeat].GC2[1]:F1}");
				Console.WriteLine($" Random		: {ECSRepeatTestResult[ECSTestRepeat].Random_Time:F2}ms | GC0 : {ECSRepeatTestResult[ECSTestRepeat].GC0[2]:F1} , GC1 : {ECSRepeatTestResult[ECSTestRepeat].GC1[2]:F1} , GC2 : {ECSRepeatTestResult[ECSTestRepeat].GC2[2]:F1}");
				Console.WriteLine($" MultiComponent	: {ECSRepeatTestResult[ECSTestRepeat].MultiComponent_Time:F2}ms | GC0 : {ECSRepeatTestResult[ECSTestRepeat].GC0[3]:F1} , GC1 : {ECSRepeatTestResult[ECSTestRepeat].GC1[3]:F1} , GC2 : {ECSRepeatTestResult[ECSTestRepeat].GC2[3]:F1}");
				Console.WriteLine($" Calculation	: {ECSRepeatTestResult[ECSTestRepeat].Calculation_Time:F2}ms | GC0 : {ECSRepeatTestResult[ECSTestRepeat].GC0[4]:F1} , GC1 : {ECSRepeatTestResult[ECSTestRepeat].GC1[4]:F1} , GC2 : {ECSRepeatTestResult[ECSTestRepeat].GC2[4]:F1}");
			}
			ECSresult = AVGResult(ECSRepeatTestResult);
			// 전체 테스트 평균
			Console.WriteLine("=====================ECSTest _ AVG===================================");
			Console.WriteLine($" Sequential	: {ECSresult.Sequential_Time:F2}ms | GC0 : {ECSresult.GC0[0]:F1} , GC1 : {ECSresult.GC1[0]:F1} , GC2 : {ECSresult.GC2[0]:F1}");
			Console.WriteLine($" Conditional	: {ECSresult.Conditional_Time:F2}ms | GC0 : {ECSresult.GC0[1]:F1} , GC1 : {ECSresult.GC1[1]:F1} , GC2 : {ECSresult.GC2[1]:F1}");
			Console.WriteLine($" Random		: {ECSresult.Random_Time:F2}ms | GC0 : {ECSresult.GC0[2]:F1} , GC1 : {ECSresult.GC1[2]:F1} , GC2 : {ECSresult.GC2[2]:F1}");
			Console.WriteLine($" MultiComponent : {ECSresult.MultiComponent_Time:F2}ms | GC0 : {ECSresult.GC0[3]:F1} , GC1 : {ECSresult.GC1[3]:F1} , GC2 : {ECSresult.GC2[3]:F1}");
			Console.WriteLine($" Calculation	: {ECSresult.Calculation_Time:F2}ms | GC0 : {ECSresult.GC0[4]:F1} , GC1 : {ECSresult.GC1[4]:F1} , GC2 : {ECSresult.GC2[4]:F1}");

			Console.WriteLine("\n");
			Console.WriteLine("\n");
			Console.WriteLine("\n");
			// OOP
			for (int OOPTestRepeat = 0; OOPTestRepeat < TestRepeat; OOPTestRepeat++)
			{
				OOPRepeatTestResult[OOPTestRepeat] = RunTest(new OOP_Main());
				Console.WriteLine($"=====================OOPTest _ Unit {OOPTestRepeat}===================================");
				Console.WriteLine($" Sequential	: {OOPRepeatTestResult[OOPTestRepeat].Sequential_Time:F2}ms | GC0 : {OOPRepeatTestResult[OOPTestRepeat].GC0[0]:F1} , GC1 : {OOPRepeatTestResult[OOPTestRepeat].GC1[0]:F1} , GC2 : {OOPRepeatTestResult[OOPTestRepeat].GC2[0]:F1}");
				Console.WriteLine($" Conditional	: {OOPRepeatTestResult[OOPTestRepeat].Conditional_Time:F2}ms | GC0 : {OOPRepeatTestResult[OOPTestRepeat].GC0[1]:F1} , GC1 : {OOPRepeatTestResult[OOPTestRepeat].GC1[1]:F1} , GC2 : {OOPRepeatTestResult[OOPTestRepeat].GC2[1]:F1}");
				Console.WriteLine($" Random		: {OOPRepeatTestResult[OOPTestRepeat].Random_Time:F2}ms | GC0 : {OOPRepeatTestResult[OOPTestRepeat].GC0[2]:F1} , GC1 : {OOPRepeatTestResult[OOPTestRepeat].GC1[2]:F1} , GC2 : {OOPRepeatTestResult[OOPTestRepeat].GC2[2]}");
				Console.WriteLine($" MultiComponent	: {OOPRepeatTestResult[OOPTestRepeat].MultiComponent_Time:F2}ms | GC0 : {OOPRepeatTestResult[OOPTestRepeat].GC0[3]:F1} , GC1 : {OOPRepeatTestResult[OOPTestRepeat].GC1[3]:F1} , GC2 : {OOPRepeatTestResult[OOPTestRepeat].GC2[3]:F1}");
				Console.WriteLine($" Calculation	: {OOPRepeatTestResult[OOPTestRepeat].Calculation_Time:F2}ms | GC0 : {OOPRepeatTestResult[OOPTestRepeat].GC0[4]:F1} , GC1 : {OOPRepeatTestResult[OOPTestRepeat].GC1[4]:F1} , GC2 : {OOPRepeatTestResult[OOPTestRepeat].GC2[4]:F1}");
			}
			OOPresult = AVGResult(OOPRepeatTestResult);
			// 전체 테스트 평균
			Console.WriteLine("=====================OOPTest _ AVG===================================");
			Console.WriteLine($" Sequential	: {OOPresult.Sequential_Time:F2}ms | GC0 : {OOPresult.GC0[0]:F1} , GC1 : {OOPresult.GC1[0]:F1} , GC2 : {OOPresult.GC2[0]:F1}");
			Console.WriteLine($" Conditional	: {OOPresult.Conditional_Time:F2}ms | GC0 : {OOPresult.GC0[1]:F1} , GC1 : {OOPresult.GC1[1]:F1} , GC2 : {OOPresult.GC2[1]:F1}");
			Console.WriteLine($" Random		: {OOPresult.Random_Time:F2}ms | GC0 : {OOPresult.GC0[2]:F1} , GC1 : {OOPresult.GC1[2]:F1} , GC2 : {OOPresult.GC2[2]:F1}");
			Console.WriteLine($" MultiComponent : {OOPresult.MultiComponent_Time:F2}ms | GC0 : {OOPresult.GC0[3]:F1} , GC1 : {OOPresult.GC1[3]:F1} , GC2 : {OOPresult.GC2[3]:F1}");
			Console.WriteLine($" Calculation	: {OOPresult.Calculation_Time:F2}ms | GC0 : {OOPresult.GC0[4]:F1} , GC1 : {OOPresult.GC1[4]:F1} , GC2 : {OOPresult.GC2[4]:F1}");


		}

		public static TestResult RunTest(ITest testTarget)
		{
			int Objectcount = 100000;
			int MaxRepeat = 10000;
			int warmUpRepeat = 10;
			//Stopwatch
			Stopwatch sw = new Stopwatch();
			// Result
			TestResult testResult = new TestResult();
			//GC
			GC.Collect();
			float GC0before;
			float GC1before;
			float GC2before;


			//RunSequential
			testTarget.Init(Objectcount);
			for (int repeat = 0; repeat < warmUpRepeat; repeat++)
				testTarget.RunSequential();

			GC0before = GC.CollectionCount(0);
			GC1before = GC.CollectionCount(1);
			GC2before = GC.CollectionCount(2);

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
			testResult.Conditional_Time = sw.Elapsed.TotalMilliseconds;
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
			testResult.Random_Time = sw.Elapsed.TotalMilliseconds;
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
			testResult.MultiComponent_Time = sw.Elapsed.TotalMilliseconds;
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
			testResult.Calculation_Time = sw.Elapsed.TotalMilliseconds;
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
					AVGResult.GC0[j] += testresults[i].GC0[j];
					AVGResult.GC1[j] += testresults[i].GC1[j];
					AVGResult.GC2[j] += testresults[i].GC2[j];
				}
			}
			for (int i = 0; i < 5; i++)
			{
				AVGResult.GC0[i] = AVGResult.GC0[i] / 5;
				AVGResult.GC1[i] = AVGResult.GC1[i] / 5;
				AVGResult.GC2[i] = AVGResult.GC2[i] / 5;
			}
			AVGResult.Sequential_Time = (double)(AVGResult.Sequential_Time / testresults.Length);
			AVGResult.Conditional_Time = (double)(AVGResult.Conditional_Time / testresults.Length);
			AVGResult.Random_Time = (double)(AVGResult.Random_Time / testresults.Length);
			AVGResult.MultiComponent_Time = (double)(AVGResult.MultiComponent_Time / testresults.Length);
			AVGResult.Calculation_Time = (double)(AVGResult.Calculation_Time / testresults.Length);

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
		public float[] GC0 = new float[5];
		public float[] GC1 = new float[5];
		public float[] GC2 = new float[5];
	}


}
