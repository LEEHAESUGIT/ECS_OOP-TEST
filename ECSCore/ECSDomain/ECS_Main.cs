using ECSCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_OOP_CompareTEST.TEST.ECS_OOP_TEST.ECSCore.ECSDomain
{
	internal class ECS_Main : ITest
	{
		public ECSManager ECSCore = new ECSManager();
		public Entity[] Entitys;
		float value = 1f;
		int InitCount;
		public void Init(int EntityCount)
		{
			InitCount = EntityCount;
			ComponentSetting.SetComponent(typeof(PositionXComponent),
											typeof(PositionYComponent),
											typeof(PositionZComponent),
											typeof(VelocityXComponent),
											typeof(VelocityYComponent),
											typeof(VelocityZComponent));

			Entitys = new Entity[EntityCount];

			for (int entityIndex = 0; entityIndex < EntityCount; entityIndex++)
			{
				Entitys[entityIndex] = ECSCore.CreateEntity(typeof(PositionXComponent),
										typeof(PositionYComponent),
										typeof(PositionZComponent),
										typeof(VelocityXComponent),
										typeof(VelocityYComponent),
										typeof(VelocityZComponent));
				ECSCore.Init(Entitys[entityIndex]);

				ECSCore.Get<PositionXComponent>(Entitys[entityIndex]).value = value;
				ECSCore.Get<PositionYComponent>(Entitys[entityIndex]).value = value;
				ECSCore.Get<PositionZComponent>(Entitys[entityIndex]).value = value;
				ECSCore.Get<VelocityXComponent>(Entitys[entityIndex]).value = value;
				ECSCore.Get<VelocityYComponent>(Entitys[entityIndex]).value = value;
				ECSCore.Get<VelocityZComponent>(Entitys[entityIndex]).value = value;
			}
			if(ECSCore.Get<PositionXComponent>(Entitys[^1]).value != value)
			{
				throw new InvalidDataException("do Not Include Data PositionXComponent");
			}
			if (ECSCore.Get<PositionYComponent>(Entitys[^1]).value != value)
			{
				throw new InvalidDataException("do Not Include Data PositionYComponent");
			}
			if (ECSCore.Get<PositionZComponent>(Entitys[^1]).value != value)
			{
				throw new InvalidDataException("do Not Include Data PositionZComponent");
			}
			if (ECSCore.Get<VelocityXComponent>(Entitys[^1]).value != value)
			{
				throw new InvalidDataException("do Not Include Data VelocityXComponent");
			}
			if (ECSCore.Get<VelocityYComponent>(Entitys[^1]).value != value)
			{
				throw new InvalidDataException("do Not Include Data VelocityYComponent");
			}
			if (ECSCore.Get<VelocityZComponent>(Entitys[^1]).value != value)
			{
				throw new InvalidDataException("do Not Include Data VelocityZComponent");
			}
		}
		public void RunSequential()
		{
			int[] _PosTypeIndex;
			int[] _VelTypeIndex;
			int archetypeIndex1;
			int archetypeIndex2;
			EntityQuery Query_Filter_1 = ECSCore.Query()
				.WithAll<PositionXComponent,VelocityXComponent>()
				.WithNone<NeedInit>()
				.Build();
			Query_Filter_1.UpdateArchetypes(ECSCore.entityManager);
			_PosTypeIndex = new int[Query_Filter_1.archetypes.Count];
			_VelTypeIndex = new int[Query_Filter_1.archetypes.Count];
			archetypeIndex1 = 0;
			archetypeIndex2 = 0;
			
			foreach (var archetype in Query_Filter_1.archetypes)
			{
				if (archetype.TypeIndexMap.TryGetValue(ComponentTypeRegister.GetID(typeof(PositionXComponent)), out int index1))
					_PosTypeIndex[archetypeIndex1++] = index1;
				else
				{
					_PosTypeIndex[archetypeIndex1++] = -1;
					throw new InvalidDataException(" didn't find Type in Archetype");
				}
				if (archetype.TypeIndexMap.TryGetValue(ComponentTypeRegister.GetID(typeof(VelocityXComponent)), out int index2))
					_VelTypeIndex[archetypeIndex2++] = index2;
				else
				{
					_VelTypeIndex[archetypeIndex2++] = -1;
					throw new InvalidDataException(" didn't find Type in Archetype");
				}
			}

				archetypeIndex1 = 0;
				archetypeIndex2 = 0;

			Query_Filter_1.UpdateArchetypes(ECSCore.entityManager);
			foreach (var archetype in Query_Filter_1.archetypes)
			{
				// 아키타입내부 컴포넌트 타입에 맞는 청크 순환
				foreach (var chunk in archetype.Chunks)
				{
					var PosArray = chunk.GetSpan<PositionXComponent>(_PosTypeIndex[archetypeIndex1]);
					var VelArray = chunk.GetSpan<VelocityXComponent>(_VelTypeIndex[archetypeIndex2]);
					for (int i = 0; i < PosArray.Length; i++)
					{
						PosArray[i].value += VelArray[i].value;
					}
				}
				archetypeIndex1++;
				archetypeIndex2++;
			}
		}
		public void RunConditional() { }
		public void RunRandom() { }
		public void RunMultiComponent() { }
		public void RunCalculation() { }


	}
	
	

}
