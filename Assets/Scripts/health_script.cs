using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class health_script : MonoBehaviour {

    public Slider health_slider;
	// Use this for initialization
	public GameObject deathEffect;
	WizardMove playerMovement;

	void Start () {
		playerMovement = GetComponent<WizardMove> ();
	}
	
	// Update is called once per frame
	void Update () {
		//health_slider.value = (float)GameState.Player.health / GameState.Player.MAX_HEALTH;
    }

	public void addDamage(int damage) {
		if (damage <= 0)
			return;
		GameState.Player.health -= damage;
		if (GameState.Player.health <= 0) {
			makeDead ();
		}
		
	}

	public void makeDead()
	{
		Instantiate (deathEffect,transform.position, transform.rotation);
		Destroy (gameObject);
	}
}
