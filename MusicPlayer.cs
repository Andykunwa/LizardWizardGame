using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;	

public class MusicPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void LoadFirstScene () {
		SceneManager.LoadScene (1);
	}

	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			Invoke ("LoadFirstScene", .2f);
		};
	}
}
