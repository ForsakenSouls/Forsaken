using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBallController : MonoBehaviour {

	// скорость магического шара
	public float rocketSpeed;
	// шар
	Rigidbody2D myRB;
	// выстрел
	void Awake () {
		myRB = GetComponent <Rigidbody2D> ();
		if(transform.localRotation.z > 0)
			myRB.AddForce ( new Vector2(-1, 0) * rocketSpeed, ForceMode2D.Impulse);
		else
			myRB.AddForce ( new Vector2(1, 0) * rocketSpeed, ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		GameState.Player.mana -= 1;
	}

	// удаление шара
	public void removeBall()
	{
		myRB.velocity = new Vector2 (0, 0);


	}
}
