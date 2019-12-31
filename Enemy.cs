using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	
	[SerializeField] float maxHits = 3;
	public AudioSource hurtVoice;
	public Animator enemyAnimations;
	public Patrol patroller;
	public GameObject player;
	public int moveSpeed = 8;
	private bool withinDistance = false;
	public bool nullifyUpdate = false;
	GemUpdate gemUpdate;

	// Use this for initialization
	void Start () {
		gemUpdate = FindObjectOfType<GemUpdate> ();
		enemyAnimations = GetComponent<Animator> ();
		patroller = GetComponent<Patrol> ();
		hurtVoice = GetComponent<AudioSource> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		enemyAnimations.Play ("walk");
	}
	
	// Update is called once per frame
	void Update () {
		if (nullifyUpdate == false) 
		{
			if (Vector3.Distance(transform.position, player.transform.position) < 25f && Vector3.Distance(transform.position, player.transform.position) > 2f) {
				withinDistance = true;
				patroller.enabled = false;
				enemyAnimations.Play ("attack2");
				transform.LookAt (player.transform.position);
				transform.position += transform.forward * moveSpeed * Time.deltaTime;
			}

			if (Vector3.Distance (transform.position, player.transform.position) < 2f) {
				enemyAnimations.Play ("attack1");
			}
		}
	}

	//ON HIT AND DEATH SEQUENCE//

	void OnParticleCollision(GameObject other){
		maxHits--;
		enemyAnimations.Play ("hit1");
		if (maxHits <= 0) 
		{
			patroller.enabled = false;
			if (null != enemyAnimations) {
				nullifyUpdate = true;
				enemyAnimations.Play ("death1");
				hurtVoice.Play ();
			}
			Invoke ("deathDeletion", 1);
		}
	}

	public void deathDeletion(){
		Destroy (gameObject);
		gemUpdate.ScoreGems ();
	}
}