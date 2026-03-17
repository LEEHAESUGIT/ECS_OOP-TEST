
using System.ComponentModel;

namespace ECSCore
{
	internal static class ComponentSetting
	{
		internal static void SetComponent(params Type[] SetComponentTypes)
		{
			//default
			ComponentTypeRegister.Set(typeof(NeedInit)); // 무조건 항상 0번째
			
			foreach(Type component in SetComponentTypes)
			{
				ComponentTypeRegister.Set(component);
			}

		}
	}

	// Component Flags
	internal struct NeedInit : IComponentData { }
}