using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealSpell : MonoBehaviour {

    int artID = 7;
	void Update () {
		 if (Input.GetKeyDown(KeyCode.E) && GameState.ArtID == artID)
                Spell();
	}

    void Spell()
    {
        if (GameState.Player.mana >= 300)
        {
            GameState.Player.mana -= 300;
            GameState.Player.health += 20;
            if (GameState.Player.health > 100)
                GameState.Player.health = 100;
        }
    }
}
