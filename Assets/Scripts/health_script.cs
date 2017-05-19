using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class health_script : MonoBehaviour {

    public Slider health_slider;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		health_slider.value = (float)GameState.Player.health / GameState.Player.MAX_HEALTH;
    }
}
