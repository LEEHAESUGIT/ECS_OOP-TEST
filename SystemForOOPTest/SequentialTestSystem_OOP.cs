using ECS_OOP_CompareTEST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_OOP_CompareTEST
{
	internal class SequentialTestSystem_OOP
	{
		public void OnUpdate(OOPObejct[] oopObjects)
		{
			foreach (var oopObject in oopObjects)
			{
				oopObject.PositionX += oopObject.VelocityX;

				//oopObject.ChangePosX(oopObject.PositionX + oopObject.VelocityX);
			}
		}

	}
}
