using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Attack : MonoBehaviour {
	//[SerializeField] float weaponDamage = 5f;
	public ParticleSystem particles;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			particles.Play ();
		}

		if (Input.GetMouseButtonUp (0)) {
			particles.Stop ();
		}
	}
}
