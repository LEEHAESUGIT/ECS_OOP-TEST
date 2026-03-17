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

		public OOPObejct ChangePosX(float positionX) => copyWith(positionX , null, null,null, null,null);
		public OOPObejct ChangePosY(float positionY) => copyWith(null, positionY , null,null, null,null);
		public OOPObejct ChangePosZ(float positionZ) => copyWith(null, null, positionZ, null, null,null);
		public OOPObejct ChangeVelX(float velovityX) => copyWith(null, null, null, velovityX, null,null);
		public OOPObejct ChangeVelY(float velovityY) => copyWith(null, null, null,null, velovityY, null);
		public OOPObejct ChangevelZ(float velovityZ) => copyWith(null, null, null,null, null, velovityZ);


		private OOPObejct copyWith(	float? positionX = null,
									float? positionY = null,
									float? positionZ = null,
									float? velocityX = null,
									float? velocityY = null,
									float? velocityZ = null)
		{
			return new OOPObejct(	positionX ?? this.PositionX,
									positionY ?? this.PositionY,
									positionZ ?? this.PositionZ,
									velocityX ?? this.VelocityX,
									velocityY ?? this.VelocityY,
									velocityZ ?? this.VelocityZ);
		}




	}

}
