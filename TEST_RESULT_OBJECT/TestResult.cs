using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_OOP_CompareTEST
{
	// 한번의 생성 테스트 결과
	internal class InitTestResult
	{
		// 1. 총 소요 시간 Elapsed Time
		public double Elapsed_Time;
		// 2. 메모리 할당량 Allocated Memory
		public long Allocated_Memory;
		// 3. GC 발생 정보
		public float GC0;
		public float GC1;
		public float GC2;
		// 4. 엔티티 생성 수 대비 성능
		public double TimeToEntityCreate;
		public double MemoryToEntityCreate;

	}
	// 생성 테스트 결과들의 평균값
	internal class InitTestAVGResult
	{
		// 1. 총 소요 시간 Elapsed Time
		public double Elapsed_Time;
		// 2. 메모리 할당량 Allocated Memory
		public long Allocated_Memory;
		// 3. GC 발생 정보
		public float GC0;
		public float GC1;
		public float GC2;
		// 4. 엔티티 생성 수 대비 성능
		public double TimeToEntityCreate;
		public double MemoryToEntityCreate;

		public InitTestAVGResult() { }

		public void AVGCaculatorForResult(InitTestResult[] results)
		{
			for (int i = 0; i < results.Length; i++)
			{
				this.Elapsed_Time += results[i].Elapsed_Time;
				this.Allocated_Memory += results[i].Allocated_Memory;
				this.GC0 += results[i].GC0;
				this.GC1 += results[i].GC1;
				this.GC2 += results[i].GC2;
				this.TimeToEntityCreate += results[i].TimeToEntityCreate;
				this.MemoryToEntityCreate += results[i].MemoryToEntityCreate;
			}
			this.Elapsed_Time = this.Elapsed_Time / results.Length;
			this.Allocated_Memory = this.Allocated_Memory / results.Length;
			this.GC0 /= results.Length;
			this.GC1 /= results.Length;
			this.GC2 /= results.Length;
			this.TimeToEntityCreate /= results.Length;
			this.MemoryToEntityCreate /= results.Length;
		}
	}

	internal class RunTestResult
	{
		// 1. 총 실행 시간
		public double Elapsed_Time;
		// 2. 평균 처리 시간 per iteration
		public double AVG_Process_Time;
		// 3. GC 발생 정보
		public float GC0;
		public float GC1;
		public float GC2;
		// 4. 메모리 할당량 Allocated Memory
		public long Allocated_Memory;
		// 5. 처리량 Throughput
		public double SecForProcess_Time;
	}

	internal class RunTestAVGResult
	{
		public double Elapsed_Time;
		// 2. 평균 처리 시간 per iteration
		public double AVG_Process_Time;
		// 3. GC 발생 정보
		public float GC0;
		public float GC1;
		public float GC2;
		// 4. 메모리 할당량 Allocated Memory
		public long Allocated_Memory;
		// 5. 처리량 Throughput
		public double SecForProcess_Time;

		public RunTestAVGResult() { }

		public void AVGCaculatorForResult(RunTestResult[] results)
		{
			for (int i = 0; i < results.Length; i++)
			{
				this.Elapsed_Time += results[i].Elapsed_Time;
				this.AVG_Process_Time += results[i].AVG_Process_Time;
				this.GC0 += results[i].GC0;
				this.GC1 += results[i].GC1;
				this.GC2 += results[i].GC2;
				this.Allocated_Memory += results[i].Allocated_Memory;
				this.SecForProcess_Time += results[i].SecForProcess_Time;
			}
			this.Elapsed_Time = this.Elapsed_Time / results.Length;
			this.AVG_Process_Time = this.AVG_Process_Time / results.Length;
			this.GC0 /= results.Length;
			this.GC1 /= results.Length;
			this.GC2 /= results.Length;
			this.Allocated_Memory /= results.Length;
			this.SecForProcess_Time /= results.Length;

		}
	}
}
