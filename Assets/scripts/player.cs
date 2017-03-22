using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	[SerializeField]
	private stat hunger;
	//[SerializeField]
	//private stat happiness;
	// Use this for initialization
	private void Awake()
	{
		hunger.Initialize();
		//happiness.Initialize ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) {
			hunger.CurrentVal -= 10;

		}
		if (Input.GetKeyDown (KeyCode.W)) {

			hunger.CurrentVal += 10;
		}
	}

}
