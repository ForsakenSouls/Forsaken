using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionArt : MonoBehaviour, Artifact {
    public AudioClip aud;
    int artID = 5;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && GameState.ArtID == artID)
            UseArtifact();

    }
    public void UseArtifact()
    {
        GetComponent<AudioSource>().clip = aud;
        GetComponent<AudioSource>().Play();
        GameState.Player.health += 25;
        if (GameState.Player.health > 100)
            GameState.Player.health = 100;
    }
}
