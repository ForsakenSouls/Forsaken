using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class health_script : MonoBehaviour {

	public Slider health_slider;
	public Image damageScreen;
	Color damagedColor = new Color (0f, 0f, 0f, 0.5f);
	float averageColor = 5f;
	// Use this for initialization
	public GameObject deathEffect;
	WizardMove playerMovement;


	void Start () {
		playerMovement = GetComponent<WizardMove> ();
	}

    // Update is called once per frame
    void Update()
    {
        health_slider.value = (float)GameState.Player.health / GameState.Player.MAX_HEALTH;
        if (GameState.damaged)
        {
            damageScreen.color = damagedColor;
        }
        else
        {
            damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, averageColor * Time.deltaTime);
        }
        GameState.damaged = false;
        if (GameState.Player.health <= 0)
        {
            SceneManager.LoadScene("MenuScene");
        }
	}

	public void addDamage(int damage) {
		if (damage <= 0)
			return;
		GameState.Player.health -= damage;
		if (GameState.Player.health <= 0) {
			makeDead ();
		}

	}

	public void makeDead()
	{
		Instantiate (deathEffect,transform.position, transform.rotation);
		Destroy (gameObject);
	}
}
