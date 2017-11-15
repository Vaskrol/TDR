// IAttackable.cs. 
// 
// Vpetrov. Петров Василий Александрович. 
// 
// 2017
namespace Assets.Scripts
{
	public interface IAttackable
	{
		void ReceiveDamage(float damage, DamageType type);
	}
}