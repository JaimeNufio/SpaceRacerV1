using UnityEngine;
using System.Collections;

public class AlienShip : MonoBehaviour {

	float piCount = 0,health = 8,timer,timermax = 1.5f;
	public GameObject round;

	// Use this for initialization
	void Start () {

	}

	void spawn(){
		GameObject clone = (GameObject)Instantiate (round,transform.position-new Vector3(0,0,-4),transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		piCount += Mathf.PI / 360;
		if (piCount > 20 * Mathf.PI) {
			piCount = 0;
		}
		transform.position = new Vector3 (3*(piCount/5)-5,Mathf.Cos(piCount*5)+3,-5);

		if (health <= 0) {
			piCount = 0;
			health = 8;
		}

		timer += Time.deltaTime;

		if (timer > timermax) {
			timer = 0;
			spawn ();
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.transform.position.y < 5.2 && other.tag == "bullet") {
			health -= Game_.damage;
			Destroy (other.gameObject);
		}
	}

}
