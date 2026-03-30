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
	public enum Testcase
	{ 
		SEQUENTIAL,
		CONDITIONAL,
		RANDOM,
		MULTICOMPONENT,
		CACULATION
	}



	internal class MainTest
	{
		public static void Main()
		{
			const int Objectcount = 100000;
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

			// AVG for ECS
			// 반복테스트의 평균값 저장 - Init
			InitTestAVGResult ECS_Sequential_Init_AVG = new InitTestAVGResult();
			InitTestAVGResult ECS_Conditional_Init_AVG = new InitTestAVGResult();
			InitTestAVGResult ECS_Random_Init_AVG = new InitTestAVGResult();
			InitTestAVGResult ECS_MultiComponent_Init_AVG = new InitTestAVGResult();
			InitTestAVGResult ECS_Calculation_Init_AVG = new InitTestAVGResult();
			// 반복테스트의 평균값 저장 - Run
			RunTestAVGResult ECS_Sequential_Run_AVG = new RunTestAVGResult();
			RunTestAVGResult ECS_Conditional_Run_AVG = new RunTestAVGResult();
			RunTestAVGResult ECS_Random_Run_AVG = new RunTestAVGResult();
			RunTestAVGResult ECS_MultiComponent_Run_AVG = new RunTestAVGResult();
			RunTestAVGResult ECS_Calculation_Run_AVG = new RunTestAVGResult();
			// AVG for OOP
			InitTestAVGResult OOP_Sequential_Init_AVG = new InitTestAVGResult();
			InitTestAVGResult OOP_Conditional_Init_AVG = new InitTestAVGResult();
			InitTestAVGResult OOP_Random_Init_AVG = new InitTestAVGResult();
			InitTestAVGResult OOP_MultiComponent_Init_AVG = new InitTestAVGResult();
			InitTestAVGResult OOP_Calculation_Init_AVG = new InitTestAVGResult();
			// 반복테스트의 평균값 저장 - Run
			RunTestAVGResult OOP_Sequential_Run_AVG = new RunTestAVGResult();
			RunTestAVGResult OOP_Conditional_Run_AVG = new RunTestAVGResult();
			RunTestAVGResult OOP_Random_Run_AVG = new RunTestAVGResult();
			RunTestAVGResult OOP_MultiComponent_Run_AVG = new RunTestAVGResult();
			RunTestAVGResult OOP_Calculation_Run_AVG = new RunTestAVGResult();

			// ECS
			#region ECSTEST
			// 테스트를 위한 임시 초기화
			for (int i = 0; i < RepeatCount ; i++)
			{
				Sequential_Init[i] = new();
				Conditional_Init[i] = new();
				Random_Init[i] = new();
				MultiComponent_Init[i] = new();
				Calculation_Init[i] = new();

				Sequential_Run[i] = new();
				Conditional_Run[i] = new();
				Random_Run[i] = new();
				MultiComponent_Run[i] = new();
				Calculation_Run[i] = new();
			}
			ECS_Sequential_Init_AVG = new();
			ECS_Conditional_Init_AVG = new();
			ECS_Random_Init_AVG = new();
			ECS_MultiComponent_Init_AVG = new();
			ECS_Calculation_Init_AVG = new();

			ECS_Sequential_Run_AVG = new();
			ECS_Conditional_Run_AVG = new();
			ECS_Random_Run_AVG = new();
			ECS_MultiComponent_Run_AVG = new();
			ECS_Calculation_Run_AVG = new();

			RepeatTest_Cycle(typeof(ECS_Main),
								Objectcount,
								RepeatCount,
								warmup,
								obj => InitTest((ECS_Main)obj , Testcase.SEQUENTIAL , Objectcount),
								obj => SequentialTest((ECS_Main)obj, Objectcount),
								out InitTestResult[] ECS_init_SequentialResults,
								out RunTestResult[] ECS_run_SequentialResults);
			Sequential_Init = ECS_init_SequentialResults;
			Sequential_Run = ECS_run_SequentialResults;
			ECS_Sequential_Init_AVG.AVGCaculatorForResult(Sequential_Init);
			ECS_Sequential_Run_AVG.AVGCaculatorForResult(Sequential_Run);



			ECS_ResultView(RepeatCount, Sequential_Init, Conditional_Init, Random_Init, MultiComponent_Init , Calculation_Init,
										Sequential_Run , Conditional_Run , Random_Run , MultiComponent_Run , Calculation_Run);

			



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
			// 테스트를 위한 임시 초기화
			for (int i = 0; i < RepeatCount; i++)
			{
				Sequential_Init[i] = new();
				Conditional_Init[i] = new();
				Random_Init[i] = new();
				MultiComponent_Init[i] = new();
				Calculation_Init[i] = new();

				Sequential_Run[i] = new();
				Conditional_Run[i] = new();
				Random_Run[i] = new();
				MultiComponent_Run[i] = new();
				Calculation_Run[i] = new();
			}
			OOP_Sequential_Init_AVG = new();
			OOP_Conditional_Init_AVG = new();
			OOP_Random_Init_AVG = new();
			OOP_MultiComponent_Init_AVG = new();
			OOP_Calculation_Init_AVG = new();
		
			OOP_Sequential_Run_AVG = new();
			OOP_Conditional_Run_AVG = new();
			OOP_Random_Run_AVG = new();
			OOP_MultiComponent_Run_AVG = new();
			OOP_Calculation_Run_AVG = new();
			//SequentialTest
			RepeatTest_Cycle(typeof(OOP_Main),
								Objectcount,
								RepeatCount,
								warmup,
								obj => InitTest((OOP_Main)obj ,Testcase.SEQUENTIAL , Objectcount),
								obj => SequentialTest((OOP_Main)obj, Objectcount),
								out InitTestResult[] OOP_init_SequentialResults,
								out RunTestResult[] OOP_run_SequentialResults);
			Sequential_Init = OOP_init_SequentialResults;
			Sequential_Run = OOP_run_SequentialResults;
			OOP_Sequential_Init_AVG.AVGCaculatorForResult(Sequential_Init);
			OOP_Sequential_Run_AVG.AVGCaculatorForResult(Sequential_Run);
			//ConditionalTest
			RepeatTest_Cycle(typeof(OOP_Main),
								Objectcount,
								RepeatCount,
								warmup,
								obj => InitTest((OOP_Main)obj,Testcase.CONDITIONAL , Objectcount),
								obj => ConditionalTest((OOP_Main)obj, Objectcount),
								out InitTestResult[] OOP_init_ConditionalResults,
								out RunTestResult[] OOP_run_ConditionalResults);
			Conditional_Init = OOP_init_ConditionalResults;
			Conditional_Run = OOP_run_ConditionalResults;
			OOP_Conditional_Init_AVG.AVGCaculatorForResult(Conditional_Init);
			OOP_Conditional_Run_AVG.AVGCaculatorForResult(Conditional_Run);
			//RandomTest
			RepeatTest_Cycle(typeof(OOP_Main),
								Objectcount,
								RepeatCount,
								warmup,
								obj => InitTest((OOP_Main)obj, Testcase.RANDOM, Objectcount),
								obj => RandomTest((OOP_Main)obj, Objectcount),
								out InitTestResult[] OOP_init_RandomResults,
								out RunTestResult[] OOP_run_RandomResults);
			Random_Init = OOP_init_RandomResults;
			Random_Run = OOP_run_RandomResults;
			OOP_Random_Init_AVG.AVGCaculatorForResult(Random_Init);
			OOP_Random_Run_AVG.AVGCaculatorForResult(Random_Run);
			//MultiComponentTest
			RepeatTest_Cycle(typeof(OOP_Main),
								Objectcount,
								RepeatCount,
								warmup,
								obj => InitTest((OOP_Main)obj, Testcase.MULTICOMPONENT,  Objectcount),
								obj => MultiComponentTest((OOP_Main)obj, Objectcount),
								out InitTestResult[] OOP_init_MultiComponentResults,
								out RunTestResult[] OOP_run_MultiComponentResults);
			MultiComponent_Init = OOP_init_MultiComponentResults;
			MultiComponent_Run = OOP_run_MultiComponentResults;
			OOP_MultiComponent_Init_AVG.AVGCaculatorForResult(MultiComponent_Init);
			OOP_MultiComponent_Run_AVG.AVGCaculatorForResult(MultiComponent_Run);
			//CaculationTest
			RepeatTest_Cycle(typeof(OOP_Main),
								Objectcount,
								RepeatCount,
								warmup,
								obj => InitTest((OOP_Main)obj,Testcase.CACULATION, Objectcount),
								obj => CalculationTest((OOP_Main)obj, Objectcount),
								out InitTestResult[] OOP_init_CalculationResults,
								out RunTestResult[] OOP_run_CalculationResults);
			Calculation_Init = OOP_init_CalculationResults;
			Calculation_Run = OOP_run_CalculationResults;
			OOP_Calculation_Init_AVG.AVGCaculatorForResult(Calculation_Init);
			OOP_Calculation_Run_AVG.AVGCaculatorForResult(Calculation_Run);


			OOP_ResultView(RepeatCount, Sequential_Init, Conditional_Init, Random_Init, MultiComponent_Init, Calculation_Init,
										Sequential_Run, Conditional_Run, Random_Run, MultiComponent_Run, Calculation_Run);

			#endregion
			ECS_ResultAVGView(ECS_Sequential_Init_AVG, ECS_Conditional_Init_AVG, ECS_Random_Init_AVG, ECS_MultiComponent_Init_AVG, ECS_Calculation_Init_AVG,
							  ECS_Sequential_Run_AVG, ECS_Conditional_Run_AVG, ECS_Random_Run_AVG, ECS_MultiComponent_Run_AVG, ECS_Calculation_Run_AVG);


			OOP_ResultAVGView(OOP_Sequential_Init_AVG, OOP_Conditional_Init_AVG, OOP_Random_Init_AVG, OOP_MultiComponent_Init_AVG, OOP_Calculation_Init_AVG,
							  OOP_Sequential_Run_AVG, OOP_Conditional_Run_AVG, OOP_Random_Run_AVG, OOP_MultiComponent_Run_AVG, OOP_Calculation_Run_AVG);

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

		public static void ECS_ResultView(int repeatCount,	InitTestResult[] init_Sequential, InitTestResult[] init_Conditional, InitTestResult[] init_Random, InitTestResult[] init_MultiComponent, InitTestResult[] init_Caculation,
															RunTestResult[] run_Sequential , RunTestResult[] run_Conditional, RunTestResult[] run_Random, RunTestResult[] run_MultiComponent, RunTestResult[] run_Caculation)
		{
			for (int i = 0; i < repeatCount; i++)
			{
				Console.WriteLine($"=====================ECSTest_Init {i + 1}===================================");
				Console.WriteLine($" Sequential	: {init_Sequential[i].Elapsed_Time:F2}ms | Allocated_Memory : {init_Sequential[i].Allocated_Memory:F2} | TimeToEntityCreate : {init_Sequential[i].TimeToEntityCreate:F2}  | MemoryToEntityCreate : {init_Sequential[i].MemoryToEntityCreate:F2} | GC0 : {init_Sequential[i].GC0:F1} , GC1 : {init_Sequential[i].GC1:F1} , GC2 : {init_Sequential[i].GC2:F1}");
				Console.WriteLine($" Conditonal	: {init_Conditional[i].Elapsed_Time:F2}ms | Allocated_Memory : {init_Conditional[i].Allocated_Memory:F2} | TimeToEntityCreate : {init_Conditional[i].TimeToEntityCreate:F2}  | MemoryToEntityCreate : {init_Conditional[i].MemoryToEntityCreate:F2} | GC0 : {init_Conditional[i].GC0:F1} , GC1 : {init_Conditional[i].GC1:F1} , GC2 : {init_Conditional[i].GC2:F1}");
				Console.WriteLine($" Random		: {init_Random[i].Elapsed_Time:F2}ms | Allocated_Memory : {init_Random[i].Allocated_Memory:F2} | TimeToEntityCreate : {init_Random[i].TimeToEntityCreate:F2}  | MemoryToEntityCreate : {init_Random[i].MemoryToEntityCreate:F2} | GC0 : {init_Random[i].GC0:F1} , GC1 : {init_Random[i].GC1:F1} , GC2 : {init_Random[i].GC2:F1}");
				Console.WriteLine($" MultiComponent	: {init_MultiComponent[i].Elapsed_Time:F2}ms | Allocated_Memory : {init_MultiComponent[i].Allocated_Memory:F2} | TimeToEntityCreate : {init_MultiComponent[i].TimeToEntityCreate:F2}  | MemoryToEntityCreate : {init_MultiComponent[i].MemoryToEntityCreate:F2} | GC0 : {init_MultiComponent[i].GC0:F1} , GC1 : {init_MultiComponent[i].GC1:F1} , GC2 : {init_MultiComponent[i].GC2:F1}");
				Console.WriteLine($" Caculation	: {init_Caculation[i].Elapsed_Time:F2}ms | Allocated_Memory : {init_Caculation[i].Allocated_Memory:F2} | TimeToEntityCreate : {init_Caculation[i].TimeToEntityCreate:F2}  | MemoryToEntityCreate : {init_Caculation[i].MemoryToEntityCreate:F2} | GC0 : {init_Caculation[i].GC0:F1} , GC1 : {init_Caculation[i].GC1:F1} , GC2 : {init_Caculation[i].GC2:F1}");
				Console.WriteLine($"=====================ECSTest_Run {i + 1}===================================");
				Console.WriteLine($" Sequential	: {run_Sequential[i].Elapsed_Time:F2}ms | Allocated_Memory : {run_Sequential[i].Allocated_Memory:F2} | AVG_Process_Time : {run_Sequential[i].AVG_Process_Time:F2}  | SecForProcess_Time : {run_Sequential[i].SecForProcess_Time:F2}  | GC0 :  {run_Sequential[i].GC0:F1} , GC1 : {run_Sequential[i].GC1:F1} , GC2 : {run_Sequential[i].GC2:F1}");
				Console.WriteLine($" Conditonal	: {run_Conditional[i].Elapsed_Time:F2}ms | Allocated_Memory : {run_Conditional[i].Allocated_Memory:F2} | AVG_Process_Time : {run_Conditional[i].AVG_Process_Time:F2}  | SecForProcess_Time : {run_Conditional[i].SecForProcess_Time:F2} | GC0 : {run_Conditional[i].GC0:F1} , GC1 : {run_Conditional[i].GC1:F1} , GC2 : {run_Conditional[i].GC2:F1}");
				Console.WriteLine($" Random		: {run_Random[i].Elapsed_Time:F2}ms | Allocated_Memory : {run_Random[i].Allocated_Memory:F2} | AVG_Process_Time : {run_Random[i].AVG_Process_Time:F2}  | SecForProcess_Time : {run_Random[i].SecForProcess_Time:F2} | GC0 : {run_Random[i].GC0:F1} , GC1 : {run_Random[i].GC1:F1} , GC2 : {run_Random[i].GC2:F1}");
				Console.WriteLine($" MultiComponent	: {run_MultiComponent[i].Elapsed_Time:F2}ms | Allocated_Memory : {run_MultiComponent[i].Allocated_Memory:F2} | AVG_Process_Time : {run_MultiComponent[i].AVG_Process_Time:F2}  | SecForProcess_Time : {run_MultiComponent[i].SecForProcess_Time:F2} | GC0 : {run_MultiComponent[i].GC0:F1} , GC1 : {run_MultiComponent[i].GC1:F1} , GC2 : {run_MultiComponent[i].GC2:F1}");
				Console.WriteLine($" Caculation	: {run_Caculation[i].Elapsed_Time:F2}ms | Allocated_Memory : {run_Caculation[i].Allocated_Memory:F2} | AVG_Process_Time : {run_Caculation[i].AVG_Process_Time:F2}  | SecForProcess_Time : {run_Caculation[i].SecForProcess_Time:F2} | GC0 : {run_Caculation[i].GC0:F1} , GC1 : {run_Caculation[i].GC1:F1} , GC2 : {run_Caculation[i].GC2:F1}");
				Console.WriteLine("\n");
			}
		}
		public static void ECS_ResultAVGView(	InitTestAVGResult init_Sequential, InitTestAVGResult init_Conditional, InitTestAVGResult init_Random, InitTestAVGResult init_MultiComponent, InitTestAVGResult init_Caculation,
												RunTestAVGResult run_Sequential, RunTestAVGResult run_Conditional, RunTestAVGResult run_Random, RunTestAVGResult run_MultiComponent, RunTestAVGResult run_Caculation)
		{
			Console.WriteLine($"=====================ECSTest_Init_AVG ===================================");
			Console.WriteLine($" Sequential	: {init_Sequential.Elapsed_Time:F2}ms | Allocated_Memory : {init_Sequential.Allocated_Memory:F2} | TimeToEntityCreate : {init_Sequential.TimeToEntityCreate:F2}  | MemoryToEntityCreate : {init_Sequential.MemoryToEntityCreate:F2} | GC0 : {init_Sequential.GC0:F1} , GC1 : {init_Sequential.GC1:F1} , GC2 : {init_Sequential.GC2:F1}");
			Console.WriteLine($" Conditonal	: {init_Conditional.Elapsed_Time:F2}ms | Allocated_Memory : {init_Conditional.Allocated_Memory:F2} | TimeToEntityCreate : {init_Conditional.TimeToEntityCreate:F2}  | MemoryToEntityCreate : {init_Conditional.MemoryToEntityCreate:F2} | GC0 : {init_Conditional.GC0:F1} , GC1 : {init_Conditional.GC1:F1} , GC2 : {init_Conditional.GC2:F1}");
			Console.WriteLine($" Random		: {init_Random.Elapsed_Time:F2}ms | Allocated_Memory : {init_Random.Allocated_Memory:F2} | TimeToEntityCreate : {init_Random.TimeToEntityCreate:F2}  | MemoryToEntityCreate : {init_Random.MemoryToEntityCreate:F2} | GC0 : {init_Random.GC0:F1} , GC1 : {init_Random.GC1:F1} , GC2 : {init_Random.GC2:F1}");
			Console.WriteLine($" MultiComponent	: {init_MultiComponent.Elapsed_Time:F2}ms | Allocated_Memory : {init_MultiComponent.Allocated_Memory:F2} | TimeToEntityCreate : {init_MultiComponent.TimeToEntityCreate:F2}  | MemoryToEntityCreate : {init_MultiComponent.MemoryToEntityCreate:F2} | GC0 : {init_MultiComponent.GC0:F1} , GC1 : {init_MultiComponent.GC1:F1} , GC2 : {init_MultiComponent.GC2:F1}");
			Console.WriteLine($" Caculation	: {init_Caculation.Elapsed_Time:F2}ms | Allocated_Memory : {init_Caculation.Allocated_Memory:F2} | TimeToEntityCreate : {init_Caculation.TimeToEntityCreate:F2}  | MemoryToEntityCreate : {init_Caculation.MemoryToEntityCreate:F2} | GC0 : {init_Caculation.GC0:F1} , GC1 : {init_Caculation.GC1:F1} , GC2 : {init_Caculation.GC2:F1}");
			Console.WriteLine($"=====================ECSTest_Run_AVG===================================");
			Console.WriteLine($" Sequential	: {run_Sequential.Elapsed_Time:F2}ms | Allocated_Memory : {run_Sequential.Allocated_Memory:F2} | AVG_Process_Time : {run_Sequential.AVG_Process_Time:F2}  | SecForProcess_Time : {run_Sequential.SecForProcess_Time:F2} | GC0 : {run_Sequential.GC0:F1} , GC1 : {run_Sequential.GC1:F1} , GC2 : {run_Sequential.GC2:F1}");
			Console.WriteLine($" Conditonal	: {run_Conditional.Elapsed_Time:F2}ms | Allocated_Memory : {run_Conditional.Allocated_Memory:F2} | AVG_Process_Time : {run_Conditional.AVG_Process_Time:F2}  | SecForProcess_Time : {run_Conditional.SecForProcess_Time:F2} | GC0 : {run_Conditional.GC0:F1} , GC1 : {run_Conditional.GC1:F1} , GC2 : {run_Conditional.GC2:F1}");
			Console.WriteLine($" Random		: {run_Random.Elapsed_Time:F2}ms | Allocated_Memory : {run_Random.Allocated_Memory:F2} | AVG_Process_Time : {run_Random.AVG_Process_Time:F2}  | SecForProcess_Time : {run_Random.SecForProcess_Time:F2} | GC0 : {run_Random.GC0:F1} , GC1 : {run_Random.GC1:F1} , GC2 : {run_Random.GC2:F1}");
			Console.WriteLine($" MultiComponent	: {run_MultiComponent.Elapsed_Time:F2}ms | Allocated_Memory : {run_MultiComponent.Allocated_Memory:F2} | AVG_Process_Time : {run_MultiComponent.AVG_Process_Time:F2}  | SecForProcess_Time : {run_MultiComponent.SecForProcess_Time:F2} | GC0 : {run_MultiComponent.GC0:F1} , GC1 : {run_MultiComponent.GC1:F1} , GC2 : {run_MultiComponent.GC2:F1}");
			Console.WriteLine($" Caculation	: {run_Caculation.Elapsed_Time:F2}ms | Allocated_Memory : {run_Caculation.Allocated_Memory:F2} | AVG_Process_Time : {run_Caculation.AVG_Process_Time:F2}  | SecForProcess_Time : {run_Caculation.SecForProcess_Time:F2} | GC0 : {run_Caculation.GC0:F1} , GC1 : {run_Caculation.GC1:F1} , GC2 : {run_Caculation.GC2:F1}");
			Console.WriteLine($"========================================================================================================================================================================================================================================================================================================================================================================================================");
			Console.WriteLine("\n");
		}
		public static void OOP_ResultView(int repeatCount, InitTestResult[] init_Sequential, InitTestResult[] init_Conditional, InitTestResult[] init_Random, InitTestResult[] init_MultiComponent, InitTestResult[] init_Caculation,
															RunTestResult[] run_Sequential, RunTestResult[] run_Conditional, RunTestResult[] run_Random, RunTestResult[] run_MultiComponent, RunTestResult[] run_Caculation)
		{
			for (int i = 0; i < repeatCount; i++)
			{
				Console.WriteLine($"=====================OOPTest_Init {i + 1}===================================");
				Console.WriteLine($" Sequential	: {init_Sequential[i].Elapsed_Time:F2}ms | Allocated_Memory : {init_Sequential[i].Allocated_Memory:F2} | TimeToEntityCreate : {init_Sequential[i].TimeToEntityCreate:F2}  | MemoryToEntityCreate : {init_Sequential[i].MemoryToEntityCreate:F2} | GC0 : {init_Sequential[i].GC0:F1} , GC1 : {init_Sequential[i].GC1:F1} , GC2 : {init_Sequential[i].GC2:F1}");
				Console.WriteLine($" Conditonal	: {init_Conditional[i].Elapsed_Time:F2}ms | Allocated_Memory : {init_Conditional[i].Allocated_Memory:F2} | TimeToEntityCreate : {init_Conditional[i].TimeToEntityCreate:F2}  | MemoryToEntityCreate : {init_Conditional[i].MemoryToEntityCreate:F2} | GC0 : {init_Conditional[i].GC0:F1} , GC1 : {init_Conditional[i].GC1:F1} , GC2 : {init_Conditional[i].GC2:F1}");
				Console.WriteLine($" Random		: {init_Random[i].Elapsed_Time:F2}ms | Allocated_Memory : {init_Random[i].Allocated_Memory:F2} | TimeToEntityCreate : {init_Random[i].TimeToEntityCreate:F2}  | MemoryToEntityCreate : {init_Random[i].MemoryToEntityCreate:F2} | GC0 : {init_Random[i].GC0:F1} , GC1 : {init_Random[i].GC1:F1} , GC2 : {init_Random[i].GC2:F1}");
				Console.WriteLine($" MultiComponent	: {init_MultiComponent[i].Elapsed_Time:F2}ms | Allocated_Memory : {init_MultiComponent[i].Allocated_Memory:F2} | TimeToEntityCreate : {init_MultiComponent[i].TimeToEntityCreate:F2}  | MemoryToEntityCreate : {init_MultiComponent[i].MemoryToEntityCreate:F2} | GC0 : {init_MultiComponent[i].GC0:F1} , GC1 : {init_MultiComponent[i].GC1:F1} , GC2 : {init_MultiComponent[i].GC2:F1}");
				Console.WriteLine($" Caculation	: {init_Caculation[i].Elapsed_Time:F2}ms | Allocated_Memory : {init_Caculation[i].Allocated_Memory:F2} | TimeToEntityCreate : {init_Caculation[i].TimeToEntityCreate:F2}  | MemoryToEntityCreate : {init_Caculation[i].MemoryToEntityCreate:F2} | GC0 : {init_Caculation[i].GC0:F1} , GC1 : {init_Caculation[i].GC1:F1} , GC2 : {init_Caculation[i].GC2:F1}");
				Console.WriteLine($"=====================OOPTest_Run {i + 1}===================================");
				Console.WriteLine($" Sequential	: {run_Sequential[i].Elapsed_Time:F2}ms | Allocated_Memory : {run_Sequential[i].Allocated_Memory:F2} | AVG_Process_Time : {run_Sequential[i].AVG_Process_Time:F2}  | SecForProcess_Time : {run_Sequential[i].SecForProcess_Time:F2}  | GC0 :  {run_Sequential[i].GC0:F1} , GC1 : {run_Sequential[i].GC1:F1} , GC2 : {run_Sequential[i].GC2:F1}");
				Console.WriteLine($" Conditonal	: {run_Conditional[i].Elapsed_Time:F2}ms | Allocated_Memory : {run_Conditional[i].Allocated_Memory:F2} | AVG_Process_Time : {run_Conditional[i].AVG_Process_Time:F2}  | SecForProcess_Time : {run_Conditional[i].SecForProcess_Time:F2} | GC0 : {run_Conditional[i].GC0:F1} , GC1 : {run_Conditional[i].GC1:F1} , GC2 : {run_Conditional[i].GC2:F1}");
				Console.WriteLine($" Random		: {run_Random[i].Elapsed_Time:F2}ms | Allocated_Memory : {run_Random[i].Allocated_Memory:F2} | AVG_Process_Time : {run_Random[i].AVG_Process_Time:F2}  | SecForProcess_Time : {run_Random[i].SecForProcess_Time:F2} | GC0 : {run_Random[i].GC0:F1} , GC1 : {run_Random[i].GC1:F1} , GC2 : {run_Random[i].GC2:F1}");
				Console.WriteLine($" MultiComponent	: {run_MultiComponent[i].Elapsed_Time:F2}ms | Allocated_Memory : {run_MultiComponent[i].Allocated_Memory:F2} | AVG_Process_Time : {run_MultiComponent[i].AVG_Process_Time:F2}  | SecForProcess_Time : {run_MultiComponent[i].SecForProcess_Time:F2} | GC0 : {run_MultiComponent[i].GC0:F1} , GC1 : {run_MultiComponent[i].GC1:F1} , GC2 : {run_MultiComponent[i].GC2:F1}");
				Console.WriteLine($" Caculation	: {run_Caculation[i].Elapsed_Time:F2}ms | Allocated_Memory : {run_Caculation[i].Allocated_Memory:F2} | AVG_Process_Time : {run_Caculation[i].AVG_Process_Time:F2}  | SecForProcess_Time : {run_Caculation[i].SecForProcess_Time:F2} | GC0 : {run_Caculation[i].GC0:F1} , GC1 : {run_Caculation[i].GC1:F1} , GC2 : {run_Caculation[i].GC2:F1}");
				Console.WriteLine("\n");
			}
		}
		public static void OOP_ResultAVGView(InitTestAVGResult init_Sequential, InitTestAVGResult init_Conditional, InitTestAVGResult init_Random, InitTestAVGResult init_MultiComponent, InitTestAVGResult init_Caculation,
												RunTestAVGResult run_Sequential, RunTestAVGResult run_Conditional, RunTestAVGResult run_Random, RunTestAVGResult run_MultiComponent, RunTestAVGResult run_Caculation)
		{
			Console.WriteLine($"=====================OOPTest_Init_AVG ===================================");
			Console.WriteLine($" Sequential	: {init_Sequential.Elapsed_Time:F2}ms | Allocated_Memory : {init_Sequential.Allocated_Memory:F2} | TimeToEntityCreate : {init_Sequential.TimeToEntityCreate:F2}  | MemoryToEntityCreate : {init_Sequential.MemoryToEntityCreate:F2} | GC0 : {init_Sequential.GC0:F1} , GC1 : {init_Sequential.GC1:F1} , GC2 : {init_Sequential.GC2:F1}");
			Console.WriteLine($" Conditonal	: {init_Conditional.Elapsed_Time:F2}ms | Allocated_Memory : {init_Conditional.Allocated_Memory:F2} | TimeToEntityCreate : {init_Conditional.TimeToEntityCreate:F2}  | MemoryToEntityCreate : {init_Conditional.MemoryToEntityCreate:F2} | GC0 : {init_Conditional.GC0:F1} , GC1 : {init_Conditional.GC1:F1} , GC2 : {init_Conditional.GC2:F1}");
			Console.WriteLine($" Random		: {init_Random.Elapsed_Time:F2}ms | Allocated_Memory : {init_Random.Allocated_Memory:F2} | TimeToEntityCreate : {init_Random.TimeToEntityCreate:F2}  | MemoryToEntityCreate : {init_Random.MemoryToEntityCreate:F2} | GC0 : {init_Random.GC0:F1} , GC1 : {init_Random.GC1:F1} , GC2 : {init_Random.GC2:F1}");
			Console.WriteLine($" MultiComponent	: {init_MultiComponent.Elapsed_Time:F2}ms | Allocated_Memory : {init_MultiComponent.Allocated_Memory:F2} | TimeToEntityCreate : {init_MultiComponent.TimeToEntityCreate:F2}  | MemoryToEntityCreate : {init_MultiComponent.MemoryToEntityCreate:F2} | GC0 : {init_MultiComponent.GC0:F1} , GC1 : {init_MultiComponent.GC1:F1} , GC2 : {init_MultiComponent.GC2:F1}");
			Console.WriteLine($" Caculation	: {init_Caculation.Elapsed_Time:F2}ms | Allocated_Memory : {init_Caculation.Allocated_Memory:F2} | TimeToEntityCreate : {init_Caculation.TimeToEntityCreate:F2}  | MemoryToEntityCreate : {init_Caculation.MemoryToEntityCreate:F2} | GC0 : {init_Caculation.GC0:F1} , GC1 : {init_Caculation.GC1:F1} , GC2 : {init_Caculation.GC2:F1}");
			Console.WriteLine($"=====================OOPTest_Run_AVG===================================");
			Console.WriteLine($" Sequential	: {run_Sequential.Elapsed_Time:F2}ms | Allocated_Memory : {run_Sequential.Allocated_Memory:F2} | AVG_Process_Time : {run_Sequential.AVG_Process_Time:F2}  | SecForProcess_Time : {run_Sequential.SecForProcess_Time:F2} | GC0 : {run_Sequential.GC0:F1} , GC1 : {run_Sequential.GC1:F1} , GC2 : {run_Sequential.GC2:F1}");
			Console.WriteLine($" Conditonal	: {run_Conditional.Elapsed_Time:F2}ms | Allocated_Memory : {run_Conditional.Allocated_Memory:F2} | AVG_Process_Time : {run_Conditional.AVG_Process_Time:F2}  | SecForProcess_Time : {run_Conditional.SecForProcess_Time:F2} | GC0 : {run_Conditional.GC0:F1} , GC1 : {run_Conditional.GC1:F1} , GC2 : {run_Conditional.GC2:F1}");
			Console.WriteLine($" Random		: {run_Random.Elapsed_Time:F2}ms | Allocated_Memory : {run_Random.Allocated_Memory:F2} | AVG_Process_Time : {run_Random.AVG_Process_Time:F2}  | SecForProcess_Time : {run_Random.SecForProcess_Time:F2} | GC0 : {run_Random.GC0:F1} , GC1 : {run_Random.GC1:F1} , GC2 : {run_Random.GC2:F1}");
			Console.WriteLine($" MultiComponent	: {run_MultiComponent.Elapsed_Time:F2}ms | Allocated_Memory : {run_MultiComponent.Allocated_Memory:F2} | AVG_Process_Time : {run_MultiComponent.AVG_Process_Time:F2}  | SecForProcess_Time : {run_MultiComponent.SecForProcess_Time:F2} | GC0 : {run_MultiComponent.GC0:F1} , GC1 : {run_MultiComponent.GC1:F1} , GC2 : {run_MultiComponent.GC2:F1}");
			Console.WriteLine($" Caculation	: {run_Caculation.Elapsed_Time:F2}ms | Allocated_Memory : {run_Caculation.Allocated_Memory:F2} | AVG_Process_Time : {run_Caculation.AVG_Process_Time:F2}  | SecForProcess_Time : {run_Caculation.SecForProcess_Time:F2} | GC0 : {run_Caculation.GC0:F1} , GC1 : {run_Caculation.GC1:F1} , GC2 : {run_Caculation.GC2:F1}");
			Console.WriteLine($"========================================================================================================================================================================================================================================================================================================================================================================================================");
			Console.WriteLine("\n");
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
		public static InitTestResult InitTest(ITest testOBJ, Testcase test ,int objCount)
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
			testOBJ.Init(objCount,test);
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

		public static RunTestResult SequentialTest(ITest testOBJ, int objCount)
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
		public static RunTestResult ConditionalTest(ITest testOBJ, int objCount)
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
				testOBJ.RunConditional();
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
		public static RunTestResult RandomTest(ITest testOBJ, int objCount)
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
				testOBJ.RunRandom();
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
		public static RunTestResult MultiComponentTest(ITest testOBJ, int objCount)
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
				testOBJ.RunMultiComponent();
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
		public static RunTestResult CalculationTest(ITest testOBJ, int objCount)
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
				testOBJ.RunCalculation();
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


		//public static TestResult RunTest(ITest testTarget)
		//{
		//	int Objectcount = 100000;
		//	int MaxRepeat = 10000;
		//	int warmUpRepeat = 10;
		//	//Stopwatch
		//	Stopwatch sw = new Stopwatch();
		//	// Result
		//	TestResult testResult = new TestResult();
		//	//GC
		//	GC.Collect();
		//	float GC0before;
		//	float GC1before;
		//	float GC2before;


		//	//RunSequential
		//	testTarget.Init(Objectcount);
		//	for (int repeat = 0; repeat < warmUpRepeat; repeat++)
		//		testTarget.RunSequential();

		//	GC0before = GC.CollectionCount(0);
		//	GC1before = GC.CollectionCount(1);
		//	GC2before = GC.CollectionCount(2);

		//	sw.Restart();
		//	for (int repeat = 0; repeat < MaxRepeat; repeat++)
		//		testTarget.RunSequential();
		//	sw.Stop();
		//	testResult.Sequential_Time = sw.Elapsed.TotalMilliseconds;
		//	testResult.GC0[0] = GC.CollectionCount(0) - GC0before;
		//	testResult.GC1[0] = GC.CollectionCount(1) - GC1before;
		//	testResult.GC2[0] = GC.CollectionCount(2) - GC2before;


		//	//RunConditional
		//	testTarget.Init(Objectcount);
		//	for (int repeat = 0; repeat < warmUpRepeat; repeat++)
		//		testTarget.RunConditional();

		//	GC0before = GC.CollectionCount(0);
		//	GC1before = GC.CollectionCount(1);
		//	GC2before = GC.CollectionCount(2);
		//	sw.Restart();
		//	for (int repeat = 0; repeat < MaxRepeat; repeat++)
		//		testTarget.RunConditional();
		//	sw.Stop();
		//	testResult.Conditional_Time = sw.Elapsed.TotalMilliseconds;
		//	testResult.GC0[1] = GC.CollectionCount(0) - GC0before;
		//	testResult.GC1[1] = GC.CollectionCount(1) - GC1before;
		//	testResult.GC2[1] = GC.CollectionCount(2) - GC2before;

		//	//RunRandom
		//	testTarget.Init(Objectcount);
		//	for (int repeat = 0; repeat < warmUpRepeat; repeat++)
		//		testTarget.RunRandom();

		//	GC0before = GC.CollectionCount(0);
		//	GC1before = GC.CollectionCount(1);
		//	GC2before = GC.CollectionCount(2);
		//	sw.Restart();
		//	for (int repeat = 0; repeat < MaxRepeat; repeat++)
		//		testTarget.RunRandom();
		//	sw.Stop();
		//	testResult.Random_Time = sw.Elapsed.TotalMilliseconds;
		//	testResult.GC0[2] = GC.CollectionCount(0) - GC0before;
		//	testResult.GC1[2] = GC.CollectionCount(1) - GC1before;
		//	testResult.GC2[2] = GC.CollectionCount(2) - GC2before;

		//	//RunMultiComponent
		//	testTarget.Init(Objectcount);
		//	for (int repeat = 0; repeat < warmUpRepeat; repeat++)
		//		testTarget.RunMultiComponent();

		//	GC0before = GC.CollectionCount(0);
		//	GC1before = GC.CollectionCount(1);
		//	GC2before = GC.CollectionCount(2);
		//	sw.Restart();
		//	for (int repeat = 0; repeat < MaxRepeat; repeat++)
		//		testTarget.RunMultiComponent();
		//	sw.Stop();
		//	testResult.MultiComponent_Time = sw.Elapsed.TotalMilliseconds;
		//	testResult.GC0[3] = GC.CollectionCount(0) - GC0before;
		//	testResult.GC1[3] = GC.CollectionCount(1) - GC1before;
		//	testResult.GC2[3] = GC.CollectionCount(2) - GC2before;

		//	//RunCalculation
		//	testTarget.Init(Objectcount);
		//	for (int repeat = 0; repeat < warmUpRepeat; repeat++)
		//		testTarget.RunCalculation();

		//	GC0before = GC.CollectionCount(0);
		//	GC1before = GC.CollectionCount(1);
		//	GC2before = GC.CollectionCount(2);
		//	sw.Restart();
		//	for (int repeat = 0; repeat < MaxRepeat; repeat++)
		//		testTarget.RunCalculation();
		//	sw.Stop();
		//	testResult.Calculation_Time = sw.Elapsed.TotalMilliseconds;
		//	testResult.GC0[4] = GC.CollectionCount(0) - GC0before;
		//	testResult.GC1[4] = GC.CollectionCount(1) - GC1before;
		//	testResult.GC2[4] = GC.CollectionCount(2) - GC2before;

		//	return testResult;
		//}
































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
