using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Fade : MonoBehaviour {
	public GameObject panel;
	public GameObject logo;
	public GameObject game_logo;
	//public Transform spawn;
	Color temp;
	void Start () {
		temp=panel.GetComponent<Image>().color;

	}
	void Update () {
		StartCoroutine (FadeTo (0.0f, 2.0f));
		StartCoroutine (Loadlogo ());
		//StartCoroutine (LoadMenu ());
	}
	IEnumerator FadeTo(float aValue, float aTime)	{
		float alpha = temp.a;
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime){
			Color newColor = new Color(0, 0, 0, Mathf.Lerp(alpha,aValue,t));
			temp = newColor;
			panel.GetComponent<Image>().color=temp;
			yield return null;
		}
	}
	IEnumerator LoadMenu(){
		yield return new WaitForSeconds (3.0f);
		if (PlayerPrefs.HasKey ("Finished_Level"))
			SceneManager.LoadScene (PlayerPrefs.GetInt ("Finished_Level") + 1);
		else
			SceneManager.LoadScene (1);
	}
	IEnumerator Loadlogo(){
		yield return new WaitForSeconds (2.5f);
		logo.SetActive (false);
		//Instantiate (game_logo, spawn.position, Quaternion.identity);
		game_logo.SetActive (true);
		StartCoroutine (LoadMenu ());
		}
}