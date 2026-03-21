using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_OOP_CompareTEST
{
	internal interface ITest
	{
		public void Init(int objectCount);
		public void RunSequential();
		public void RunConditional();
		public void RunRandom();
		public void RunMultiComponent();
		public void RunCalculation();

	}
}
