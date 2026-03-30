using ECS_OOP_CompareTEST;
using ECSCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_OOP_CompareTEST
{
	internal class SequentialTestSystem_ECS : ISystem
	{
		EntityQuery Query_Filter;
		
		public void Set(ECSManager ecsMG)
		{
			Query_Filter = ecsMG.Query()
				.WithAll<ActiveComponent>()
				.WithAll<PositionXComponent>()
				.WithAll<VelocityXComponent>()
				.WithNone<DummyComponent>()
				.Build();
			Query_Filter.UpdateArchetypes(ecsMG.entityManager);

		}

		public void OnUpdate(ECSManager ecsMG)
		{
			foreach (var archetype in Query_Filter.archetypes)
			{
				var active_IDx = archetype.GetTypeIndex<ActiveComponent>();
				var posX_IDx = archetype.GetTypeIndex<PositionXComponent>();
				var velX_IDx = archetype.GetTypeIndex<VelocityXComponent>();
				foreach (var chunk in archetype.Chunks)
				{
					var active_Span = chunk.GetSpan<ActiveComponent>(active_IDx);
					var posX_Span = chunk.GetSpan<PositionXComponent>(posX_IDx);
					var velX_Span = chunk.GetSpan<VelocityXComponent>(velX_IDx);

					for (int i = 0; i < chunk.ChunkCount; i++)
					{
						if (active_Span[i].Is)
						{
							posX_Span[i].value += velX_Span[i].value;
						}
					}
				}
			}
		}
	}
}
