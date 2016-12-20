using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	
	float piCount = 0,health = 8,timer,timermax = 1.5f;


	// Update is called once per frame
	void Update () {
		piCount += Mathf.PI / 360;
		if (piCount > 20 * Mathf.PI) {
			piCount = 0;
		}
		transform.position = new Vector3 (.4f*Mathf.Sin(piCount*4),-2*piCount +50,0);

		if (health <= 0) {
			piCount = 0;
			health = 8;
		}
			
	}

}
