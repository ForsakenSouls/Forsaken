using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoctArt : MonoBehaviour {

    int artID = 6;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && GameState.ArtID == artID)
            Decoct_Potion();

    }
    void Decoct_Potion()
    {
        if (GameState.Player.state == states.отравлен)
            GameState.Player.state = states.здоров;
    }
}
