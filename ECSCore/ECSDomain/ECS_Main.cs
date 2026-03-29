using ECSCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_OOP_CompareTEST
{
	internal class ECS_Main : ITest
	{
		float value = 1f;
		int InitCount;

		Random rand = new Random(1000);
		public ECSManager ECSCore = new ECSManager();
		public Entity[] Entitys;

		// TEST Class
		SequentialTestSystem_ECS sequential = new SequentialTestSystem_ECS();
		ConditionalTestSystem_ECS conditional = new ConditionalTestSystem_ECS();
		RandomTestSystem_ECS random = new RandomTestSystem_ECS();
		MultiComponentTestSystem_ECS multiComponent = new MultiComponentTestSystem_ECS();
		CaculationTestSystem_ECS caculation = new CaculationTestSystem_ECS();

		EntityQuery[] query = new EntityQuery[5]; 




		public void Init(int EntityCount , Testcase test)
		{
			InitCount = EntityCount;
			ComponentSetting.SetComponent(typeof(PositionXComponent),
											typeof(PositionYComponent),
											typeof(PositionZComponent),
											typeof(VelocityXComponent),
											typeof(VelocityYComponent),
											typeof(VelocityZComponent),
											typeof(ActiveComponent),
											typeof(DummyComponent));

			Entitys = new Entity[InitCount];

			for (int i = 0; i < InitCount; i++)
			{
				bool active = rand.Next(2) == 1;
				bool hasPos = rand.Next(2) == 1;
				bool hasVel = rand.Next(2) == 1;

				if(active)
				{
					if (hasPos && hasVel)
					{
						Entitys[i] = ECSCore.CreateEntity(typeof(ActiveComponent),
															typeof(PositionXComponent),
															typeof(PositionYComponent),
															typeof(PositionZComponent),
															typeof(VelocityXComponent),
															typeof(VelocityYComponent),
															typeof(VelocityZComponent));
					}
					else if (hasPos) 
					{
						Entitys[i] = ECSCore.CreateEntity(	typeof(ActiveComponent),
															typeof(PositionXComponent),
															typeof(PositionYComponent),
															typeof(PositionZComponent));
					}
					else if (hasVel) 
					{
						Entitys[i] = ECSCore.CreateEntity(typeof(ActiveComponent),
																typeof(VelocityXComponent),
																typeof(VelocityYComponent),
																typeof(VelocityZComponent));
					}
					
					else
					{
						Entitys[i] = ECSCore.CreateEntity(	typeof(ActiveComponent),
															typeof(DummyComponent));					
					}
				}
				else
				{
					Entitys[i] = ECSCore.CreateEntity(typeof(DummyComponent));
				}

				ECSCore.Init(Entitys[i]);

			}
			Query_Filter_1 = ecsMG.Query()
				.WithAll<PositionXComponent, VelocityXComponent>()
				.WithNone<NeedInit>()
				.Build();
			query[0] = ECSCore.Query()
				.WithAll<>()
				.WithNone<>()
				.WithAny<>();
											

			

			
			switch (test)
			{
				case Testcase.SEQUENTIAL:
					sequential.Set(ECSCore);
					break;
				case Testcase.CONDITIONAL:
					conditional.Set(ECSCore);
					break;
				case Testcase.RANDOM:
					random.Set(ECSCore);
					break;
				case Testcase.MULTICOMPONENT:
					multiComponent.Set(ECSCore);
					break;
				case Testcase.CACULATION:
					caculation.Set(ECSCore);
					break;
				default:
					break;

			}
		}

		public void RunSequential() => sequential.OnUpdate(ECSCore);
		public void RunConditional() => conditional.OnUpdate(ECSCore);
		public void RunRandom() => random.OnUpdate(ECSCore);
		public void RunMultiComponent() => multiComponent.OnUpdate(ECSCore);
		public void RunCalculation() => caculation.OnUpdate(ECSCore);
		//public void RunSequential()
		//{
		//	int[] _PosTypeIndex;
		//	int[] _VelTypeIndex;
		//	int archetypeIndex1;
		//	int archetypeIndex2;
		//	EntityQuery Query_Filter_1 = ECSCore.Query()
		//		.WithAll<PositionXComponent,VelocityXComponent>()
		//		.WithNone<NeedInit>()
		//		.Build();
		//	Query_Filter_1.UpdateArchetypes(ECSCore.entityManager);
		//	_PosTypeIndex = new int[Query_Filter_1.archetypes.Count];
		//	_VelTypeIndex = new int[Query_Filter_1.archetypes.Count];
		//	archetypeIndex1 = 0;
		//	archetypeIndex2 = 0;

		//	foreach (var archetype in Query_Filter_1.archetypes)
		//	{
		//		if (archetype.TypeIndexMap.TryGetValue(ComponentTypeRegister.GetID(typeof(PositionXComponent)), out int index1))
		//			_PosTypeIndex[archetypeIndex1++] = index1;
		//		else
		//		{
		//			_PosTypeIndex[archetypeIndex1++] = -1;
		//			throw new InvalidDataException(" didn't find Type in Archetype");
		//		}
		//		if (archetype.TypeIndexMap.TryGetValue(ComponentTypeRegister.GetID(typeof(VelocityXComponent)), out int index2))
		//			_VelTypeIndex[archetypeIndex2++] = index2;
		//		else
		//		{
		//			_VelTypeIndex[archetypeIndex2++] = -1;
		//			throw new InvalidDataException(" didn't find Type in Archetype");
		//		}
		//	}

		//		archetypeIndex1 = 0;
		//		archetypeIndex2 = 0;

		//	Query_Filter_1.UpdateArchetypes(ECSCore.entityManager);
		//	foreach (var archetype in Query_Filter_1.archetypes)
		//	{
		//		// 아키타입내부 컴포넌트 타입에 맞는 청크 순환
		//		foreach (var chunk in archetype.Chunks)
		//		{
		//			var PosArray = chunk.GetSpan<PositionXComponent>(_PosTypeIndex[archetypeIndex1]);
		//			var VelArray = chunk.GetSpan<VelocityXComponent>(_VelTypeIndex[archetypeIndex2]);
		//			for (int i = 0; i < PosArray.Length; i++)
		//			{
		//				PosArray[i].value += VelArray[i].value;
		//			}
		//		}
		//		archetypeIndex1++;
		//		archetypeIndex2++;
		//	}
		//}



	}
	
	

}
