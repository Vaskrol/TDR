// IWeapon.cs. 
// 
// Vpetrov. Петров Василий Александрович. 
// 
// 2017

using Assets.Scripts.Appearance;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
	public abstract class Weapon
	{
		public float Damage { get; set; }
		public float Speed { get; set; }
		public string SpriteName { get; set; }
		public Vector2 Position { get; set; }
		public VisualAppearance VisualAppearance { get; set; }
		public GameObject GameObject { get; private set; }
		public GameObject Owner { get; private set; }

		private const string _texturesPath = "Sprites/";
		private const float _texturePixelsPerUnit = 128f;

		protected Weapon(
			GameObject owner,
			string spriteName,
			float damage,
			float speed,
			Vector2? position = null,
			VisualAppearance visualAppearance = null)
		{
			Owner = owner;
			SpriteName = spriteName;
			Damage = damage;
			Speed = speed;
			Position = position ?? Vector2.zero;
			VisualAppearance = visualAppearance ?? new StaticAppearance();
		}

		protected Weapon(GameObject owner)
		{
			Owner = owner;
			Position = Vector2.zero;
			VisualAppearance = new StaticAppearance();
		}

		public abstract void Attack();

		public virtual void ProcessVisual()
		{
			VisualAppearance.Process(GameObject);
		}

		public virtual GameObject Create()
		{
			var gameObject = new GameObject(SpriteName);
			gameObject.transform.SetParent(Owner.transform, true);
			gameObject.transform.localPosition = Position;

			var tex = Resources.Load(_texturesPath + SpriteName) as Texture2D;
			var renderer = gameObject.AddComponent<SpriteRenderer>();
			renderer.sprite = Sprite.Create(
				tex, 
				new Rect(0.0f, 0.0f, tex.width, tex.height), 
				new Vector2(0.5f, 0.5f),
				_texturePixelsPerUnit);
			GameObject = gameObject;

			return gameObject;
		}
	}
}