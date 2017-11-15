// Stick.cs. 
// 
// Vpetrov. Петров Василий Александрович. 
// 
// 2017

using Assets.Scripts.Appearance;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
	public class Stick : Weapon
	{
		public Stick(GameObject owner) : base(owner)
		{
			Damage = 5;
			Speed = 1;
			Distance = 0.5f;
			Position = new Vector3(0.15f, 0, 0);
			DamageType = DamageType.MeleeImpact;
			SpriteName = "Stick1";
			AnimatorName = "SwordAnimator";
			VisualAppearance = new LeftRightMouseAppearance();
		}

		public override void Attack()
		{
			PlayAttackAnim();

			var hitDir = WeaponGameObject.transform.right * Distance;
			if (VisualAppearance.CurrentFacing ==
			    VisualAppearance.Facing.Left)
				hitDir *= -1;

			Debug.DrawRay(WeaponGameObject.transform.position,
				hitDir, Color.green);

			var hit = Physics2D.Raycast(WeaponGameObject.transform.position, hitDir);
			if (hit.transform == null) return;
			var hitAttackable =
				hit.transform.gameObject.GetComponent<IAttackable>();
			if (hitAttackable != null)
			{
				hitAttackable.ReceiveDamage(Damage, DamageType);
			}
		}
	}
}