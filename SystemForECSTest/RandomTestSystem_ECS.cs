using ECSCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_OOP_CompareTEST
{
	internal class RandomTestSystem_ECS : ISystem
	{
		Random rand = new Random(1000);
		EntityQuery Query_FilterForRandom;
		int activeID = ComponentTypeRegister.GetID<ActiveComponent>();
		int posXID = ComponentTypeRegister.GetID<PositionXComponent>();
		int posYID = ComponentTypeRegister.GetID<PositionYComponent>();
		int posZID = ComponentTypeRegister.GetID<PositionZComponent>();
		int velXID = ComponentTypeRegister.GetID<VelocityXComponent>();
		int velYID = ComponentTypeRegister.GetID<VelocityYComponent>();
		int velZID = ComponentTypeRegister.GetID<VelocityZComponent>();

		private int[] RandomIndexs;

		public void Set(ECSManager ecsMG)
		{
			Query_FilterForRandom = ecsMG.Query()
										.WithAll<ActiveComponent>()
										.WithAll<PositionXComponent>()
										.WithAll<PositionYComponent>()
										.WithAll<PositionZComponent>()
										.WithAll<VelocityXComponent>()
										.WithAll<VelocityYComponent>()
										.WithAll<VelocityZComponent>()
										.WithNone<NeedInit>()
										.WithNone<DummyComponent>()
										.Build();

			
		}
		public void OnUpdate(ECSManager ecsMG)
		{
			foreach (var archetype in Query_FilterForRandom.GetArchetype(ecsMG.entityManager))
			{
				var active_IDx = archetype.GetTypeIndex(activeID);
				var posX_IDx = archetype.GetTypeIndex(posXID);
				var posY_IDx = archetype.GetTypeIndex(posYID);
				var posZ_IDx = archetype.GetTypeIndex(posZID);
				var velX_IDx = archetype.GetTypeIndex(velXID);
				var velY_IDx = archetype.GetTypeIndex(velYID);
				var velZ_IDx = archetype.GetTypeIndex(velZID);
				foreach (var chunk in archetype.Chunks)
				{
					RandomIndexs = new int[chunk.ChunkCount];
					shuffle(RandomIndexs);
					var active_Span = chunk.GetSpan<ActiveComponent>(active_IDx);
					var posX_Span = chunk.GetSpan<PositionXComponent>(posX_IDx);
					var posY_Span = chunk.GetSpan<PositionYComponent>(posY_IDx);
					var posZ_Span = chunk.GetSpan<PositionZComponent>(posZ_IDx);
					var velX_Span = chunk.GetSpan<VelocityXComponent>(velX_IDx);
					var velY_Span = chunk.GetSpan<VelocityYComponent>(velY_IDx);
					var velZ_Span = chunk.GetSpan<VelocityZComponent>(velZ_IDx);


					for (int i = 0; i < chunk.ChunkCount; i++)
					{

						if (active_Span[RandomIndexs[i]].Is)
						{
							posX_Span[RandomIndexs[i]].value += velX_Span[RandomIndexs[i]].value;
							posY_Span[RandomIndexs[i]].value -= velY_Span[RandomIndexs[i]].value;
							posZ_Span[RandomIndexs[i]].value *= velZ_Span[RandomIndexs[i]].value;
						}
					}
				}
			}
		}
		public void shuffle(int[] randIndexs)
		{
			for (int i = randIndexs.Length - 1; i > 0; i--)
			{
				int index = rand.Next(i);
				(randIndexs[i], randIndexs[index]) = (randIndexs[index], randIndexs[i]);
			}
		}
	}
}
