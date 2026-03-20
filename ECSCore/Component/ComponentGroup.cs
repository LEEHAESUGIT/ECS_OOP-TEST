
namespace ECSCore
{
	internal static class ComponentSetting
	{
		internal static void SetComponent(params Type[] components)
		{
			// flag
			ComponentTypeRegister.Set(typeof(NeedInit)); // 무조건 항상 0번째

			for (int i = 0; i < components.Length; i++)
			{
				ComponentTypeRegister.Set(components[i]);
			}
		}
	}

	// Component Flags
	internal struct NeedInit : IComponentData { }
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