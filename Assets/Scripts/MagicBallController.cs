using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBallController : MonoBehaviour {


	public float rocketSpeed;
	Rigidbody2D myRB;
	// Use this for initialization
	void Start () {
		myRB = GetComponent <Rigidbody2D> ();
		myRB.AddForce ( new Vector2(1, 0) * rocketSpeed, ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
