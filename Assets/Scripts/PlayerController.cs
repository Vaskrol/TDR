using System.Collections.Generic;
using Assets.Scripts;
using Assets.Scripts.Appearance;
using Assets.Scripts.Moving;
using Assets.Scripts.Weapons;
using UnityEngine;

public class PlayerController : MonoBehaviour, IAttackable
{
	public float Speed;
	public float HP;
	private Moving _moving;
	private Weapon _weapon;
	private VisualAppearance _visualAppearance;

	void Start()
	{
		HP = 20;

		_moving = new BasicPlayerMoving(gameObject, 5f);
		_weapon = new Stick(gameObject);
		_weapon.Create();
		_visualAppearance = new LeftRightMouseAppearance();

	}

	void Update ()
	{
		_moving.Process();
		_visualAppearance.Process(gameObject);
		_weapon.ProcessVisual();

		if (Input.GetMouseButtonDown(0))
			_weapon.Attack();
	}


	public void ReceiveDamage(float damage, DamageType type)
	{
		HP -= damage;
		if (HP <= 0)
			OnDeath();
	}

	public void OnDeath()
	{
		Debug.Log("Player killed!");
	}
}
