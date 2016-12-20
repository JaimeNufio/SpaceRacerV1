using UnityEngine;
using System.Collections;

public class newdoDamage : MonoBehaviour {

	public float damage;

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "ship" && !Game_.isDead) {
			Game_.health -= damage;
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "ship" && !Game_.isDead) {
			Game_.health -= damage;
		}
	}
}
