using UnityEngine;
using System.Collections;

public class Fly : MonoBehaviour {

	bool slot,hold;

	public int starCount;
	public float count,
	health,
	//countTime,
	holdTime,
	holdThreshold,limit,
	bulletSpeed,
	edgeDamage;

	float originalZ,yPos;

	Vector3 travelPos,newPos,bulletPos;

	public GameObject[] Fire = new GameObject[2], SpaceRocks = new GameObject[4];
	public GameObject bullet,star;

	void Start () {
		Game_.initiStats ();
		Game_.registerStats ();
		Game_.time = 0;
		health = Game_.maxHealth;
		//if (!Input.gyro.enabled) {Input.gyro.enabled = true;}
		originalZ = transform.position.z;
		yPos = transform.position.y;
		for (int i = 0; i < starCount; i++) {
			Instantiate (star,new Vector3(0,-10,0),Quaternion.identity);
		}

		for (int i = 0; i < Game_.rockCount; i++){
			int index = Random.Range (0,3);
			Instantiate (SpaceRocks[index],new Vector3(0,-10,0),Quaternion.identity);
		}
		//Game_.gameTime = Game_.timeUnit * -30;
	}
	

	void Update () {

		//Debugging tool for the health bar

		if (Game_.health <= 0.5) {
			Game_.health = 0;
			Game_.isDead = true;
		}


		if (!Game_.isDead) {
			
			Vector3 accel = Input.acceleration;
			travelPos = new Vector3 (accel.x / limit, 0, originalZ);
			newPos = travelPos + transform.position;

			if (newPos.y > yPos || newPos.y < yPos) {
				transform.position = Vector3.Lerp (transform.position, new Vector3 (transform.position.x, yPos, transform.position.z), Time.deltaTime * 5);
			}

			transform.rotation = Quaternion.identity;

			if (travelPos.x < 3.5 || travelPos.x > -3.5) {
				transform.Translate (travelPos);
			}

			//Debug.Log (transform.position.x);

			if (transform.position.x > 3 || transform.position.x < -3) {
				Game_.health -= edgeDamage;
				Debug.Log ("offEdge");
			}

			if (Input.touchCount > 0 && Game_.fire > 0 && !hold) {
				count += Time.deltaTime;
				//Debug.Log(Game_.fire);
				if (slot) {
					bulletPos = Fire [0].transform.position;
				} else {
					bulletPos = Fire [1].transform.position;
				}

				bulletPos = new Vector3 (bulletPos.x, bulletPos.y, 0);

				if (count > Game_.countTime) {
					Game_.fire -= 2;
					slot = !slot;
					GameObject clone = (GameObject)Instantiate (bullet, bulletPos, transform.rotation);
					//clone.transform.rotation = transform.rotation;
					clone.GetComponent<Rigidbody2D> ().AddForce ( bulletSpeed*transform.forward);
					//clone.transform.parent = GameObject.FindGameObjectsWithTag ("mainCamera");
					count = 0;
				}
			} else if (Input.touchCount < 1) {
				if (Game_.fire < Game_.maxFire) {
					Game_.fire += 1;
				}
			} else {
				//Debug.Log("On Empty");
				if (Game_.fire <= 0) {
					hold = true;
				}
				if (hold) {
					holdTime += Time.deltaTime;
					if (holdTime > holdThreshold) {
						hold = false;
					}
				}
			}
		}else{
			transform.GetComponent<Rigidbody2D> ().gravityScale = .5f;
			float calcSpeed = Game_.calcSpeed();
			if (PlayerPrefs.GetFloat("maxSpeed")<Game_.Adjust(calcSpeed-Game_.startTime)){
				PlayerPrefs.SetFloat ("maxSpeed",Game_.Adjust(calcSpeed - Game_.startTime));
			}
			Game_.time = 0;
		}
	}
}
