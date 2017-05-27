using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldActive : MonoBehaviour {

	public GameObject Shield;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (GameState.Invaluable)
			Shield.SetActive (true);
		else
			Shield.SetActive (false);
	}
}
