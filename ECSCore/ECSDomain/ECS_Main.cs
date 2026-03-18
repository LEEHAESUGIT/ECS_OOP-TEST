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
		public void Init(int EntityCount)
		{
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
		public void RunSequential() { }
		public void RunConditional() { }
		public void RunRandom() { }
		public void RunMultiComponent() { }
		public void RunCalculation() { }


	}
	public struct PositionXComponent : IComponentData
	{
		public float value;
	}
	public struct PositionYComponent : IComponentData
	{
		public float value;
	}
	public struct PositionZComponent : IComponentData
	{
		public float value;
	}
	public struct VelocityXComponent : IComponentData
	{
		public float value;
	}
	public struct VelocityYComponent : IComponentData
	{
		public float value;
	}
	public struct VelocityZComponent : IComponentData
	{
		public float value;
	}

}
