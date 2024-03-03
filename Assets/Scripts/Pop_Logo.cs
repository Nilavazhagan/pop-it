using UnityEngine;
using System.Collections;

public class Pop_Logo : MonoBehaviour {
	public GameObject burst_obj;
	Vector3 position;
	// Use this for initialization
	void Start () {
	
	}
	void Awake(){
		position = new Vector3 (transform.position.x - 2.5f, transform.position.y + 0.5f);
		StartCoroutine (Delayed_Die ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Delayed_Die(){
		yield return new WaitForSeconds (1.5f);
		Destroy (this.gameObject);
		Instantiate (burst_obj, position, Quaternion.identity);
	}
}
