using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
	public float Speed;

	private GameObject _currentWeapon;
	private List<GameObject> _visuals;
	private Facing _facing;

	void Start()
	{
		_facing = Facing.Right;
		_visuals = new List<GameObject>();
		_visuals.Add(gameObject);

		_currentWeapon = transform.Find("Weapon").gameObject;
		_visuals.Add(_currentWeapon);
	}

	void Update ()
	{
		var hAxis = Input.GetAxis("Horizontal");
		var vAxis = Input.GetAxis("Vertical");
		var moving = 
			new Vector2(hAxis, vAxis) 
			* Speed
			* Time.deltaTime;

		transform.Translate(moving);

		var mouseAim = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		if (mouseAim.x < transform.position.x && _facing == Facing.Right)
		{
			_facing = Facing.Left;
			foreach (var visual in _visuals)
			{
				FlipVisual(visual);
			}
		}
		else if (mouseAim.x > transform.position.x && _facing == Facing.Left)
		{
			_facing = Facing.Right;
			foreach (var visual in _visuals)
			{
				FlipVisual(visual);
			}
		}
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

	private enum Facing
	{
		Left,
		Right
	}
}
