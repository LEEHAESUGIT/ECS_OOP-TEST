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
		EntityQuery Query_Filter_1;
		int[] _PosTypeIndexGroup;
		int[] _VelTypeIndexGroup;
		public void Set(ECSManager ecsMG)
		{
			Query_Filter_1 = ecsMG.Query()
				.WithAll<PositionXComponent, VelocityXComponent>()
				.WithNone<NeedInit>()
				.Build();

			Query_Filter_1.UpdateArchetypes(ecsMG.entityManager);
			_PosTypeIndexGroup = new int[Query_Filter_1.archetypes.Count];
			_VelTypeIndexGroup = new int[Query_Filter_1.archetypes.Count];
			for(int i = 0 ; i < Query_Filter_1.archetypes.Count  ; i++)
			{
				_PosTypeIndexGroup[i] = Query_Filter_1.archetypes[i].GetTypeIndex<PositionXComponent>();
				_VelTypeIndexGroup[i] = Query_Filter_1.archetypes[i].GetTypeIndex<VelocityXComponent>();
			}

		}

		public void OnUpdate(ECSManager ecsMG)
		{
			int _posTypeIndex = 0;
			int _velTypeIndex = 0;

			Query_Filter_1.UpdateArchetypes(ecsMG.entityManager);
			foreach (var archetype in Query_Filter_1.archetypes)
			{
				// 아키타입내부 컴포넌트 타입에 맞는 청크 순환
				foreach (var chunk in archetype.Chunks)
				{
					var PosArray = chunk.GetSpan<PositionXComponent>(_PosTypeIndexGroup[_posTypeIndex]);
					var VelArray = chunk.GetSpan<VelocityXComponent>(_VelTypeIndexGroup[_velTypeIndex]);
					for (int i = 0; i < PosArray.Length; i++)
					{
						PosArray[i].value += VelArray[i].value;
					}
				}
				_posTypeIndex++;
				_velTypeIndex++;
			}
		}
	}
}
