using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour {

	//Наш ai
	HeroClass AI;
	public int currentHealth;
	// Use this for initialization
	void Start () {
		AI = new WizardClass("Саня", false, races.орк, 99, 100, 99, 100);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addDamage(int damage)
	{
		AI.health -= damage;
		if (AI.health < 0)
			MakeDead();
	}

	public void MakeDead()
	{
		Destroy (gameObject);
	}
}
