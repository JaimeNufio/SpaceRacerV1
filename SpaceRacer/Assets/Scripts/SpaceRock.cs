using UnityEngine;
using System.Collections;

public class SpaceRock : MonoBehaviour {

	public float zPos = 0;
	public float health = 0,damage;
	Vector3 startHere;
	public Sprite[] fuel = new Sprite[4];
	public GameObject darkMatter;

	float piCount,uniqueSpeed;
	Vector3 linePos;

	// Use this for initialization
	void Start () {
		Restart ();
	}

	void createDarkMatter(int num,Vector3 startHere){
		if (num > 0) {
			for (int i = 0; i < num; i++) {
				GameObject cl = (GameObject)Instantiate (darkMatter, this.transform);
				cl.transform.parent = transform.parent;
				startHere = transform.position;
				cl.transform.position = startHere + new Vector3 (Random.Range (-.4f, .4f), Random.Range (-.4f, .4f), 2);
				float matterSize = Random.Range (2f, 5f);
				cl.GetComponent<Transform> ().localScale = new Vector3 (matterSize, matterSize, 1);
				cl.GetComponent<SpriteRenderer> ().sprite = fuel [(Random.Range (0, 3))];
				//Debug.Log ("Made darkMatter");
			}
		}
	}

	void Restart(){
		float size = Random.Range (1.5f,6);
		health = (int)size;
		transform.localScale = new Vector3 (size,size,1);
		linePos = new Vector3 (Random.Range(-3.2f,3.2f),Random.Range(20,8f),Random.Range(-1,1));
		transform.position = linePos;
		uniqueSpeed = Random.Range (.7f, 2f);
	}

	// Update is called once per frame
	void Update () {
		startHere = transform.position;
		piCount+=(Mathf.PI/360);
	
		if (piCount >= 2 * Mathf.PI) {
			piCount = 0;
		}

		transform.position += new Vector3 (0,-Game_.starSpeed*Game_.starSpeedMult*uniqueSpeed*.5f,0);
		transform.rotation = Quaternion.AngleAxis (Mathf.Sin(piCount),Vector3.forward);

		if (transform.position.y < -10) {
			Restart ();
		}

		damage = transform.localScale.x;
				
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.transform.position.y < 5.2 && other.tag == "bullet") {
			health -= Game_.damage;
			//Debug.Log ("hit, hp = " + health);
			transform.localScale = new Vector3 (health, health, 1);
			if (Random.Range (1, 10) > 5) {
				createDarkMatter (Random.Range (0, 3), startHere);
			}
			if (health < 1) {
				createDarkMatter (Random.Range(1,3),startHere);
				Restart ();
			}
			Destroy (other.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "ship" && !Game_.isDead){
			Debug.Log ("bump");
			//health -= 0.25f;
			transform.localScale = new Vector3 (health, health, 1);
			Game_.health -= damage;
			if (Random.Range (0, 1) > .5f) {
				Game_.gotDarkMatter ();

			}
			//screateDarkMatter (Random.Range(0,4),startHere);

		}
	}
}
	