using ECS_OOP_CompareTEST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_OOP_CompareTEST
{
	internal class OOP_Main : ITest
	{
		float value = 1f;
		int InitCount;

		Random rand = new Random();
		public OOPObejct[] oopObjects;
		

		SequentialTestSystem_OOP sequential = new SequentialTestSystem_OOP();
		ConditionalTestSystem_OOP conditional = new ConditionalTestSystem_OOP();
		RandomTestSystem_OOP random = new RandomTestSystem_OOP();
		MultiComponentTestSystem_OOP multiComponent = new MultiComponentTestSystem_OOP();
		CaculationTestSystem_OOP caculation = new CaculationTestSystem_OOP();
		public void Init(int objectCount)
		{
			InitCount = objectCount;
			oopObjects = new OOPObejct[objectCount];
			

			for (int objectIndex = 0; objectIndex < objectCount; objectIndex++)
			{
				oopObjects[objectIndex] = OOPObejct.Of(value, value, value, value, value, value ,rand.Next(2)==1);
			}

			if (oopObjects[^1].PositionX != value)
			{
				throw new InvalidDataException("do Not Include Data PositionXComponent");
			}
			if (oopObjects[^1].PositionY != value)
			{
				throw new InvalidDataException("do Not Include Data PositionYComponent");
			}
			if (oopObjects[^1].PositionZ != value)
			{
				throw new InvalidDataException("do Not Include Data PositionZComponent");
			}
			if (oopObjects[^1].VelocityX != value)
			{
				throw new InvalidDataException("do Not Include Data VelocityXComponent");
			}
			if (oopObjects[^1].VelocityY != value)
			{
				throw new InvalidDataException("do Not Include Data VelocityYComponent");
			}
			if (oopObjects[^1].VelocityZ != value)
			{
				throw new InvalidDataException("do Not Include Data VelocityZComponent");
			}
			sequential.Set(oopObjects);
			conditional.Set(oopObjects);
			random.Set(oopObjects);
			multiComponent.Set(oopObjects);
			caculation.Set(oopObjects);

		}
		//public OOPObejct[] Clone()
		//{
		//	var copy = oopObjects.Select(o => OOPObejct.Of(o.PositionX,
		//													o.PositionY,
		//													o.PositionZ,
		//													o.VelocityX,
		//													o.VelocityY,
		//													o.VelocityZ,
		//													o.IsActive)).ToArray();
		//	return copy;
		//}		

		public void RunSequential()
		{
			sequential.OnUpdate(oopObjects);
		}
		public void RunConditional() 
		{ 
			conditional.OnUpdate(oopObjects);
		}
		public void RunRandom() 
		{ 
			random.OnUpdate(oopObjects);
		}
		public void RunMultiComponent() 
		{
			multiComponent.OnUpdate(oopObjects);
		}
		public void RunCalculation() 
		{
			caculation.OnUpdate(oopObjects);
		}




		// 
		

	}





	internal class OOPObejct
	{
		public float PositionX { get;  set; }
		public float PositionY { get;  set; }
		public float PositionZ { get;  set; }
		public float VelocityX { get;  set; }
		public float VelocityY { get;  set; }
		public float VelocityZ { get;  set; }
		public bool IsActive { get;  set; }

		private OOPObejct(float positionX, float positionY, float positionZ, float velocityX, float velocityY, float velocityZ, bool isActive)
		{
			this.PositionX = positionX;
			this.PositionY = positionY;
			this.PositionZ = positionZ;
			this.VelocityX = velocityX;
			this.VelocityY = velocityY;
			this.VelocityZ = velocityZ;
			this.IsActive = isActive;
		}

		public static OOPObejct Of(float positionX, float positionY, float positionZ, float velocityX, float velocityY, float velocityZ, bool isActive)
		{
			return new OOPObejct(positionX, positionY, positionZ, velocityX, velocityY, velocityZ, isActive);
		}

		//public OOPObejct ChangePosX(float positionX) => copyWith(positionX, null, null, null, null, null, true);
		//public OOPObejct ChangePosY(float positionY) => copyWith(null, positionY, null, null, null, null, true);
		//public OOPObejct ChangePosZ(float positionZ) => copyWith(null, null, positionZ, null, null, null, true);
		//public OOPObejct ChangeVelX(float velovityX) => copyWith(null, null, null, velovityX, null, null, true);
		//public OOPObejct ChangeVelY(float velovityY) => copyWith(null, null, null, null, velovityY, null, true);
		//public OOPObejct ChangeVelZ(float velovityZ) => copyWith(null, null, null, null, null, velovityZ, true);
		//public OOPObejct ChangeActive(bool Is) => copyWith(null, null, null, null, null, null, Is);


		//private OOPObejct copyWith(float? positionX = null,
		//							float? positionY = null,
		//							float? positionZ = null,
		//							float? velocityX = null,
		//							float? velocityY = null,
		//							float? velocityZ = null,
		//							bool? Is = true)
		//{
		//	return new OOPObejct(positionX ?? this.PositionX,
		//							positionY ?? this.PositionY,
		//							positionZ ?? this.PositionZ,
		//							velocityX ?? this.VelocityX,
		//							velocityY ?? this.VelocityY,
		//							velocityZ ?? this.VelocityZ,
		//							Is ?? this.IsActive);
		//}




	}

}
