using ECSCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_OOP_CompareTEST
{
	internal class ConditionalTestSystem_ECS : ISystem
	{
		EntityQuery Query_FilterForConditional;
		int activeID = ComponentTypeRegister.GetID<ActiveComponent>();
		int posXID = ComponentTypeRegister.GetID<PositionXComponent>();
		int posYID = ComponentTypeRegister.GetID<PositionYComponent>();
		int posZID = ComponentTypeRegister.GetID<PositionZComponent>();
		int velXID = ComponentTypeRegister.GetID<VelocityXComponent>();
		int velYID = ComponentTypeRegister.GetID<VelocityYComponent>();
		int velZID = ComponentTypeRegister.GetID<VelocityZComponent>();

		public void Set(ECSManager ecsMG)
		{
			Query_FilterForConditional = ecsMG.Query()
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
			foreach (var archetype in Query_FilterForConditional.GetArchetype(ecsMG.entityManager))
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
					var active_Span = chunk.GetSpan<ActiveComponent>(active_IDx);
					var posX_Span = chunk.GetSpan<PositionXComponent>(posX_IDx);
					var posY_Span = chunk.GetSpan<PositionYComponent>(posY_IDx);
					var posZ_Span = chunk.GetSpan<PositionZComponent>(posZ_IDx);
					var velX_Span = chunk.GetSpan<VelocityXComponent>(velX_IDx);
					var velY_Span = chunk.GetSpan<VelocityYComponent>(velY_IDx);
					var velZ_Span = chunk.GetSpan<VelocityZComponent>(velZ_IDx);


					for (int i = 0; i < chunk.ChunkCount; i++)
					{
						if (active_Span[i].Is)
						{
							posX_Span[i].value = posX_Span[i].value + (velX_Span[i].value * 2.5f);
							posY_Span[i].value = posY_Span[i].value + (velY_Span[i].value * 2.5f);
							posZ_Span[i].value = posZ_Span[i].value + (velZ_Span[i].value * 2.5f);
						}
					}
				}
			}
		}


	}
}
