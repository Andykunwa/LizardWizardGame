using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {

	public Animation chest;
	public ParticleSystem opened;
	GemUpdate gemUpdate;
	SecretUpdate secretUpdate;
	public AudioSource success;

	// Use this for initialization
	void Start () {
		chest = GetComponent<Animation> ();
		success = GetComponent<AudioSource> ();
		gemUpdate = FindObjectOfType<GemUpdate> ();
		secretUpdate = FindObjectOfType<SecretUpdate> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnParticleCollision(GameObject other) {
		chest.Play ("Open");
		opened.Play ();
		Invoke ("deathDeletion", 3);
		success.Play ();
	}

	public void deathDeletion(){		
		Destroy (gameObject);
		gemUpdate.ScoreChest ();
		secretUpdate.ChestPing ();
	}
}
