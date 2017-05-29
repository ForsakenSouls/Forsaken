using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeArt : MonoBehaviour {

    int artID = 3;
	void Update () {
        if (Input.GetKeyDown(KeyCode.E) && GameState.ArtID == artID)
            UseArtifact();        
    }

    void UseArtifact()
    {
        GameState.paralyzed = true;
    }
}
