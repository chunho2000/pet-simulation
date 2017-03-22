using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public GameObject HungerText;
	public GameObject HappinessText;

	public GameObject namePanel;
	public GameObject nameInput;
	public GameObject NameText;

	public GameObject foodPanel;
	public Sprite[] foodIcons;
	public GameObject pet;
	public int hunger;




	void Update () {
		HungerText.GetComponent<Text>().text = pethunger.hunger.ToString();
       
		HappinessText.GetComponent<Text>().text =pethunger.happiness.ToString();


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
            GetComponent<AudioSource>().Play();

                pethunger.savePet();
                SceneManager.LoadScene ("Minigame1");
            break;
		case(2):
               GetComponent<AudioSource>().Play();
                foodPanel.SetActive (!foodPanel.activeInHierarchy);
			break;
		case(3):
			pethunger.hunger += 5;
                GetComponent<AudioSource>().Play();
			break;
		case(4):
                GetComponent<AudioSource>().Play();
               pethunger.savePet ();
			Application.Quit();
			break;
		case(5):
                GetComponent<AudioSource>().Play();
                pethunger.savePet();
                SceneManager.LoadScene ("Minigame2");
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
