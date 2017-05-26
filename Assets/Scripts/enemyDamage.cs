using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour {

	public int damage;
	public int damageRate;
	public int pushBackForce;

	float nextDamage;
	// Use this for initialization
	void Start () {
		nextDamage = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void onTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Player" && nextDamage < Time.time) {
			health_script health = GetComponent<health_script> ();
			health.addDamage (damage);
			nextDamage = Time.time + damageRate;

			pushBack (other.transform);
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
