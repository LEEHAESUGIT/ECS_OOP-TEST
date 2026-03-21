namespace ECSCore
{
	public interface ISystem
	{

		public void Set(ECSManager ecsMG);
		public void OnUpdate(ECSManager ecsMG);
	}
}
