using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUpdate : MonoBehaviour {

	int health = 100;
	[SerializeField] int healthTick = 10;
	Text startHealth;

	// Use this for initialization
	void Start () {
		startHealth = GetComponent<Text> ();
		startHealth.text = "Health: " + health.ToString ();
	}

	public void HealthPing(){
		health = health - healthTick;
		startHealth.text = "Health: " + health.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
