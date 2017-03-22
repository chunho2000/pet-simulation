using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public GameObject pet;
	public GameObject flashtext;
	public GameObject namePanel;
	public GameObject nameInput;
	public GameObject NameText;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("flashTheText", 0f, 0.5f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonUp (0)) {
			SceneManager.LoadScene ("game");
		}
	}
	void flashTheText() {
		if (flashtext.activeInHierarchy)
			flashtext.SetActive (false);
		else
			flashtext.SetActive (true);

	}

	public void triggerNamePanel (bool b){
		namePanel.SetActive (!namePanel.activeInHierarchy);

		if (b) {
			pet.GetComponent<pethunger> ().name = nameInput.GetComponent<InputField> ().text;
			PlayerPrefs.SetString ("name", pet.GetComponent<pethunger> ().name);
		}
	}
}
