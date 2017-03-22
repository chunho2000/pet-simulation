using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappinessBarPlayer : MonoBehaviour {
	[SerializeField]
	private HappinessBarStat happiness;

	private void Awake(){

		 happiness.Initialize ();
	}
	void Update () {
		
	}
}
