using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public GameObject flashtext;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("flashTheText", 0f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp(0))
			SceneManager.LoadScene ("game");
	}
	void flashTheText() {
		if (flashtext.activeInHierarchy)
			flashtext.SetActive (false);
		else
			flashtext.SetActive (true);

	}
}
