using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	public GameObject inventory;
    private GUIStyle guistyle = new GUIStyle();
	// Use this for initialization
	void Start () {
		
	}
    void OnGUI()
    {

        if (inventory.activeSelf)
        {
            guistyle.fontSize = 12;
            GUI.Label(new Rect(307, 93, 150, 200), GameState.Player.ToString(), guistyle);
        }
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
