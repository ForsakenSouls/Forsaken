using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

	Rigidbody2D enemyRB;
	bool charging = false;
	Animator enemyAnim;
	public float speed;
	// Use this for initialization
	void Start () {
		enemyAnim = GetComponentInChildren<Animator> ();
		enemyRB = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		charging = true;
		enemyAnim.SetBool ("isCharging", charging);
		enemyRB.AddForce (new Vector2 (-1, 0) * speed);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
		}
	}
}
