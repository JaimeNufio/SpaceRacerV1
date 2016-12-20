using UnityEngine;
using System.Collections;

public class MovePlanet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp (transform.position, new Vector3 (0, -20, 0), 1.4f*Time.deltaTime*Game_.starSpeed*Game_.starSpeedMult);
			if (transform.position.y < -15){
			Destroy (transform.gameObject);
			}
	}
}
