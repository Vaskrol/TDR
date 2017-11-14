// BasicPlayerMoving.cs. 
// 
// Vpetrov. Петров Василий Александрович. 
// 
// 2017

using System;
using UnityEngine;

namespace Assets.Scripts.Moving
{
	public class BasicPlayerMoving : Moving
	{
		private readonly GameObject _player;
		
		public BasicPlayerMoving(
			GameObject player,
			float speed = 0)
		{
			_player = player;
			Speed = speed;
		}

		public override void Process()
		{
			var hAxis = Input.GetAxis("Horizontal");
			var vAxis = Input.GetAxis("Vertical");

			if (Math.Abs(hAxis) < 0.001f) return;

			var moving =
				new Vector2(hAxis, vAxis)
				* Speed
				* Time.deltaTime;

			_player.transform.Translate(moving);
		}
	}
}