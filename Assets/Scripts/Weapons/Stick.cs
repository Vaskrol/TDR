// Stick.cs. 
// 
// Vpetrov. Петров Василий Александрович. 
// 
// 2017

using System;
using System.Collections;
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
			Position = new Vector2(0.15f, 0);
			SpriteName = "Stick1";
			VisualAppearance = new LeftRightMouseAppearance();
		}

		public override void Attack()
		{
			Debug.DrawRay(GameObject.transform.position,
				GameObject.transform.right, Color.green);
		}
	}
}