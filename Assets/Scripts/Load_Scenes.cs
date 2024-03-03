using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Load_Scenes : MonoBehaviour {

	public void Load_Easy(){
		SceneManager.LoadScene (2);
	}

	public void Load_Medium(){
		SceneManager.LoadScene (3);
	}

	public void Load_Hard(){
		SceneManager.LoadScene (4);
	}

	public void Load_Timed(){
		SceneManager.LoadScene (5);
	}

}
