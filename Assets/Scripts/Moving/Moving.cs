// IMoving.cs. 
// 
// Vpetrov. Петров Василий Александрович. 
// 
// 2017
namespace Assets.Scripts.Moving
{
	public abstract class Moving
	{
		public float Speed { get; set; }

		public abstract void Process();
	}
}