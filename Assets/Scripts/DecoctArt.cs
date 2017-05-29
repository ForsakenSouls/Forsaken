﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoctArt :MonoBehaviour, Artifact {

    int artID = 6;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && GameState.ArtID == artID)
           UseArtifact();

    }
    public void UseArtifact()
    {
        if (GameState.Player.state == states.отравлен)
            GameState.Player.state = states.здоров;
    }
}
