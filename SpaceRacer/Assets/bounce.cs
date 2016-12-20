using UnityEngine;
using System.Collections;

public class bounce : MonoBehaviour {

	float piCount;
	Vector2 start;
	// Use this for initialization
	void Start () {
		start = (Vector2)transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (true) {
			piCount += Mathf.PI / 360;

			if (piCount > Mathf.PI * 2) {
				piCount = 0;
			}

			transform.position = new Vector2 (start.x, start.y + (8 * Mathf.Sin (piCount * 5)));
		}
	}
}
