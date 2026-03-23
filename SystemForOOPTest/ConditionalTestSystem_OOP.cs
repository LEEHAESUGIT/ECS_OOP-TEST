using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_OOP_CompareTEST
{
	internal class ConditionalTestSystem_OOP : IObject
	{
		public void Set(OOPObejct[] oopObjects)
		{

		}
		public void OnUpdate(OOPObejct[] oopObjects)
		{
			for (int i = 0; i < oopObjects.Length; i++)
			{
				var obj = oopObjects[i];
				if (obj.IsActive)
				{
					obj.PositionX = obj.PositionX + (obj.VelocityX * 2.5f);
					obj.PositionY = obj.PositionY + (obj.VelocityY * 2.5f);
					obj.PositionZ = obj.PositionZ + (obj.VelocityZ * 2.5f);
				}
			}
		}
	}
}
