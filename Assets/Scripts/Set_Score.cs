using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Set_Score : MonoBehaviour {
	public Text Easy_score, Medium_score, Hard_score, Timed_score;

	// Use this for initialization
	void Awake () {
		if (PlayerPrefs.HasKey ("Easy_HS"))
			Easy_score.text = "" + PlayerPrefs.GetInt ("Easy_HS");
		if (PlayerPrefs.HasKey ("Medium_HS"))
			Medium_score.text = "" + PlayerPrefs.GetInt ("Medium_HS");
		if (PlayerPrefs.HasKey ("Hard_HS"))
			Hard_score.text = "" + PlayerPrefs.GetInt ("Hard_HS");
		if (PlayerPrefs.HasKey ("Timed_HS"))
			Timed_score.text = "" + PlayerPrefs.GetInt ("Timed_HS");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
