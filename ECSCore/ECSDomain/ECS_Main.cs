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
						Entitys[i] = ECSCore.CreateEntity(	typeof(ActiveComponent));					
					}
				}
				else
				{
					Entitys[i] = ECSCore.CreateEntity(typeof(DummyComponent));
				}

				ECSCore.Init(Entitys[i]);

			}
			


			query[0] = ECSCore.Query()
				.WithAll<ActiveComponent>()
				.WithAll<PositionXComponent>()
				.WithAll<PositionYComponent>()
				.WithAll<PositionZComponent>()
				.WithAll<VelocityXComponent>()
				.WithAll<VelocityYComponent>()
				.WithAll<VelocityZComponent>()
				.WithNone<DummyComponent>()
				.Build();
			query[0].UpdateArchetypes(ECSCore.entityManager);
			foreach (var archetype in query[0].archetypes)
			{
				var active_IDx = archetype.GetTypeIndex<ActiveComponent>();
				var posX_IDx = archetype.GetTypeIndex<PositionXComponent>();
				var posY_IDx = archetype.GetTypeIndex<PositionYComponent>();
				var posZ_IDx = archetype.GetTypeIndex<PositionZComponent>();
				var velX_IDx = archetype.GetTypeIndex<VelocityXComponent>();
				var velY_IDx = archetype.GetTypeIndex<VelocityYComponent>();
				var velZ_IDx = archetype.GetTypeIndex<VelocityZComponent>();
				foreach (var chunk in archetype.Chunks)
				{
					var active_Span = chunk.GetSpan<ActiveComponent>(active_IDx);
					var posX_Span = chunk.GetSpan<PositionXComponent>(posX_IDx);
					var posY_Span = chunk.GetSpan<PositionYComponent>(posY_IDx);
					var posZ_Span = chunk.GetSpan<PositionZComponent>(posZ_IDx);
					var velX_Span = chunk.GetSpan<VelocityXComponent>(velX_IDx);
					var velY_Span = chunk.GetSpan<VelocityYComponent>(velY_IDx);
					var velZ_Span = chunk.GetSpan<VelocityZComponent>(velZ_IDx);
					
					for(int i = 0 ; i < chunk.ChunkCount ; i++)
					{
						active_Span[i].Is = rand.Next(2) == 1;
						posX_Span[i].value = rand.Next(0,1000);
						posY_Span[i].value = rand.Next(0,1000);
						posZ_Span[i].value = rand.Next(0,1000);
						velX_Span[i].value = rand.Next(0,1000);
						velY_Span[i].value = rand.Next(0,1000);
						velZ_Span[i].value = rand.Next(0,1000);
					}
				}
			}

			query[1] = ECSCore.Query()
				.WithAll<ActiveComponent>()
				.WithAll<PositionXComponent>()
				.WithAll<PositionYComponent>()
				.WithAll<PositionZComponent>()
				.WithNone<VelocityXComponent>()
				.WithNone<VelocityYComponent>()
				.WithNone<VelocityZComponent>()
				.WithNone<DummyComponent>()
				.Build();
			query[1].UpdateArchetypes(ECSCore.entityManager);
			foreach (var archetype in query[1].archetypes)
			{
				var active_IDx = archetype.GetTypeIndex<ActiveComponent>();
				var posX_IDx = archetype.GetTypeIndex<PositionXComponent>();
				var posY_IDx = archetype.GetTypeIndex<PositionYComponent>();
				var posZ_IDx = archetype.GetTypeIndex<PositionZComponent>();
				foreach (var chunk in archetype.Chunks)
				{
					var active_Span = chunk.GetSpan<ActiveComponent>(active_IDx);
					var posX_Span = chunk.GetSpan<PositionXComponent>(posX_IDx);
					var posY_Span = chunk.GetSpan<PositionYComponent>(posY_IDx);
					var posZ_Span = chunk.GetSpan<PositionZComponent>(posZ_IDx);

					for (int i = 0; i < chunk.ChunkCount; i++)
					{
						active_Span[i].Is = rand.Next(2) == 1;
						posX_Span[i].value = rand.Next(0, 1000);
						posY_Span[i].value = rand.Next(0, 1000);
						posZ_Span[i].value = rand.Next(0, 1000);
					}
				}
			}

			query[2] = ECSCore.Query()
				.WithAll<ActiveComponent>()
				.WithAll<VelocityXComponent>()
				.WithAll<VelocityYComponent>()
				.WithAll<VelocityZComponent>()
				.WithNone<PositionXComponent>()
				.WithNone<PositionYComponent>()
				.WithNone<PositionZComponent>()
				.WithNone<DummyComponent>()
				.Build();
			query[2].UpdateArchetypes(ECSCore.entityManager);
			foreach (var archetype in query[2].archetypes)
			{
				var active_IDx = archetype.GetTypeIndex<ActiveComponent>();
				var velX_IDx = archetype.GetTypeIndex<VelocityXComponent>();
				var velY_IDx = archetype.GetTypeIndex<VelocityYComponent>();
				var velZ_IDx = archetype.GetTypeIndex<VelocityZComponent>();
				foreach (var chunk in archetype.Chunks)
				{
					var active_Span = chunk.GetSpan<ActiveComponent>(active_IDx);
					var velX_Span = chunk.GetSpan<VelocityXComponent>(velX_IDx);
					var velY_Span = chunk.GetSpan<VelocityYComponent>(velY_IDx);
					var velZ_Span = chunk.GetSpan<VelocityZComponent>(velZ_IDx);

					for (int i = 0; i < chunk.ChunkCount; i++)
					{
						active_Span[i].Is = rand.Next(2) == 1;
						velX_Span[i].value = rand.Next(0, 1000);
						velY_Span[i].value = rand.Next(0, 1000);
						velZ_Span[i].value = rand.Next(0, 1000);
					}
				}
			}

			query[3] = ECSCore .Query()
				.WithAll<ActiveComponent>()
				.WithNone<PositionXComponent>()
				.WithNone<PositionYComponent>()
				.WithNone<PositionZComponent>()
				.WithNone<VelocityXComponent>()
				.WithNone<VelocityYComponent>()
				.WithNone<VelocityZComponent>()
				.WithNone<DummyComponent>()
				.Build();
			query[3].UpdateArchetypes(ECSCore.entityManager);
			foreach (var archetype in query[3].archetypes)
			{
				var active_IDx = archetype.GetTypeIndex<ActiveComponent>();
				foreach (var chunk in archetype.Chunks)
				{
					var active_Span = chunk.GetSpan<ActiveComponent>(active_IDx);

					for (int i = 0; i < chunk.ChunkCount; i++)
					{
						active_Span[i].Is = rand.Next(2) == 1;
					}
				}
			}

			query[4] = ECSCore.Query()
				.WithAll<DummyComponent>()
				.WithNone<ActiveComponent>()
				.WithNone<PositionXComponent>()
				.WithNone<PositionYComponent>()
				.WithNone<PositionZComponent>()
				.WithNone<VelocityXComponent>()
				.WithNone<VelocityYComponent>()
				.WithNone<VelocityZComponent>()
				.Build();
			query[4].UpdateArchetypes(ECSCore.entityManager);
			foreach (var archetype in query[4].archetypes)
			{
				var dummy_IDx = archetype.GetTypeIndex<DummyComponent>();
				foreach (var chunk in archetype.Chunks)
				{
					var dummy_Span =  chunk.GetSpan<DummyComponent>(dummy_IDx);
				}
			}


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
		
	}
}
