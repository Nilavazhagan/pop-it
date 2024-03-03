using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pixel_Instantiate : MonoBehaviour {
	public GameObject pixel;
	public Text score_text;
	public Text intro_text;
	float time;
	bool addTime;
	public static int score;
	public static float speed = 2f;
	public static bool gameON = true;
	int last_score;
	int count;
	int side;
	Vector2 point1;
	float tempx,tempy;
	// Use this for initialization
	void Start () {
		gameON = true;
		score = 0;
		speed = 2f;
		count = SceneManager.GetActiveScene ().buildIndex - 1;
		if (SceneManager.GetActiveScene ().buildIndex == 1)
			count = 25;
		if (SceneManager.GetActiveScene ().buildIndex == 5) {
			count = 25;
			time = 60f;
			addTime = false;
			last_score = 0;
		}
		Create_Pixel ();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (score);
		if (SceneManager.GetActiveScene ().buildIndex == 5) {
			time -= Time.deltaTime;
			if (time >= 0f)
				intro_text.text = "" + Mathf.Round(time) + "s";
			if (last_score != score) {
				last_score = score;
				if (score % 10 == 0 && score != 0)
					addTime = true;
			}
			if (addTime == true) {
				addTime = false;
				time += 3f;
			}
			if (time <= 0)
				gameON = false;
		}
		if (gameON)
			score_text.text = "" + score;
		if (!gameON) {
			score_text.text = "GAME OVER\n" + score;
			if (SceneManager.GetActiveScene ().buildIndex == 2) {
				if(!PlayerPrefs.HasKey("Easy_HS") || PlayerPrefs.GetInt("Easy_HS") < score)
					PlayerPrefs.SetInt("Easy_HS",score);
			}
			if (SceneManager.GetActiveScene ().buildIndex == 3) {
				if(!PlayerPrefs.HasKey("Medium_HS") || PlayerPrefs.GetInt("Medium_HS") < score)
					PlayerPrefs.SetInt("Medium_HS",score);
			}
			if (SceneManager.GetActiveScene ().buildIndex == 4) {
				if(!PlayerPrefs.HasKey("Hard_HS") || PlayerPrefs.GetInt("Hard_HS") < score)
					PlayerPrefs.SetInt("Hard_HS",score);
			}
			if (SceneManager.GetActiveScene ().buildIndex == 5) {
				if(!PlayerPrefs.HasKey("Timed_HS") || PlayerPrefs.GetInt("Timed_HS") < score)
					PlayerPrefs.SetInt("Timed_HS",score);
			}
			StartCoroutine (Load_Menu ());
		}
	}

	void Create_Pixel(){
		if (gameON) {

			if (SceneManager.GetActiveScene ().buildIndex == 2) {
				if (!PlayerPrefs.HasKey ("Easy_HS") || PlayerPrefs.GetInt ("Easy_HS") < 2) {
					if(score == 0)
						intro_text.text = "Pop it!";
					if (score == 1)
						intro_text.text = "Don't Miss it!";
					if (score > 1)
						intro_text.text = "";
				}
			}
			if (SceneManager.GetActiveScene ().buildIndex == 3) {
				if (!PlayerPrefs.HasKey ("Medium_HS") || PlayerPrefs.GetInt ("Medium_HS") < 2) {
					if(score == 0)
						intro_text.text = "Pop 'em!";
					if (score == 1)
						intro_text.text = "Don't Miss 'em!";
					if (score > 1)
						intro_text.text = "";
				}
			}
			if (SceneManager.GetActiveScene ().buildIndex == 4) {
				if (!PlayerPrefs.HasKey ("Hard_HS") || PlayerPrefs.GetInt ("Hard_HS") < 2) {
					if(score == 0)
						intro_text.text = "Pop 'em!";
					if (score == 1)
						intro_text.text = "Don't Miss 'em!";
					if (score > 1)
						intro_text.text = "";
				}
			}

			for (int i = 0; i < count; i++) {
				side = Random.Range (1, 4);
				switch (side) {
				case 1: //left
					tempx = -3.9f;
					tempy = Random.Range (-5.2f, 5.2f);
					break;
				case 2: //right
					tempx = 3.9f;
					tempy = Random.Range (-5.4f, 5.4f);
					break;
				case 3: //top
					tempx = Random.Range (-3.6f, 3.6f);
					tempy = 5.5f;
					break;
				case 4: //bottom
					tempx = Random.Range (-3.6f, 3.6f);
					tempy = -5.5f;
					break;
				}
				point1 = new Vector2 (tempx, tempy);
				Instantiate (pixel, point1, Quaternion.identity);
			}
			StartCoroutine (Delay ()); 
		}
	}

	IEnumerator Delay(){
		yield return new WaitForSeconds (5f);
		Create_Pixel ();
	}

	IEnumerator Load_Menu(){
		yield return new WaitForSeconds (5f);
		SceneManager.LoadScene (1);
	}
}
