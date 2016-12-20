using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class healthBar : MonoBehaviour {

	public Text  text1,text2,health,ammo;
	public Image bar1,bar2;
	public int multX = 0;
	float mult = 211, b = 301;
	float maxPercent1, percent1,maxPercent2,percent2;

	Vector3 originalPos1, originalPos2,originalScale1;

	// Use this for initialization
	void Start () {

		originalPos1 = bar1.transform.GetComponent<RectTransform>().localPosition;
		originalPos2 = bar2.transform.GetComponent<RectTransform>().localPosition;
		//originalScale1 = bar1.transform.GetComponent<RectTransform>().lossyScale;
	}
	
	// Update is called once per frame
	void Update () {
		percent1 = Game_.health/Game_.maxHealth;
		percent2 = Game_.fire /Game_.maxFire;
		//Debug.Log (percent1);

		if (percent1 < 0) {
			percent1 = 0;
		}
		if (percent2 < 0){
			percent2 = 0;
		}

		text1.text =Game_.round(percent2*100) + "%";
		text2.text = Game_.round(percent1*100) + "%";

		bar1.GetComponent<RectTransform> ().localPosition = new Vector3 ((mult*percent1)-b,originalPos1.y,0);
		bar2.GetComponent<RectTransform> ().localPosition = new Vector3 ((mult*percent2)-b,originalPos2.y,0);

		if (Game_.isDead) {
			bar1.gameObject.SetActive (false);
			bar2.gameObject.SetActive (false);
			health.gameObject.SetActive (false);
			ammo.gameObject.SetActive (false);
		}

	}
}

