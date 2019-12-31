using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecretUpdate : MonoBehaviour {

	[SerializeField] int secretPing = 1;

	int secrets = 0;
	Text secretText;

	// Use this for initialization
	void Start () {
		secretText = GetComponent<Text> ();
		secretText.text = "Secrets Found: " + secrets.ToString ();
	}

	public void ChestPing(){
		secrets = secrets + secretPing;
		secretText.text = "Secrets Found: " + secrets.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
