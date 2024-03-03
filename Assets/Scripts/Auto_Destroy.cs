using UnityEngine;
using System.Collections;

public class Auto_Destroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void Awake(){
		StartCoroutine (Die ());
	}

	// Update is called once per frame
	void Update () {
	
	}
	IEnumerator Die(){
		yield return new WaitForSeconds (2f);
		Destroy (this.gameObject);
	}
}
