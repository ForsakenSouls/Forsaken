using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPotionArt : MonoBehaviour {

    int artID = 4;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && GameState.ArtID == artID)
           Mana_Potion();

    }
    void Mana_Potion()
    {
        GameState.Player.mana += 250;
        if (GameState.Player.mana > 1000)
            GameState.Player.mana = 1000;
    }
}
