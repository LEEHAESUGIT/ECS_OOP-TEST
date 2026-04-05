
namespace ECSCore
{
	internal static class ComponentSetting
	{
		internal static void SetComponent()
		{

			// flag
			ComponentTypeRegister.Set<NeedInit>(); // 무조건 항상 0번째
												   // Status
			ComponentTypeRegister.Set<ActiveComponent>();
			ComponentTypeRegister.Set<PositionXComponent>();
			ComponentTypeRegister.Set<PositionYComponent>();
			ComponentTypeRegister.Set<PositionZComponent>();
			ComponentTypeRegister.Set<VelocityXComponent>();
			ComponentTypeRegister.Set<VelocityYComponent>();
			ComponentTypeRegister.Set<VelocityZComponent>();
			ComponentTypeRegister.Set<DummyComponent>();
			
			ComponentTypeRegister.IsFrozen = false;
		}
	}
	internal struct ActiveComponent() : IComponentData
	{
		internal bool Is; 
	}
	internal struct PositionXComponent() : IComponentData
	{
		internal float value;
	}
	internal struct PositionYComponent() : IComponentData
	{
		internal float value;
	}
	internal struct PositionZComponent() : IComponentData
	{
		internal float value;
	}
	internal struct VelocityXComponent() : IComponentData
	{
		internal float value;
	}
	internal struct VelocityYComponent() : IComponentData
	{
		internal float value;
	}
	internal struct VelocityZComponent() : IComponentData
	{
		internal float value;
	}
	internal struct DummyComponent() : IComponentData { }
	// Component Flags
	internal struct NeedInit : IComponentData { }
}