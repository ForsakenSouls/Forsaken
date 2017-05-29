using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeArt : MonoBehaviour {

    int artID = 3;
	void Update () {
        if (Input.GetKeyDown(KeyCode.E) && GameState.ArtID == artID)
            Eye_Potion();        
    }

    void Eye_Potion()
    {
        GameState.paralyzed = true;
    }
}
