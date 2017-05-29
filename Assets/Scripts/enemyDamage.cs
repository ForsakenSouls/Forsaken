﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour {

	public int damage;
	public int damageRate;
	public int pushBackForce;

	float nextDamage;
	float delayTime;
	// Use this for initialization
	void Start () {
		nextDamage = 0f;
		delayTime = 1f;
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" && !GameState.Invaluable) {
			GameState.Player.health -= damage;
			GameState.damaged = true;
			if (GameState.Player.health <= 10)
			{
				GameState.Player.state = states.ослаблен;
			}
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Player" && nextDamage < Time.time && !GameState.Invaluable) {
			nextDamage = Time.time + delayTime;
			GameState.damaged = true;
			GameState.Player.health -= damage;
		}
	}

	void pushBack(Transform pushObject)
	{
		Vector2 pushDirection = new Vector2 (pushObject.position.x - transform.position.x, 0).normalized;
		pushDirection *= pushBackForce;
		Rigidbody2D pushRB = pushObject.gameObject.GetComponent<Rigidbody2D> ();
		pushRB.velocity = Vector2.zero;
		pushRB.AddForce (pushDirection, ForceMode2D.Impulse);
	}
}
