using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtsAndSpells : MonoBehaviour {
	
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () { 
		if (Input.GetKeyDown(KeyCode.E)) 
		{ 
			switch (GameState.ArtID) 
			{ 
			case 5: { Health_Potion(); break; } 
			case 4: { Mana_Potion(); break; } 
				
			} 
		}
	} 
	void Health_Potion() 
	{ 
		GameState.Player.health += 25; 
		if (GameState.Player.health > 100) 
			GameState.Player.health = 100;		
	}
	void Mana_Potion()
	{
		GameState.Player.mana += 250; 
		if (GameState.Player.mana > 1000) 
			GameState.Player.health = 1000;	
	}
}