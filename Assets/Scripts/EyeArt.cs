using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeArt : MonoBehaviour {
    public AudioClip aud;
    int artID = 3;
	void Update () {
        if (Input.GetKeyDown(KeyCode.E) && GameState.ArtID == artID)
            UseArtifact();        
    }

    void UseArtifact()
    {
        GetComponent<AudioSource>().clip = aud;
        GetComponent<AudioSource>().Play();
        GameState.paralyzed = true;
    }
}
