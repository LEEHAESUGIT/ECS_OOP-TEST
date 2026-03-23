using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_OOP_CompareTEST
{
	internal class RandomTestSystem_OOP : IObject
	{
		Random rand = new Random();
		public int[] RandomIndexs;
		public void Set(OOPObejct[] oopObjects)
		{
			RandomIndexs = new int[oopObjects.Length];
			for(int i = 0 ; i < oopObjects.Length ; i++)
			{
				RandomIndexs[i] = i;
			}
			shuffle(RandomIndexs);
		}
		public void OnUpdate(OOPObejct[] oopObjects )
		{
			for (int i = 0; i < oopObjects.Length; i++)
			{
				var obj = oopObjects[RandomIndexs[i]];

				obj.PositionX += obj.VelocityX;
				obj.PositionY -= obj.VelocityY;
				obj.PositionZ *= obj.VelocityZ;

			}
		}
		public void shuffle(int[] randIndexs)
		{
			for (int i = randIndexs.Length - 1; i > 0; i--)
			{
				int index = rand.Next(i);
				(randIndexs[i], randIndexs[index]) = (randIndexs[index], randIndexs[i]);
			}
		}
	}
}
