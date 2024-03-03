using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Pixel_Control : MonoBehaviour {
	public GameObject burst;
	public float speed = 20f;
	int side;
	Vector2 point1;
	Vector2 point2;
	float tempx,tempy;
	// Use this for initialization
	void Awake () {
		speed = Pixel_Instantiate.speed;
		if (this.transform.position.x < -3.8)
			side = 1;
		else if (this.transform.position.x > 3.8)
			side = 2;
		else if (this.transform.position.y > 5.4)
			side = 3;
		else if (this.transform.position.y > -5.4)
			side = 4;
		if (side == 1 || side == 2) {
			tempx = -this.transform.position.x;
			tempy = Random.Range (-5.2f, 5.2f);
		} else {
			tempx = Random.Range (-3.6f, 3.6f);
			tempy = -this.transform.position.y;
		}
		point2 = new Vector2 (tempx, tempy);
		transform.position = Vector2.MoveTowards(transform.position, point2,speed*Time.deltaTime);
	}

	
	// Update is called once per frame
	void Update () {
		transform.position = Vector2.MoveTowards(transform.position, point2,speed*Time.deltaTime);
		if (SceneManager.GetActiveScene ().buildIndex != 1 && SceneManager.GetActiveScene ().buildIndex != 5) {
			switch (side) {
			case 1:
				if (transform.position.x >= 3.8f)
					Pixel_Instantiate.gameON = false;
				break;
			case 2:
				if (transform.position.x <= -3.8f)
					Pixel_Instantiate.gameON = false;
				break;
			case 3:
				if (transform.position.y <= -5.4f)
					Pixel_Instantiate.gameON = false;
				break;
			case 4:
				if (transform.position.y >= 5.4f)
					Pixel_Instantiate.gameON = false;
				break;
			}
		}
	}
	void OnMouseOver(){
		if (SceneManager.GetActiveScene ().buildIndex != 1) {
			if (Input.GetMouseButtonDown (0)) {
				Pixel_Instantiate.score++;
				Pixel_Instantiate.speed += Pixel_Instantiate.speed * 0.02f;
				Destroy (this.gameObject);
				Instantiate (burst, transform.position, Quaternion.identity);
			}
		}
	}
}