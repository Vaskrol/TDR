// BasicPlayerMoving.cs. 
// 
// Vpetrov. Петров Василий Александрович. 
// 
// 2017

using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Moving
{
	public class BasicPlayerMoving : IMoving
	{
		public float Speed;

		private GameObject _player;
		private List<GameObject> _visuals;
		private Facing _facing;

		public BasicPlayerMoving(GameObject player)
		{
			_facing = Facing.Right;
			_visuals = new List<GameObject>();
			_player = player;
			_visuals.Add(_player);

			var currentWeapon = player.transform.Find("Weapon").gameObject;
			
			_visuals.Add(currentWeapon);
		}

		public void Process()
		{
			var hAxis = Input.GetAxis("Horizontal");
			var vAxis = Input.GetAxis("Vertical");
			var moving =
				new Vector2(hAxis, vAxis)
				* Speed
				* Time.deltaTime;

			_player.transform.Translate(moving);

			var mouseAim = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			if (mouseAim.x < _player.transform.position.x && _facing == Facing.Right)
			{
				_facing = Facing.Left;
				foreach (var visual in _visuals)
				{
					FlipVisual(visual);
				}
			}
			else if (mouseAim.x > _player.transform.position.x && _facing == Facing.Left)
			{
				_facing = Facing.Right;
				foreach (var visual in _visuals)
				{
					FlipVisual(visual);
				}
			}
		}

		private enum Facing
		{
			Left,
			Right
		}

		private void FlipVisual(GameObject go)
		{
			go.GetComponent<SpriteRenderer>().flipX =
				!go.GetComponent<SpriteRenderer>().flipX;

			if (go.name == "Player")
				return;

			go.transform.localPosition =
				new Vector3(
					-go.transform.localPosition.x,
					go.transform.localPosition.y,
					go.transform.localPosition.z);
		}
	}
}