using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_OOP_CompareTEST
{
	internal class ConditionalTestSystem_OOP
	{
		public void OnUpdate(OOPObejct[] oopObjects)
		{
			foreach(OOPObejct Object in oopObjects)
			{
				if(Object.IsActive)
				{
					Object.PositionX = Object.PositionY + (Object.VelocityY * 2.5f);
				}

			}
		}
	}
}
