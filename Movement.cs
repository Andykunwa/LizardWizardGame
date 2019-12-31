using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float speedH = 2.0f;
	public float speedV = 2.0f;
	private float yaw = 0.0f;
	private float pitch = 0.0f;
	public float coolDown = 11;
	public float teleCoolDown = 10;
	public float coolDownTimer;
	public float teleCoolDownTimer;
	public ParticleSystem jumpParticles;
	public ParticleSystem teleportParticles;
	public AudioSource teleportSound;

	// Use this for initialization
	void Start () 
	{

	}

	public void coolDownDelay() {
		coolDownTimer = coolDown;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey (KeyCode.W)) {				
			transform.Translate (0f, 0f, 8f * Time.deltaTime);
			GetComponent<Animation>().CrossFade ("Run");
		}
		else
			GetComponent<Animation>().CrossFade ("Idle");

		if (Input.GetKey (KeyCode.S)) {
			transform.Translate (0f, 0f, -8f * Time.deltaTime);
			GetComponent<Animation>().CrossFade ("Walk");
		}

		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (-8f * Time.deltaTime, 0f, 0f);
			GetComponent<Animation>().CrossFade ("Run");
		}

		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (8f * Time.deltaTime, 0f, 0f);
			GetComponent<Animation>().CrossFade ("Run");
		}

		if (Input.GetKey (KeyCode.Space)) {
			transform.Translate (0f, 12f * Time.deltaTime, 0f);
			GetComponent<Animation> ().CrossFade ("Idle");
		}

		if (Input.GetMouseButton (1)) {
			yaw += speedH * Input.GetAxis ("Mouse X");
			pitch -= speedV * Input.GetAxis ("Mouse Y");
			transform.eulerAngles = new Vector3 (pitch, yaw, 0.0f);
		}

		if (Input.GetMouseButton (0)) {						
			GetComponent<Animation> ().CrossFade ("Attack01");
		}

		///////////////////////////ROCKET JUMP ABILITY////////////////////////////

		if (coolDownTimer > 0) {
			coolDownTimer -= Time.deltaTime;
		}
		if (coolDownTimer < 0) {
			coolDownTimer = 0;
		}
		if (Input.GetKey (KeyCode.E) && coolDownTimer == 0) {
			transform.Translate (0f, 24f * Time.deltaTime, 0f);
			jumpParticles.Play ();
			Invoke ("coolDownDelay", 4);
		}

		/////////////////////////TELEPORT ABILITY/////////////////////////////////

		if (teleCoolDownTimer > 0) {
			teleCoolDownTimer -= Time.deltaTime;
		}
		if (teleCoolDownTimer < 0) {
			teleCoolDownTimer = 0;
		}
		if (Input.GetKey (KeyCode.Q) && teleCoolDownTimer == 0) {
			transform.position += transform.forward * 24f;
			teleportParticles.Play ();
			teleportSound.Play ();
			teleCoolDownTimer = teleCoolDown;
		}
	}
}
