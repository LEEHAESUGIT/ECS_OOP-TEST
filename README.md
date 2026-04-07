# ECS_OOP TEST
ECS Compare to OOP

테스트 방법

순차 접근

조건문

랜덤 접근

멀티 컴포넌트

연산 테스트


2026 - 03 - 20 금
순차접근 테스트 10만개의 객체 성공




2026 - 04 - 07 화
테스트 결과
=====================ECSTest_Init_AVG ===================================
 Sequential     : 60.66ms | Allocated_Memory : 19430686.00 | TimeToEntityCreate : 0.00  | MemoryToEntityCreate : 194.00 | GC0 : 0.9 , GC1 : 0.9 , GC2 : 0.9
 Conditonal     : 59.34ms | Allocated_Memory : 19430698.00 | TimeToEntityCreate : 0.00  | MemoryToEntityCreate : 194.00 | GC0 : 0.9 , GC1 : 0.9 , GC2 : 0.9
 Random         : 53.80ms | Allocated_Memory : 19480989.00 | TimeToEntityCreate : 0.00  | MemoryToEntityCreate : 194.00 | GC0 : 0.9 , GC1 : 0.9 , GC2 : 0.9
 MultiComponent : 54.51ms | Allocated_Memory : 19431777.00 | TimeToEntityCreate : 0.00  | MemoryToEntityCreate : 194.00 | GC0 : 0.9 , GC1 : 0.9 , GC2 : 0.9
 Caculation     : 54.65ms | Allocated_Memory : 19430165.00 | TimeToEntityCreate : 0.00  | MemoryToEntityCreate : 194.00 | GC0 : 0.9 , GC1 : 0.9 , GC2 : 0.9
=====================ECSTest_Run_AVG===================================
 Sequential     : 4.83ms | Allocated_Memory : 8000.00 | AVG_Process_Time : 0.00  | SecForProcess_Time : 2219024441.21 | GC0 : 0.0 , GC1 : 0.0 , GC2 : 0.0
 Conditonal     : 13.88ms | Allocated_Memory : 8000.00 | AVG_Process_Time : 0.00  | SecForProcess_Time : 768448517.21 | GC0 : 0.0 , GC1 : 0.0 , GC2 : 0.0
 Random         : 15.43ms | Allocated_Memory : 8000.00 | AVG_Process_Time : 0.00  | SecForProcess_Time : 649240831.45 | GC0 : 0.0 , GC1 : 0.0 , GC2 : 0.0
 MultiComponent : 8.07ms | Allocated_Memory : 8000.00 | AVG_Process_Time : 0.00  | SecForProcess_Time : 1240664958.43 | GC0 : 0.0 , GC1 : 0.0 , GC2 : 0.0
 Caculation     : 15.19ms | Allocated_Memory : 8000.00 | AVG_Process_Time : 0.00  | SecForProcess_Time : 660307970.54 | GC0 : 0.0 , GC1 : 0.0 , GC2 : 0.0

=====================OOPTest_Init_AVG ===================================
 Sequential     : 3.27ms | Allocated_Memory : 5600024.00 | TimeToEntityCreate : 0.00  | MemoryToEntityCreate : 56.00 | GC0 : 0.0 , GC1 : 0.0 , GC2 : 0.0
 Conditonal     : 3.32ms | Allocated_Memory : 5600024.00 | TimeToEntityCreate : 0.00  | MemoryToEntityCreate : 56.00 | GC0 : 0.0 , GC1 : 0.0 , GC2 : 0.0
 Random         : 4.84ms | Allocated_Memory : 6000048.00 | TimeToEntityCreate : 0.00  | MemoryToEntityCreate : 60.00 | GC0 : 0.0 , GC1 : 0.0 , GC2 : 0.0
 MultiComponent : 3.92ms | Allocated_Memory : 5600024.00 | TimeToEntityCreate : 0.00  | MemoryToEntityCreate : 56.00 | GC0 : 0.0 , GC1 : 0.0 , GC2 : 0.0
 Caculation     : 3.88ms | Allocated_Memory : 5600024.00 | TimeToEntityCreate : 0.00  | MemoryToEntityCreate : 56.00 | GC0 : 0.0 , GC1 : 0.0 , GC2 : 0.0
=====================OOPTest_Run_AVG===================================
 Sequential     : 28.23ms | Allocated_Memory : 0.00 | AVG_Process_Time : 0.00  | SecForProcess_Time : 360386051.37 | GC0 : 0.0 , GC1 : 0.0 , GC2 : 0.0
 Conditonal     : 27.29ms | Allocated_Memory : 0.00 | AVG_Process_Time : 0.00  | SecForProcess_Time : 368456576.75 | GC0 : 0.0 , GC1 : 0.0 , GC2 : 0.0
 Random         : 147.04ms | Allocated_Memory : 0.00 | AVG_Process_Time : 0.01  | SecForProcess_Time : 68027369.59 | GC0 : 0.0 , GC1 : 0.0 , GC2 : 0.0
 MultiComponent : 76.39ms | Allocated_Memory : 0.00 | AVG_Process_Time : 0.01  | SecForProcess_Time : 130999273.94 | GC0 : 0.0 , GC1 : 0.0 , GC2 : 0.0
 Caculation     : 92.67ms | Allocated_Memory : 0.00 | AVG_Process_Time : 0.01  | SecForProcess_Time : 107961581.83 | GC0 : 0.0 , GC1 : 0.0 , GC2 : 0.0