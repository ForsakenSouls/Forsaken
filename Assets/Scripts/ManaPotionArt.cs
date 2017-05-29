using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPotionArt : MonoBehaviour {
    public AudioClip aud;
    int artID = 4;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && GameState.ArtID == artID)
            UseArtifact();

    }
    public void UseArtifact()
    {
        GetComponent<AudioSource>().clip = aud;
        GetComponent<AudioSource>().Play();
        GameState.Player.mana += 250;
        if (GameState.Player.mana > 1000)
            GameState.Player.mana = 1000;
    }
}
