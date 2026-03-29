using ECSCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_OOP_CompareTEST
{
	internal class CaculationTestSystem_OOP : IObject
	{
		Random rand = new Random(1000);
		public void Set(OOPObejct[] oopObjects)
		{
			for (int i = 0; i < oopObjects.Length; i++)
			{
				oopObjects[i].IsActive = true;
				oopObjects[i].HasPos =  rand.Next(2) == 1;
				oopObjects[i].HasVel = rand.Next(2) == 1;
			}
		}
		public void OnUpdate(OOPObejct[] oopObjects)
		{
			for (int i = 0; i < oopObjects.Length; i++)
			{
				var obj = oopObjects[i];
				if (obj.IsActive && obj.HasPos && obj.HasVel)
				{
					var px = obj.PositionX;
					var vx = obj.VelocityX;
					px = px * 0.5f;
					px = px + (vx + 1) * 0.3f;
					px = px - (px * 0.1f);
					px = px + (vx * px) * 0.0001f;
					obj.PositionX = px;


					var py = obj.PositionY;
					var vy = obj.VelocityY;
					py = py * 0.5f;
					py = py + (vy + 1) * 0.3f;
					py = py - (py * 0.1f);
					py = py + (vy * py) * 0.0001f;
					obj.PositionY = py;

					var pz = obj.PositionZ;
					var vz = obj.VelocityZ;
					pz = pz * 0.5f;
					pz = pz + (vz + 1) * 0.3f;
					pz = pz - (pz * 0.1f);
					pz = pz + (vz * pz) * 0.0001f;
					obj.PositionZ = pz;
				}
			}
		}
	}
}
