using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {


	Vector3 linePos;
	public float zPos;

	void Reset(){
		
		linePos = new Vector3 (Random.Range(-3.2f,3.2f),Random.Range(20,5.2f),zPos);
		transform.position = linePos;
		DimFix ();
		//transform.gameObject.GetComponent<SpriteRenderer>().sprite = stars[Random.Range(0,stars.Length)];
		//transform.rotation = Quaternion.AngleAxis ((float)Random.Range(0,360),Vector3.forward);
	}

	void DimFix(){
		//float size = Random.Range (6,8);
		float width = (-6*Game_.starSpeed*Game_.starSpeedMult)+5; //TODO make this method less ugly
		float length = (240*Game_.starSpeed*Game_.starSpeedMult)+5; //TODO same
		//width,length = 45,32;
		if (width < .7f) {
			width = .7f;
		}
		//if (width < .5f) {	width = Random.Range (.5f,.8f); Debug.Log ("Readjust");}
		transform.localScale = new Vector3 (width, length,0);

	}

	void Start () {
		Reset ();
	}


	void Update () {
		DimFix ();
		if (!Game_.hyperSpace && Game_.starSpeed > Game_.lightSpeed){
			Game_.hyperSpace = true;
			//Debug.Log ("NEVER TELL ME THE ODDS");
		}

		transform.position += new Vector3 (0,-Game_.starSpeed*Game_.starSpeedMult,0);

		if (transform.position.y < -5.3){
			Reset ();
		}
	}
}
