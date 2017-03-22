using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MinigameController : MonoBehaviour {

	public Camera cam;
	public GameObject ball;
	public float timeLeft;
	public Text timerText;

	private float maxWidth;

	// Use this for initialization
	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		float ballWidth = ball.GetComponent<Renderer>().bounds.extents.x;
		maxWidth = targetWidth.x - ballWidth;
		StartCoroutine (Spawn ());
		UpdateText ();
	}
	void Update () {
		if (timeLeft == 0){
			
            pethunger.happiness +=15;
            pethunger.savePet();
            SceneManager.LoadScene("game");
        } 
	}
	void FixedUpdate () {
		timeLeft -= Time.deltaTime;
		if (timeLeft < 0) {
			timeLeft = 0;
		}
		UpdateText ();

	}

	IEnumerator Spawn () {
		yield return new WaitForSeconds (2.0f);
		while (timeLeft > 0) {
			Vector3 spawnPosition = new Vector3 (Random.Range (-maxWidth, maxWidth), transform.position.y, 0.0f);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (ball, spawnPosition, spawnRotation);
			yield return new WaitForSeconds (Random.Range (1.0f, 2.0f));
		}
	}
	void UpdateText () {
		timerText.text = "Time Left:\n" + Mathf.RoundToInt (timeLeft);
	}
}
