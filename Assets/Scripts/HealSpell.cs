﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealSpell : MonoBehaviour, Spell {
    public AudioClip aud;
    int artID = 7;
    int manacost = 300;
	void Update () {
		 if (Input.GetKeyDown(KeyCode.E) && GameState.ArtID == artID)
                Cast();
	}

    public void Cast()
    {
        if (GameState.Player.mana >= manacost)
        {
            GetComponent<AudioSource>().clip = aud;
            GetComponent<AudioSource>().Play();
            GameState.Player.mana -= manacost;
            GameState.Player.health += 20;
            if (GameState.Player.health > 100)
                GameState.Player.health = 100;
        }
    }
}
