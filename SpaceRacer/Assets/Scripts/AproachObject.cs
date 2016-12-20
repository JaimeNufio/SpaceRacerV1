using UnityEngine;
using System.Collections;

public class AproachObject : MonoBehaviour {

	public Vector3 goHere;
	public float rate, timer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		goHere = GameObject.FindGameObjectWithTag ("core").transform.position;
		//goHere = new Vector3(2.5f,-4,0);
		float speed = Time.deltaTime * rate;
		transform.position = Vector3.Lerp (transform.position, goHere, speed);

		if (Vector3.Magnitude (transform.position - goHere) < 1) {
			Game_.gotDarkMatter ();

			Destroy (transform.gameObject);
		}


		if (timer > 2) {
			//Game_.darkMatter += 1;
			Destroy (transform.gameObject);
		}
	}
	/*
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "ship") {
			Debug.Log ("Points");
			Game_.darkMatter += 1;
			Destroy (transform.gameObject);
		}
	}

	void OnTriggernEnter2D(Collider2D other){
		if (other.gameObject.tag == "ship") {
			Debug.Log ("Points");
			Game_.darkMatter += 1;
			Destroy (transform.gameObject);
		}
	}
	*/
}
