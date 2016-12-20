using UnityEngine;
using System.Collections;

public class BulletGo : MonoBehaviour {

	void Start () {

	}

	void Update () {
		if (transform.position.y > 5.2) {
			Destroy (transform.gameObject);
		}
	}
}
