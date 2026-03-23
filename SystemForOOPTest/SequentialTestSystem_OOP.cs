using ECS_OOP_CompareTEST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_OOP_CompareTEST
{
	internal class SequentialTestSystem_OOP : IObject
	{
		public void Set(OOPObejct[] oopObjects)
		{

		}

		public void OnUpdate(OOPObejct[] oopObjects)
		{
			for (int i = 0; i < oopObjects.Length; i++)
			{
				var obj = oopObjects[i];
				obj.PositionX += obj.VelocityX;
				obj.PositionY += obj.VelocityY;
				obj.PositionZ += obj.VelocityZ;
			}
		}

	}
}
