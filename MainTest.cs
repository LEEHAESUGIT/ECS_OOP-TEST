using ECS_OOP_CompareTEST;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ECS_OOP_CompareTEST
{
	internal class MainTest
	{
		public static void Main()
		{
			const int Objectcount = 300000;
			const int RepeatCount = 20;
			const int warmup = 3;


			// 테스트별 반복한 결과값 - Init
			InitTestResult[] Sequential_Init = new InitTestResult[RepeatCount];
			InitTestResult[] Conditional_Init = new InitTestResult[RepeatCount];
			InitTestResult[] Random_Init = new InitTestResult[RepeatCount];
			InitTestResult[] MultiComponent_Init = new InitTestResult[RepeatCount];
			InitTestResult[] Calculation_Init = new InitTestResult[RepeatCount];
			// 테스트별 반복한 결과값 - Run
			RunTestResult[] Sequential_Run = new RunTestResult[RepeatCount];
			RunTestResult[] Conditional_Run = new RunTestResult[RepeatCount];
			RunTestResult[] Random_Run = new RunTestResult[RepeatCount];
			RunTestResult[] MultiComponent_Run = new RunTestResult[RepeatCount];
			RunTestResult[] Calculation_Run = new RunTestResult[RepeatCount];

			// 반복테스트의 평균값 저장 - Init
			InitTestAVGResult Sequential_Init_AVG = new InitTestAVGResult();
			InitTestAVGResult Conditional_Init_AVG = new InitTestAVGResult();
			InitTestAVGResult Random_Init_AVG = new InitTestAVGResult();
			InitTestAVGResult MultiComponent_Init_AVG = new InitTestAVGResult();
			InitTestAVGResult Calculation_Init_AVG = new InitTestAVGResult();
			// 반복테스트의 평균값 저장 - Run
			RunTestAVGResult Sequential_Run_AVG = new RunTestAVGResult();
			RunTestAVGResult Conditional_Run_AVG = new RunTestAVGResult();
			RunTestAVGResult Random_Run_AVG = new RunTestAVGResult();
			RunTestAVGResult MultiComponent_Run_AVG = new RunTestAVGResult();
			RunTestAVGResult Calculation_Run_AVG = new RunTestAVGResult();


			// ECS
			#region ECSTEST
			RepeatTest_Cycle(typeof(ECS_Main),
								Objectcount,
								RepeatCount,
								warmup,
								obj => InitTest((ECS_Main)obj, Objectcount),
								obj => SequentialTest((ECS_Main)obj , Objectcount),
								out InitTestResult[] aa,
								out RunTestResult[] bb);
			Sequential_Init = aa;
			Sequential_Run = bb;
			Sequential_Init_AVG.AVGCaculatorForResult(Sequential_Init);
			Sequential_Run_AVG.AVGCaculatorForResult(Sequential_Run);
			ECS_ResultView(RepeatCount,Sequential_Init,Sequential_Run);
			ECS_ResultAVGView(Sequential_Init_AVG , Sequential_Run_AVG);





			//Conditional_Init_AVG.AVGCaculatorForResult(Conditional_Init);
			//Random_Init_AVG.AVGCaculatorForResult(Random_Init);
			//MultiComponent_Init_AVG.AVGCaculatorForResult(MultiComponent_Init);
			//Calculation_Init_AVG.AVGCaculatorForResult(Calculation_Init);

			//Conditional_Run_AVG.AVGCaculatorForResult(Conditional_Run);
			//Random_Run_AVG.AVGCaculatorForResult(Random_Run);
			//MultiComponent_Run_AVG.AVGCaculatorForResult(MultiComponent_Run);
			//Calculation_Run_AVG.AVGCaculatorForResult(Calculation_Run);



			#endregion

			#region OOPTEST
			RepeatTest_Cycle(typeof(OOP_Main),
								Objectcount,
								RepeatCount,
								warmup,
								obj => InitTest((OOP_Main)obj, Objectcount),
								obj => SequentialTest((OOP_Main)obj, Objectcount),
								out InitTestResult[] cc,
								out RunTestResult[] dd);
			Sequential_Init = cc;
			Sequential_Run = dd;
			Sequential_Init_AVG.AVGCaculatorForResult(Sequential_Init);
			Sequential_Run_AVG.AVGCaculatorForResult(Sequential_Run);
			OOP_ResultView(RepeatCount, Sequential_Init, Sequential_Run);
			OOP_ResultAVGView(Sequential_Init_AVG, Sequential_Run_AVG);
			#endregion



			//TestResult ECSresult = new TestResult();
			//TestResult OOPresult = new TestResult();

			//TestResult[] ECSRepeatTestResult = new TestResult[CycleCount];
			//TestResult[] OOPRepeatTestResult = new TestResult[CycleCount];

			//// ECS
			//// 개별 테스트
			//for (int ECSTestRepeat = 0; ECSTestRepeat < CycleCount; ECSTestRepeat++)
			//{
			//	ECSRepeatTestResult[ECSTestRepeat] = RunTest(new ECS_Main());
			//	Console.WriteLine($"=====================ECSTest _ Unit {ECSTestRepeat}===================================");
			//	Console.WriteLine($" Sequential	: {ECSRepeatTestResult[ECSTestRepeat].Sequential_Time:F2}ms | GC0 : {ECSRepeatTestResult[ECSTestRepeat].GC0[0]:F1} , GC1 : {ECSRepeatTestResult[ECSTestRepeat].GC1[0]:F1} , GC2 : {ECSRepeatTestResult[ECSTestRepeat].GC2[0]:F1}");
			//	Console.WriteLine($" Conditional	: {ECSRepeatTestResult[ECSTestRepeat].Conditional_Time:F2}ms | GC0 : {ECSRepeatTestResult[ECSTestRepeat].GC0[1]:F1} , GC1 : {ECSRepeatTestResult[ECSTestRepeat].GC1[1]:F1} , GC2 : {ECSRepeatTestResult[ECSTestRepeat].GC2[1]:F1}");
			//	Console.WriteLine($" Random		: {ECSRepeatTestResult[ECSTestRepeat].Random_Time:F2}ms | GC0 : {ECSRepeatTestResult[ECSTestRepeat].GC0[2]:F1} , GC1 : {ECSRepeatTestResult[ECSTestRepeat].GC1[2]:F1} , GC2 : {ECSRepeatTestResult[ECSTestRepeat].GC2[2]:F1}");
			//	Console.WriteLine($" MultiComponent	: {ECSRepeatTestResult[ECSTestRepeat].MultiComponent_Time:F2}ms | GC0 : {ECSRepeatTestResult[ECSTestRepeat].GC0[3]:F1} , GC1 : {ECSRepeatTestResult[ECSTestRepeat].GC1[3]:F1} , GC2 : {ECSRepeatTestResult[ECSTestRepeat].GC2[3]:F1}");
			//	Console.WriteLine($" Calculation	: {ECSRepeatTestResult[ECSTestRepeat].Calculation_Time:F2}ms | GC0 : {ECSRepeatTestResult[ECSTestRepeat].GC0[4]:F1} , GC1 : {ECSRepeatTestResult[ECSTestRepeat].GC1[4]:F1} , GC2 : {ECSRepeatTestResult[ECSTestRepeat].GC2[4]:F1}");
			//}
			//ECSresult = AVGResult(ECSRepeatTestResult);
			//// 전체 테스트 평균
			//Console.WriteLine("=====================ECSTest _ AVG===================================");
			//Console.WriteLine($" Sequential	: {ECSresult.Sequential_Time:F2}ms | GC0 : {ECSresult.GC0[0]:F1} , GC1 : {ECSresult.GC1[0]:F1} , GC2 : {ECSresult.GC2[0]:F1}");
			//Console.WriteLine($" Conditional	: {ECSresult.Conditional_Time:F2}ms | GC0 : {ECSresult.GC0[1]:F1} , GC1 : {ECSresult.GC1[1]:F1} , GC2 : {ECSresult.GC2[1]:F1}");
			//Console.WriteLine($" Random		: {ECSresult.Random_Time:F2}ms | GC0 : {ECSresult.GC0[2]:F1} , GC1 : {ECSresult.GC1[2]:F1} , GC2 : {ECSresult.GC2[2]:F1}");
			//Console.WriteLine($" MultiComponent : {ECSresult.MultiComponent_Time:F2}ms | GC0 : {ECSresult.GC0[3]:F1} , GC1 : {ECSresult.GC1[3]:F1} , GC2 : {ECSresult.GC2[3]:F1}");
			//Console.WriteLine($" Calculation	: {ECSresult.Calculation_Time:F2}ms | GC0 : {ECSresult.GC0[4]:F1} , GC1 : {ECSresult.GC1[4]:F1} , GC2 : {ECSresult.GC2[4]:F1}");

			//Console.WriteLine("\n");
			//Console.WriteLine("\n");
			//Console.WriteLine("\n");
			//// OOP
			//for (int OOPTestRepeat = 0; OOPTestRepeat < TestRepeat; OOPTestRepeat++)
			//{
			//	OOPRepeatTestResult[OOPTestRepeat] = RunTest(new OOP_Main());
			//	Console.WriteLine($"=====================OOPTest _ Unit {OOPTestRepeat}===================================");
			//	Console.WriteLine($" Sequential	: {OOPRepeatTestResult[OOPTestRepeat].Sequential_Time:F2}ms | GC0 : {OOPRepeatTestResult[OOPTestRepeat].GC0[0]:F1} , GC1 : {OOPRepeatTestResult[OOPTestRepeat].GC1[0]:F1} , GC2 : {OOPRepeatTestResult[OOPTestRepeat].GC2[0]:F1}");
			//	Console.WriteLine($" Conditional	: {OOPRepeatTestResult[OOPTestRepeat].Conditional_Time:F2}ms | GC0 : {OOPRepeatTestResult[OOPTestRepeat].GC0[1]:F1} , GC1 : {OOPRepeatTestResult[OOPTestRepeat].GC1[1]:F1} , GC2 : {OOPRepeatTestResult[OOPTestRepeat].GC2[1]:F1}");
			//	Console.WriteLine($" Random		: {OOPRepeatTestResult[OOPTestRepeat].Random_Time:F2}ms | GC0 : {OOPRepeatTestResult[OOPTestRepeat].GC0[2]:F1} , GC1 : {OOPRepeatTestResult[OOPTestRepeat].GC1[2]:F1} , GC2 : {OOPRepeatTestResult[OOPTestRepeat].GC2[2]}");
			//	Console.WriteLine($" MultiComponent	: {OOPRepeatTestResult[OOPTestRepeat].MultiComponent_Time:F2}ms | GC0 : {OOPRepeatTestResult[OOPTestRepeat].GC0[3]:F1} , GC1 : {OOPRepeatTestResult[OOPTestRepeat].GC1[3]:F1} , GC2 : {OOPRepeatTestResult[OOPTestRepeat].GC2[3]:F1}");
			//	Console.WriteLine($" Calculation	: {OOPRepeatTestResult[OOPTestRepeat].Calculation_Time:F2}ms | GC0 : {OOPRepeatTestResult[OOPTestRepeat].GC0[4]:F1} , GC1 : {OOPRepeatTestResult[OOPTestRepeat].GC1[4]:F1} , GC2 : {OOPRepeatTestResult[OOPTestRepeat].GC2[4]:F1}");
			//}
			//OOPresult = AVGResult(OOPRepeatTestResult);
			//// 전체 테스트 평균
			//Console.WriteLine("=====================OOPTest _ AVG===================================");
			//Console.WriteLine($" Sequential	: {OOPresult.Sequential_Time:F2}ms | GC0 : {OOPresult.GC0[0]:F1} , GC1 : {OOPresult.GC1[0]:F1} , GC2 : {OOPresult.GC2[0]:F1}");
			//Console.WriteLine($" Conditional	: {OOPresult.Conditional_Time:F2}ms | GC0 : {OOPresult.GC0[1]:F1} , GC1 : {OOPresult.GC1[1]:F1} , GC2 : {OOPresult.GC2[1]:F1}");
			//Console.WriteLine($" Random		: {OOPresult.Random_Time:F2}ms | GC0 : {OOPresult.GC0[2]:F1} , GC1 : {OOPresult.GC1[2]:F1} , GC2 : {OOPresult.GC2[2]:F1}");
			//Console.WriteLine($" MultiComponent : {OOPresult.MultiComponent_Time:F2}ms | GC0 : {OOPresult.GC0[3]:F1} , GC1 : {OOPresult.GC1[3]:F1} , GC2 : {OOPresult.GC2[3]:F1}");
			//Console.WriteLine($" Calculation	: {OOPresult.Calculation_Time:F2}ms | GC0 : {OOPresult.GC0[4]:F1} , GC1 : {OOPresult.GC1[4]:F1} , GC2 : {OOPresult.GC2[4]:F1}");


		}

		public static void ECS_ResultView(int repeatCount , InitTestResult[] init , RunTestResult[] run)
		{
			for(int i = 0 ; i < repeatCount; i++)
			{
				Console.WriteLine($"=====================ECSTest_Init {i+1}===================================");
				Console.WriteLine($" Sequential	: {init[i].Elapsed_Time:F2}ms | Allocated_Memory : {init[i].Allocated_Memory:F2} | TimeToEntityCreate : {init[i].TimeToEntityCreate:F2}  | MemoryToEntityCreate : {init[i].MemoryToEntityCreate:F2} | GC0 : {init[i].GC0:F1} , GC1 : {init[i].GC1:F1} , GC2 : {init[i].GC2:F1}");
				Console.WriteLine($"=====================ECSTest_Run {i+1}===================================");
				Console.WriteLine($" Sequential	: {run[i].Elapsed_Time:F2}ms | Allocated_Memory : {run[i].Allocated_Memory:F2} | AVG_Process_Time : {run[i].AVG_Process_Time:F2}  | SecForProcess_Time : {run[i].SecForProcess_Time:F2} | GC0 : {run[i].GC0:F1} , GC1 : {run[i].GC1:F1} , GC2 : {run[i].GC2:F1}");
				Console.WriteLine("\n");
			}
		}
		public static void ECS_ResultAVGView(InitTestAVGResult init , RunTestAVGResult run)
		{
			Console.WriteLine($"=====================ECSTest_Init_AVG ===================================");
			Console.WriteLine($" Sequential	: {init.Elapsed_Time:F2}ms | Allocated_Memory : {init.Allocated_Memory:F2} | TimeToEntityCreate : {init.TimeToEntityCreate:F2}  | MemoryToEntityCreate : {init.MemoryToEntityCreate:F2} | GC0 : {init.GC0:F1} , GC1 : {init.GC1:F1} , GC2 : {init.GC2:F1}");
			Console.WriteLine($"=====================ECSTest_Run_AVG===================================");
			Console.WriteLine($" Sequential	: {run.Elapsed_Time:F2}ms | Allocated_Memory : {run.Allocated_Memory:F2} | AVG_Process_Time : {run.AVG_Process_Time:F2}  | SecForProcess_Time : {run.SecForProcess_Time:F2} | GC0 : {run.GC0:F1} , GC1 : {run.GC1:F1} , GC2 : {run.GC2:F1}");
		}
		public static void OOP_ResultView(int repeatCount, InitTestResult[] init, RunTestResult[] run)
		{
			for (int i = 0; i < repeatCount; i++)
			{
				Console.WriteLine($"=====================OOPTest_Init {i + 1}===================================");
				Console.WriteLine($" Sequential	: {init[i].Elapsed_Time:F2}ms | Allocated_Memory : {init[i].Allocated_Memory:F2} | TimeToEntityCreate : {init[i].TimeToEntityCreate:F2}  | MemoryToEntityCreate : {init[i].MemoryToEntityCreate:F2} | GC0 : {init[i].GC0:F1} , GC1 : {init[i].GC1:F1} , GC2 : {init[i].GC2:F1}");
				Console.WriteLine($"=====================OOPTest_Run {i + 1}===================================");
				Console.WriteLine($" Sequential	: {run[i].Elapsed_Time:F2}ms | Allocated_Memory : {run[i].Allocated_Memory:F2} | AVG_Process_Time : {run[i].AVG_Process_Time:F2}  | SecForProcess_Time : {run[i].SecForProcess_Time:F2} | GC0 : {run[i].GC0:F1} , GC1 : {run[i].GC1:F1} , GC2 : {run[i].GC2:F1}");
				Console.WriteLine("\n");
			}
		}
		public static void OOP_ResultAVGView(InitTestAVGResult init, RunTestAVGResult run)
		{
			Console.WriteLine($"=====================OOPTest_Init_AVG ===================================");
			Console.WriteLine($" Sequential	: {init.Elapsed_Time:F2}ms | Allocated_Memory : {init.Allocated_Memory:F2} | TimeToEntityCreate : {init.TimeToEntityCreate:F2}  | MemoryToEntityCreate : {init.MemoryToEntityCreate:F2} | GC0 : {init.GC0:F1} , GC1 : {init.GC1:F1} , GC2 : {init.GC2:F1}");
			Console.WriteLine($"=====================OOPTest_Run_AVG===================================");
			Console.WriteLine($" Sequential	: {run.Elapsed_Time:F2}ms | Allocated_Memory : {run.Allocated_Memory:F2} | AVG_Process_Time : {run.AVG_Process_Time:F2}  | SecForProcess_Time : {run.SecForProcess_Time:F2} | GC0 : {run.GC0:F1} , GC1 : {run.GC1:F1} , GC2 : {run.GC2:F1}");
		}

		public static void RepeatTest_Cycle(Type Itest,
												int objcount,
												int RepeatCount,
												int warmupCount,
												Func<ITest, InitTestResult> init,
												Func<ITest, RunTestResult> run,
												out InitTestResult[] init_results,
												out RunTestResult[] run_results)
		{
			init_results = new InitTestResult[RepeatCount];
			run_results = new RunTestResult[RepeatCount];


			ITest WarmUP_OBJ;
			for (int i = 0; i < warmupCount; i++)
			{
				if (Itest == typeof(ECS_Main))
					WarmUP_OBJ = new ECS_Main();
				else if (Itest == typeof(OOP_Main))
					WarmUP_OBJ = new OOP_Main();
				else
					throw new TypeAccessException();
				init(WarmUP_OBJ);
				run(WarmUP_OBJ);
			}

			ITest Real_OBJ;
			for (int i = 0; i < RepeatCount; i++)
			{
				if (Itest == typeof(ECS_Main))
					Real_OBJ = new ECS_Main();
				else if (Itest == typeof(OOP_Main))
					Real_OBJ = new OOP_Main();
				else
					throw new TypeAccessException();

				init_results[i] = init(Real_OBJ);
				run_results[i] = run(Real_OBJ);
			}
		}
		public static InitTestResult InitTest(ITest testOBJ, int objCount)
		{
			InitTestResult result = new InitTestResult();
			// Elapsed Time
			Stopwatch sw = new Stopwatch();

			//GC
			GC.Collect();
			float GC0before;
			float GC1before;
			float GC2before;


			GC0before = GC.CollectionCount(0);
			GC1before = GC.CollectionCount(1);
			GC2before = GC.CollectionCount(2);

			//Allocated Memory
			long beforeAlloc = GC.GetAllocatedBytesForCurrentThread();

			sw.Restart();
			testOBJ.Init(objCount);
			sw.Stop();

			//Allocated Memory
			long afterAlloc = GC.GetAllocatedBytesForCurrentThread();

			result.Elapsed_Time = sw.Elapsed.TotalMilliseconds;
			result.Allocated_Memory = afterAlloc - beforeAlloc;
			result.GC0 = GC.CollectionCount(0) - GC0before;
			result.GC1 = GC.CollectionCount(1) - GC1before;
			result.GC2 = GC.CollectionCount(2) - GC2before;
			//엔티티 생성 수 대비 성능
			result.TimeToEntityCreate = result.Elapsed_Time / objCount;
			result.MemoryToEntityCreate = result.Allocated_Memory / objCount;

			return result;
		}

		public static RunTestResult SequentialTest(ITest testOBJ , int objCount)
		{
			RunTestResult result = new RunTestResult();
			Stopwatch sw = new Stopwatch();

			int repeat = 100;

			//GC
			float GC0before;
			float GC1before;
			float GC2before;


			GC0before = GC.CollectionCount(0);
			GC1before = GC.CollectionCount(1);
			GC2before = GC.CollectionCount(2);

			//Allocated Memory
			long beforeAlloc = GC.GetAllocatedBytesForCurrentThread();

			sw.Restart();
			for (int i = 0; i < repeat; i++)
				testOBJ.RunSequential();
			sw.Stop();

			//Allocated Memory
			long afterAlloc = GC.GetAllocatedBytesForCurrentThread();

			result.Elapsed_Time = sw.Elapsed.TotalMilliseconds;
			result.Allocated_Memory = afterAlloc - beforeAlloc;
			result.GC0 = GC.CollectionCount(0) - GC0before;
			result.GC1 = GC.CollectionCount(1) - GC1before;
			result.GC2 = GC.CollectionCount(2) - GC2before;
			//평균 처리 시간
			// 작을수록 좋음
			// CPU효율
			// 단위 us
			result.AVG_Process_Time = (result.Elapsed_Time * 1000.0) / (objCount * repeat);
			//처리량
			// 클수록 좋음
			// 전체 처리 능력
			// 단위 us
			result.SecForProcess_Time = (objCount * repeat) / (result.Elapsed_Time / 1000.0);

			return result;
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
