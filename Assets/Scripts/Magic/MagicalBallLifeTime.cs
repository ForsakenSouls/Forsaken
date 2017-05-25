using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicalBallLifeTime : MonoBehaviour {

	//уничтожает объект через определенное количество времени
	public float LifeTime;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, LifeTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
