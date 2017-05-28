using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionArt : MonoBehaviour {

    int artID = 5;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && GameState.ArtID == artID)
            Health_Potion();

    }
    void Health_Potion()
    {
        GameState.Player.health += 25;
        if (GameState.Player.health > 100)
            GameState.Player.health = 100;
    }
}
