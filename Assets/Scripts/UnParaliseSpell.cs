using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnParaliseSpell : MonoBehaviour, Spell {
    int artID = 10;
    int manacost = 150;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && GameState.ArtID == artID)
            Cast();
    }

    public void Cast()
    {
        GameState.Player.mana -= manacost;
        if (GameState.Player.state == states.парализован)
            GameState.Player.state = states.здоров;
    }
}
