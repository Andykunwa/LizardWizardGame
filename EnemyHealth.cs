using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
	[SerializeField] float health = 20f;

	public void TakeDamage(float damage){
		health = Mathf.Max(health - damage, 0);
		print (health);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
