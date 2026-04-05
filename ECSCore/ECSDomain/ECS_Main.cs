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

		int activeID = ComponentTypeRegister.GetID<ActiveComponent>();
		int posXID = ComponentTypeRegister.GetID<PositionXComponent>();
		int posYID = ComponentTypeRegister.GetID<PositionYComponent>();
		int posZID = ComponentTypeRegister.GetID<PositionZComponent>();
		int velXID = ComponentTypeRegister.GetID<VelocityXComponent>();
		int velYID = ComponentTypeRegister.GetID<VelocityYComponent>();
		int velZID = ComponentTypeRegister.GetID<VelocityZComponent>();
		int dummyID = ComponentTypeRegister.GetID<DummyComponent>();





		

		public void Init(int EntityCount , Testcase test)
		{
			InitCount = EntityCount;
			
			Entitys = new Entity[InitCount];

			ulong type1 = BitMaskRegister.BuildMask(activeID, posXID,posYID,posZID,velXID,velYID,velZID);
			ulong type2 = BitMaskRegister.BuildMask(activeID, posXID,posYID,posZID);
			ulong type3 = BitMaskRegister.BuildMask(activeID, velXID,velYID,velZID);
			ulong type4 = BitMaskRegister.BuildMask(activeID);
			ulong type5 = BitMaskRegister.BuildMask(dummyID);
													




			for (int i = 0; i < InitCount; i++)
			{
				bool active = rand.Next(2) == 1;
				bool hasPos = rand.Next(2) == 1;
				bool hasVel = rand.Next(2) == 1;

				if(active)
				{
					if (hasPos && hasVel)
					{
						//Entitys[i] = ECSCore.CreateEntity(typeof(ActiveComponent),
						//									typeof(PositionXComponent),
						//									typeof(PositionYComponent),
						//									typeof(PositionZComponent),
						//									typeof(VelocityXComponent),
						//									typeof(VelocityYComponent),
						//									typeof(VelocityZComponent));

						Entitys[i] = ECSCore.CreateEntity(type1);
						ECSCore.Init(Entitys[i]);
						ref var isactive = ref ECSCore.Get<ActiveComponent>(Entitys[i]);
						ref var posx = ref ECSCore.Get<PositionXComponent>(Entitys[i]);
						ref var posy = ref ECSCore.Get<PositionYComponent>(Entitys[i]);
						ref var posz = ref ECSCore.Get<PositionZComponent>(Entitys[i]);
						ref var velx = ref ECSCore.Get<VelocityXComponent>(Entitys[i]);
						ref var vely = ref ECSCore.Get<VelocityXComponent>(Entitys[i]);
						ref var velz = ref ECSCore.Get<VelocityXComponent>(Entitys[i]);
						isactive.Is = rand.Next(2) == 1;
						posx.value = rand.Next(0, 1000);
						posy.value = rand.Next(0, 1000);
						posz.value = rand.Next(0, 1000);
						velx.value = rand.Next(0, 1000);
						vely.value = rand.Next(0, 1000);
						velz.value = rand.Next(0, 1000);
					}
					else if (hasPos) 
					{
						//Entitys[i] = ECSCore.CreateEntity(	typeof(ActiveComponent),
						//									typeof(PositionXComponent),
						//									typeof(PositionYComponent),
						//									typeof(PositionZComponent));
						Entitys[i] = ECSCore.CreateEntity(type2);
						ECSCore.Init(Entitys[i]);
						ref var isactive = ref ECSCore.Get<ActiveComponent>(Entitys[i]);
						ref var posx = ref ECSCore.Get<PositionXComponent>(Entitys[i]);
						ref var posy = ref ECSCore.Get<PositionYComponent>(Entitys[i]);
						ref var posz = ref ECSCore.Get<PositionZComponent>(Entitys[i]);
						isactive.Is = rand.Next(2) == 1;
						posx.value = rand.Next(0, 1000);
						posy.value = rand.Next(0, 1000);
						posz.value = rand.Next(0, 1000);


					}
					else if (hasVel) 
					{
						//Entitys[i] = ECSCore.CreateEntity(typeof(ActiveComponent),
						//										typeof(VelocityXComponent),
						//										typeof(VelocityYComponent),
						//										typeof(VelocityZComponent));
						Entitys[i] = ECSCore.CreateEntity(type3);
						ECSCore.Init(Entitys[i]);
						ref var isactive = ref ECSCore.Get<ActiveComponent>(Entitys[i]);
						ref var velx = ref ECSCore.Get<VelocityXComponent>(Entitys[i]);
						ref var vely = ref ECSCore.Get<VelocityXComponent>(Entitys[i]);
						ref var velz = ref ECSCore.Get<VelocityXComponent>(Entitys[i]);
						isactive.Is = rand.Next(2) == 1;
						velx.value = rand.Next(0, 1000);
						vely.value = rand.Next(0, 1000);
						velz.value = rand.Next(0, 1000);
					}
					else
					{
						//Entitys[i] = ECSCore.CreateEntity(	typeof(ActiveComponent));					
						Entitys[i] = ECSCore.CreateEntity(type4);
						ECSCore.Init(Entitys[i]);
						ref var isactive = ref ECSCore.Get<ActiveComponent>(Entitys[i]);
						isactive.Is = rand.Next(2) == 1;
					}
				}
				else
				{
					//Entitys[i] = ECSCore.CreateEntity(typeof(DummyComponent));
					Entitys[i] = ECSCore.CreateEntity(type5);
					ECSCore.Init(Entitys[i]);
					ref var dummy = ref ECSCore.Get<DummyComponent>(Entitys[i]);
				}

				//ECSCore.Init(Entitys[i]);

			}
			


			//query[0] = ECSCore.Query()
			//	.WithAll<ActiveComponent>()
			//	.WithAll<PositionXComponent>()
			//	.WithAll<PositionYComponent>()
			//	.WithAll<PositionZComponent>()
			//	.WithAll<VelocityXComponent>()
			//	.WithAll<VelocityYComponent>()
			//	.WithAll<VelocityZComponent>()
			//	.WithNone<DummyComponent>()
			//	.Build();

			//foreach (var archetype in query[0].GetArchetype(ECSCore.entityManager))
			//{
			//	var active_IDx = archetype.GetTypeIndex(activeID);
			//	var posX_IDx = archetype.GetTypeIndex(posXID);
			//	var posY_IDx = archetype.GetTypeIndex(posYID);
			//	var posZ_IDx = archetype.GetTypeIndex(posZID);
			//	var velX_IDx = archetype.GetTypeIndex(velXID);
			//	var velY_IDx = archetype.GetTypeIndex(velYID);
			//	var velZ_IDx = archetype.GetTypeIndex(velZID);
			//	foreach (var chunk in archetype.Chunks)
			//	{
			//		var active_Span = chunk.GetSpan<ActiveComponent>(active_IDx);
			//		var posX_Span = chunk.GetSpan<PositionXComponent>(posX_IDx);
			//		var posY_Span = chunk.GetSpan<PositionYComponent>(posY_IDx);
			//		var posZ_Span = chunk.GetSpan<PositionZComponent>(posZ_IDx);
			//		var velX_Span = chunk.GetSpan<VelocityXComponent>(velX_IDx);
			//		var velY_Span = chunk.GetSpan<VelocityYComponent>(velY_IDx);
			//		var velZ_Span = chunk.GetSpan<VelocityZComponent>(velZ_IDx);
					
			//		for(int i = 0 ; i < chunk.ChunkCount ; i++)
			//		{
			//			active_Span[i].Is = rand.Next(2) == 1;
			//			posX_Span[i].value = rand.Next(0,1000);
			//			posY_Span[i].value = rand.Next(0,1000);
			//			posZ_Span[i].value = rand.Next(0,1000);
			//			velX_Span[i].value = rand.Next(0,1000);
			//			velY_Span[i].value = rand.Next(0,1000);
			//			velZ_Span[i].value = rand.Next(0,1000);
			//		}
			//	}
			//}

			//query[1] = ECSCore.Query()
			//	.WithAll<ActiveComponent>()
			//	.WithAll<PositionXComponent>()
			//	.WithAll<PositionYComponent>()
			//	.WithAll<PositionZComponent>()
			//	.WithNone<VelocityXComponent>()
			//	.WithNone<VelocityYComponent>()
			//	.WithNone<VelocityZComponent>()
			//	.WithNone<DummyComponent>()
			//	.Build();
			
			//foreach (var archetype in query[1].GetArchetype(ECSCore.entityManager))
			//{
			//	var active_IDx = archetype.GetTypeIndex(activeID);
			//	var posX_IDx =  archetype.GetTypeIndex(posXID);
			//	var posY_IDx =  archetype.GetTypeIndex(posYID);
			//	var posZ_IDx = archetype.GetTypeIndex(posZID);
			//	foreach (var chunk in archetype.Chunks)
			//	{
			//		var active_Span = chunk.GetSpan<ActiveComponent>(active_IDx);
			//		var posX_Span = chunk.GetSpan<PositionXComponent>(posX_IDx);
			//		var posY_Span = chunk.GetSpan<PositionYComponent>(posY_IDx);
			//		var posZ_Span = chunk.GetSpan<PositionZComponent>(posZ_IDx);

			//		for (int i = 0; i < chunk.ChunkCount; i++)
			//		{
			//			active_Span[i].Is = rand.Next(2) == 1;
			//			posX_Span[i].value = rand.Next(0, 1000);
			//			posY_Span[i].value = rand.Next(0, 1000);
			//			posZ_Span[i].value = rand.Next(0, 1000);
			//		}
			//	}
			//}

			//query[2] = ECSCore.Query()
			//	.WithAll<ActiveComponent>()
			//	.WithAll<VelocityXComponent>()
			//	.WithAll<VelocityYComponent>()
			//	.WithAll<VelocityZComponent>()
			//	.WithNone<PositionXComponent>()
			//	.WithNone<PositionYComponent>()
			//	.WithNone<PositionZComponent>()
			//	.WithNone<DummyComponent>()
			//	.Build();

			//foreach (var archetype in query[2].GetArchetype(ECSCore.entityManager))
			//{
			//	var active_IDx = archetype.GetTypeIndex(activeID);
			//	var velX_IDx = archetype.GetTypeIndex(velXID);
			//	var velY_IDx = archetype.GetTypeIndex(velYID);
			//	var velZ_IDx = archetype.GetTypeIndex(velZID);
			//	foreach (var chunk in archetype.Chunks)
			//	{
			//		var active_Span = chunk.GetSpan<ActiveComponent>(active_IDx);
			//		var velX_Span = chunk.GetSpan<VelocityXComponent>(velX_IDx);
			//		var velY_Span = chunk.GetSpan<VelocityYComponent>(velY_IDx);
			//		var velZ_Span = chunk.GetSpan<VelocityZComponent>(velZ_IDx);

			//		for (int i = 0; i < chunk.ChunkCount; i++)
			//		{
			//			active_Span[i].Is = rand.Next(2) == 1;
			//			velX_Span[i].value = rand.Next(0, 1000);
			//			velY_Span[i].value = rand.Next(0, 1000);
			//			velZ_Span[i].value = rand.Next(0, 1000);
			//		}
			//	}
			//}

			//query[3] = ECSCore .Query()
			//	.WithAll<ActiveComponent>()
			//	.WithNone<PositionXComponent>()
			//	.WithNone<PositionYComponent>()
			//	.WithNone<PositionZComponent>()
			//	.WithNone<VelocityXComponent>()
			//	.WithNone<VelocityYComponent>()
			//	.WithNone<VelocityZComponent>()
			//	.WithNone<DummyComponent>()
			//	.Build();
			
			//foreach (var archetype in query[3].GetArchetype(ECSCore.entityManager))
			//{
			//	var active_IDx = archetype.GetTypeIndex(activeID);
			//	foreach (var chunk in archetype.Chunks)
			//	{
			//		var active_Span = chunk.GetSpan<ActiveComponent>(active_IDx);

			//		for (int i = 0; i < chunk.ChunkCount; i++)
			//		{
			//			active_Span[i].Is = rand.Next(2) == 1;
			//		}
			//	}
			//}

			//query[4] = ECSCore.Query()
			//	.WithAll<DummyComponent>()
			//	.WithNone<ActiveComponent>()
			//	.WithNone<PositionXComponent>()
			//	.WithNone<PositionYComponent>()
			//	.WithNone<PositionZComponent>()
			//	.WithNone<VelocityXComponent>()
			//	.WithNone<VelocityYComponent>()
			//	.WithNone<VelocityZComponent>()
			//	.Build();
			
			//foreach (var archetype in query[4].GetArchetype(ECSCore.entityManager))
			//{
			//	var dummy_IDx = archetype.GetTypeIndex(dummyID);
			//	foreach (var chunk in archetype.Chunks)
			//	{
			//		var dummy_Span =  chunk.GetSpan<DummyComponent>(dummy_IDx);
			//	}
			//}


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
					case Testcase.CALCULATION:
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
		
	}
}
