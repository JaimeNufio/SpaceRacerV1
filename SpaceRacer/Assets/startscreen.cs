using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class startscreen : MonoBehaviour {

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
		Game_.time = 12;
		Game_.initiStats ();
		Game_.registerStats ();
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


	void Update(){
		if (Input.touchCount > 0) {
			SceneManager.LoadScene ("MainGame");
		}
	}
}
