// IWeapon.cs. 
// 
// Vpetrov. Петров Василий Александрович. 
// 
// 2017

using System;
using Assets.Scripts.Appearance;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
	public abstract class Weapon
	{
		public float Damage { get; set; }
		public float Speed { get; set; }
		public float Distance { get; set; }
		public string SpriteName { get; set; }
		public string AnimatorName { get; set; }
		public Vector3 Position { get; set; }
		public VisualAppearance VisualAppearance { get; set; }
		public GameObject WeaponGameObject { get; private set; }
		public GameObject Owner { get; private set; }
		public DamageType DamageType { get; set; }

		private const string _texturesPath = "Sprites/";
		private const string _animationsPath = "Animations/";
		private const float _texturePixelsPerUnit = 128f;
		private Animator _animator;

		protected Weapon(
			GameObject owner,
			string spriteName,
			float damage,
			float speed,
			float distance,
			DamageType damageType,
			Vector2? position = null,
			VisualAppearance visualAppearance = null)
		{
			Owner = owner;
			SpriteName = spriteName;
			Damage = damage;
			Speed = speed;
			Distance = distance;
			DamageType = damageType;
			Position = position ?? Vector2.zero;
			VisualAppearance = visualAppearance ?? new StaticAppearance();
		}

		protected Weapon(GameObject owner)
		{
			Owner = owner;
			DamageType = DamageType.MeleeImpact;
			Position = Vector2.zero;
			VisualAppearance = new StaticAppearance();
		}

		public abstract void Attack();

		public virtual void ProcessVisual()
		{
			VisualAppearance.Process(WeaponGameObject);
		}

		public virtual GameObject Create()
		{
			var weaponGameObject = new GameObject(SpriteName);
			weaponGameObject.transform.SetParent(Owner.transform, false);
			weaponGameObject.transform.localPosition = Position;

			var tex = Resources.Load(_texturesPath + SpriteName) as Texture2D;
			var renderer = weaponGameObject.AddComponent<SpriteRenderer>();
			renderer.sprite = Sprite.Create(
				tex, 
				new Rect(0.0f, 0.0f, tex.width, tex.height), 
				new Vector2(0.5f, 0.5f),
				_texturePixelsPerUnit);

			_animator = weaponGameObject.AddComponent<Animator>();
			_animator.runtimeAnimatorController =
				Resources.Load<RuntimeAnimatorController>(_animationsPath + AnimatorName);

			WeaponGameObject = weaponGameObject;

			return weaponGameObject;
		}

		public virtual void PlayAttackAnim()
		{
			if (_animator != null)
			{
				_animator.SetTrigger("Attack");
			}
		}
	}
}