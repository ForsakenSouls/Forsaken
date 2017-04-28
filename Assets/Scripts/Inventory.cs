using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	public GameObject inventory;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.I)) {
			if (inventory.activeSelf)
				inventory.SetActive (false);
			else
				inventory.SetActive (true);
		}
	}
}
