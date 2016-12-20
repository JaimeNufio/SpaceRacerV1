using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonComands : MonoBehaviour {


	// Use this for initialization
	public Image thing;

	void Start () {
		Game_.isDead = false;
	}

	public void Replay(){
		Game_.isDead = false;
		Game_.darkMatter = 0;
		Game_.time = 0;

		//countDown = true;
		SceneManager.LoadScene ("MainGame");
	}

	public void OpenShop(){
		//SceneManager.LoadScene ("TheShop");
		Debug.Log ("Open Shop");
		Game_.countDown = true;

	}

	public void Update(){
		if (Game_.countDown) { 
			thing.transform.position += new Vector3 (0,10,0);
			Debug.Log ("moved to "+thing.transform.position.y);
			if (thing.transform.position.y > 600) {
				Game_.countDown = false;
				Game_.menuUp = true;
				Destroy (this.gameObject.GetComponent<ButtonComands>());
			}
		}
	}

}
