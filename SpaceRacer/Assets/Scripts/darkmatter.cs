using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class darkmatter : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		transform.gameObject.GetComponent<Text>().text = "DARK MATTER:\n"+PlayerPrefs.GetInt("totalBlackMatter")+" KG";
	}
}
