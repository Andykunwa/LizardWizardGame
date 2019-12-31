using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemUpdate : MonoBehaviour {

	[SerializeField] int gemsPerKill = 15;
	[SerializeField] int gemsPerChest = 100;

	int gems = 0;
	Text gemText;

	// Use this for initialization
	void Start () {
		gemText = GetComponent<Text> ();
		gemText.text = "Gems: " + gems.ToString ();
	}

	public void ScoreGems(){
		gems = gems + gemsPerKill;
		gemText.text = "Gems: " + gems.ToString ();
	}
	public void ScoreChest(){
		gems = gems + gemsPerChest;
		gemText.text = "Gems: " + gems.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
