using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_OOP_CompareTEST.TEST.ECS_OOP_TEST.OOPCore.OOPDomain
{
	internal class OOP_Main
	{
	}





	internal class OOPObejct
	{
		public float PositionX { get; private set; }
		public float PositionY { get; private set; }
		public float PositionZ { get; private set; }
		public float VelocityX { get; private set; }
		public float VelocityY { get; private set; }
		public float VelocityZ { get; private set; }

		private OOPObejct(float positionX, float positionY, float positionZ, float velocityX, float velocityY, float velocityZ)
		{
			this.PositionX = positionX;
			this.PositionY = positionY;
			this.PositionZ = positionZ;
			this.VelocityX = velocityX;
			this.VelocityY = velocityY;
			this.VelocityZ = velocityZ;
		}

		public static OOPObejct Of(float positionX, float positionY, float positionZ, float velocityX, float velocityY, float velocityZ)
		{
			return new OOPObejct(positionX , positionY, positionZ , velocityX , velocityY , velocityZ);
		}






	}

}
