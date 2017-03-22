using UnityEngine;
using System;
using System.Collections;

public class pethunger : MonoBehaviour {
   
    public static int _hunger;
    
    public static int _happiness;
	[SerializeField]
	private string _name;

	private bool _serverTime;
	private int _clickCount;

	void Start () {
	//PlayerPrefs.SetString ("then", "11/17/2016 10:22:12");
		UpdateStatus ();
		if (!PlayerPrefs.HasKey ("name"))
			PlayerPrefs.SetString ("name", "pethunger");
		_name = PlayerPrefs.GetString ("name");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp (0)) {
			//Debug.Log ("Clicked");
			Vector2 v = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
			RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint(v), Vector2.zero);
			if (hit){
				//Debug.Log (hit.transform.gameObject.name);
				if(hit.transform.gameObject.name == "pet"){
					_clickCount++;
					if (_clickCount >= 3) {
						_clickCount = 0;
						updateHappiness (1);

					}
				}

			}
		}
	
		if (hunger >= 100)
			hunger = 100;
	}

    [ContextMenu("hjkhkl")]
    void hapdsfads()
    {
        pethunger.happiness -= 10;
        pethunger.hunger -= 10;

    }
	void UpdateStatus () {
		if (!PlayerPrefs.HasKey ("_hunger")) {
			_hunger = 100;
			PlayerPrefs.SetInt ("_hunger", _hunger);
		} else {
			_hunger = PlayerPrefs.GetInt ("_hunger");
		if (!PlayerPrefs.HasKey ("_happiness")) {
				_happiness = 100;
				PlayerPrefs.SetInt ("_happiness", _happiness);
			} else {
				_happiness = PlayerPrefs.GetInt ("_happiness");}
		}
			
		TimeSpan ts = getTimeSpan ();
		_hunger -= (int)(ts.TotalHours * 2);
		if (_hunger < 0)
			_hunger = 0;
		_happiness-= (int)((100-_hunger) * (ts.TotalHours/5));
		if (_happiness < 0)
			_happiness = 0;

		if(!PlayerPrefs.HasKey("then"))
			PlayerPrefs.SetString("then",getStringTime());

		//Debug.Log (getTimeSpan ().ToString ());

		if (_serverTime)
			UpdateServer ();
		else
			InvokeRepeating ("UpdateDevice", 0f, 30f);

	}
	void UpdateServer() {
	}
	void UpdateDevice() {
		PlayerPrefs.SetString ("then", getStringTime ());
	}

	TimeSpan getTimeSpan (){
		if (_serverTime)
			return new TimeSpan ();
		else
			return DateTime.Now - Convert.ToDateTime(PlayerPrefs.GetString("then",DateTime.Now.ToString()));
	}


	string getStringTime(){
		DateTime now = DateTime.Now;
		return now.Month + "/" + now.Day + "/" + now.Year + " " + now.Hour + ":" + now.Minute + ":" + now.Second;
	}


	public static int hunger {
		get{ return _hunger; }
		set{_hunger = value;}
	}
	public static int happiness {
		get{ return _happiness;}
		set{_happiness = value;}
	}
	public static void savePet(){
        PlayerPrefs.SetString("then", DateTime.Now.ToString());
        PlayerPrefs.SetInt ("_hunger", _hunger);
		PlayerPrefs.SetInt ("_happiness", _happiness);

	}
	public void updateHappiness(int i){
		happiness += i;
		if (happiness >= 100)
			happiness = 100;


	}
	public string name{
		get {return _name;}
		set {_name = value;}

	}

}
      