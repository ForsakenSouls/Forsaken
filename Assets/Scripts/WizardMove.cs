using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardMove : MonoBehaviour {

	//movement variables
	public float maxSpeed;
	Rigidbody2D myRB;
	Animator myAnim;
	bool facingRight;

	//conjure
	public Transform staff;
	public GameObject spell;
	private float spellRate = 0.5f;
	private float nextFire = 0f;

	// Use this for initialization
	void Start () {
		myRB = GetComponent<Rigidbody2D> ();
		myAnim = GetComponent<Animator> ();
		facingRight = true; 
	}

	// Update is called once per frame
	void Update()
	{
		//conjuring
		if (Input.GetAxisRaw ("Fire1") > 0)
			SaySpell ();
		
	}

	// Update is called once per second
	void FixedUpdate () {
		float move = Input.GetAxis ("Horizontal");		
		myRB.velocity = new  Vector2 (move * maxSpeed, myRB.velocity.y);
		myAnim.SetFloat ("speed", Mathf.Abs (move));

		if (move > 0 && !facingRight)
			flip ();
		else if (move < 0 && facingRight)
			flip ();
	}

	void SaySpell(){
		if (Time.time > nextFire) {
			nextFire = Time.time + nextFire;
			if (facingRight) {
				Instantiate (spell, staff.position, Quaternion.Euler (0, 0, 0));
			} else if (!facingRight) {
				Instantiate (spell, staff.position, Quaternion.Euler (0, 0, 180f));
			}
		}

	}

	void flip () {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

	}
}
