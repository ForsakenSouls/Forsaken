using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBallHit : MonoBehaviour {

	// Use this for initialization
	float Damage;
	float ManaCost;

	MagicBallController myPC;
	public GameObject explosion;

	void Awake() {
		myPC = GetComponentInParent<MagicBallController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer ("Shootable")) {
			myPC.removeBall ();
			Destroy (gameObject);
		}
		
		
	}
}
