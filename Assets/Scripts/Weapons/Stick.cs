// Stick.cs. 
// 
// Vpetrov. Петров Василий Александрович. 
// 
// 2017
namespace Assets.Scripts.Weapons
{
	public class Stick : IWeapon
	{
		public float Damage { get; private set; }
		public float Cooldown { get; private set; }
		public string SpriteName { get; private set; }

		public Stick()
		{
			SpriteName = "Stick1";
			Damage = 5;
			Cooldown = 2;
		}

		public void Attack()
		{
			throw new System.NotImplementedException();
		}
	}
}