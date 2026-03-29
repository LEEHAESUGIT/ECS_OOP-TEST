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

		Random rand = new Random(1000);
		public OOPObejct[] oopObjects;
		

		SequentialTestSystem_OOP sequential = new SequentialTestSystem_OOP();
		ConditionalTestSystem_OOP conditional = new ConditionalTestSystem_OOP();
		RandomTestSystem_OOP random = new RandomTestSystem_OOP();
		MultiComponentTestSystem_OOP multiComponent = new MultiComponentTestSystem_OOP();
		CaculationTestSystem_OOP caculation = new CaculationTestSystem_OOP();
		public void Init(int objectCount, Testcase test)
		{
			InitCount = objectCount;
			oopObjects = new OOPObejct[objectCount];
			

			for (int objectIndex = 0; objectIndex < objectCount; objectIndex++)
			{
				oopObjects[objectIndex] = new OOPObejct();
				oopObjects[objectIndex].PositionX = rand.Next(0,1000);
				oopObjects[objectIndex].PositionY = rand.Next(0,1000);
				oopObjects[objectIndex].PositionZ = rand.Next(0,1000);
				oopObjects[objectIndex].VelocityX = rand.Next(0,1000);
				oopObjects[objectIndex].VelocityX = rand.Next(0,1000);
				oopObjects[objectIndex].VelocityX = rand.Next(0,1000);
			}

			switch(test)
			{
				case Testcase.SEQUENTIAL:
					sequential.Set(oopObjects);
					break;
				case Testcase.CONDITIONAL:
					conditional.Set(oopObjects);
					break;
				case Testcase.RANDOM:
					random.Set(oopObjects); 
					break;
				case Testcase.MULTICOMPONENT:
					multiComponent.Set(oopObjects);
					break;
				case Testcase.CACULATION:
					caculation.Set(oopObjects);
					break;
				default: 
					break;
					
			}
		}
	

		public void RunSequential() => sequential.OnUpdate(oopObjects);
		public void RunConditional() => conditional.OnUpdate(oopObjects);
		public void RunRandom() => random.OnUpdate(oopObjects);
		public void RunMultiComponent() => multiComponent.OnUpdate(oopObjects);
		public void RunCalculation() => caculation.OnUpdate(oopObjects);
	}

	internal class OOPObejct
	{
		public bool HasPos;
		public bool HasVel;
		public bool IsActive;
		public float PositionX, PositionY, PositionZ;
		public float VelocityX, VelocityY, VelocityZ;




		public OOPObejct() 
		{
			this.HasPos = false;
			this.HasVel = false;
			this.IsActive = false;
			this.PositionX = 0;
			this.PositionY = 0;
			this.PositionZ = 0;
			this.VelocityX = 0;
			this.VelocityY = 0;
			this.VelocityZ = 0;
		}


		public OOPObejct(float positionX, float positionY, float positionZ, float velocityX, float velocityY, float velocityZ , bool active,  bool hasPos, bool hasVel)
		{
			this.PositionX = positionX;
			this.PositionY = positionY;
			this.PositionZ = positionZ;
			this.VelocityX = velocityX;
			this.VelocityY = velocityY;
			this.VelocityZ = velocityZ;
			this.IsActive = active;
			this.HasPos = hasPos;
			this.HasVel = hasVel;
		}
		
	}
}
