using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Text score,highschore;
	bool update = true;

	float count;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//print (PlayerPrefs.GetInt ("totalBlackMatter"));
		if (Game_.isDead && update) {
			count++;
			Debug.Log ("player Died. " + PlayerPrefs.GetInt ("totalBlackMatter") + " total, " + Game_.darkMatter + " this round, "+count);

			score.text = Game_.darkMatter + " kg";
			
			//PlayerPrefs.SetInt ("totalBlackMatter",(int)(Game_.darkMatter+Game_.darkMatterTotal));
			highschore.text = PlayerPrefs.GetInt("totalBlackMatter")+" kg";
			update = false;
			Game_.darkMatter = 0;
		}
	}
}
