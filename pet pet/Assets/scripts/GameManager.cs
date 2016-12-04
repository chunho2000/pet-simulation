using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject HungerText;
	public GameObject HappinessText;

	public GameObject namePanel;
	public GameObject nameInput;
	public GameObject NameText;

	public GameObject foodPanel;
	public Sprite[] foodIcons;

	public GameObject pet;
	public GameObject bread;
	public GameObject candy;
	public int hunger;



	void Update () {
		HungerText.GetComponent<Text>().text =pet.GetComponent<pethunger> ().hunger.ToString();
		HappinessText.GetComponent<Text>().text =pet.GetComponent<pethunger> ().happiness.ToString();
		NameText.GetComponent<Text> ().text = pet.GetComponent<pethunger> ().name;

	    


	}

	public void triggerNamePanel (bool b){
		namePanel.SetActive (!namePanel.activeInHierarchy);

		if (b) {
			pet.GetComponent<pethunger> ().name = nameInput.GetComponent<InputField> ().text;
			PlayerPrefs.SetString ("name", pet.GetComponent<pethunger> ().name);
		}
			
	}

	public void buttonBehaviour(int i){
		switch (i) {
		case(0):
		default:

			break;
		case(1):
			GameObject.Find ("pet").GetComponent<pethunger> ().hunger += 10;
			break;
		case(2):
			foodPanel.SetActive (!foodPanel.activeInHierarchy);
			break;
		case(3):
			GameObject.Find ("pet").GetComponent<pethunger> ().hunger += 5;
			break;
		case(4):
			pet.GetComponent<pethunger> ().savePet ();
			Application.Quit();
			break;
			
		}


	}
	public void toggle(GameObject g){
		if (g.activeInHierarchy)
			g.SetActive (false);
	}
	public void selectFood(int i){
        toggle (foodPanel);
	}

}
