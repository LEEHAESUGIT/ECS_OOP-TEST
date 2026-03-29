using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_OOP_CompareTEST
{
	internal class MultiComponentTestSystem_OOP : IObject
	{
		Random rand = new Random(1000);
		public void Set(OOPObejct[] oopObjects)
		{
			for (int i = 0; i < oopObjects.Length; i++)
			{
				oopObjects[i].IsActive = true;
				oopObjects[i].HasPos = rand.Next(2) == 1;
				oopObjects[i].HasVel = rand.Next(3) == 0;
			}
		}
		public void OnUpdate(OOPObejct[] oopObjects)
		{
			for (int i = 0; i < oopObjects.Length; i++)
			{
				var obj = oopObjects[i];
				if (obj.IsActive && obj.HasPos && obj.HasVel)
				{
					obj.PositionX += obj.VelocityX;
					obj.PositionY += obj.VelocityY;
					obj.PositionZ += obj.VelocityZ;
				}

			}
		}
	}
}
