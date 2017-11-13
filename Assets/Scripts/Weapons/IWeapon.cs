// IWeapon.cs. 
// 
// Vpetrov. Петров Василий Александрович. 
// 
// 2017
namespace Assets.Scripts.Weapons
{
	public interface IWeapon
	{
		float Damage { get; }
		float Cooldown { get; }
		string SpriteName { get; }

		void Attack();
	}
}