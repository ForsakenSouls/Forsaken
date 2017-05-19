using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mana_script : MonoBehaviour {

    public Slider mana_slider;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame

	void Update () {
        mana_slider.value = (float)GameState.Player.mana / GameState.Player.MAX_MANA;
    }
}
