using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreatSpell : MonoBehaviour {

    int artID = 8;
    int manacost = 100;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && GameState.ArtID == artID)
            Cast();
    }

    public void Cast()
    {
        GameState.Player.mana -= manacost;
        if (GameState.Player.state == states.ослаблен)
            GameState.Player.state = states.здоров;
    }
}
