using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ReportC : MonoBehaviour {

	public GameObject Camera;
	public Text textBox,subText,darkMatterTittle,buttonSet;
	public float starSpeed,timerCap,rateChange;
	public bool debugMode,trap;
	public Color colorTo;

	float displaySpeed,timer;

	void Start () {
		this.GetComponent<Text> ().text = "" + Game_.Adjust (displaySpeed) + "%";
		//this.GetComponent<Text>().text = ""+Game_.calcSpeed();
		Game_.debugMode = debugMode;
		timer = timerCap;
		//PlayerPrefs.SetInt("blackMatter", 0);
		PlayerPrefs.SetInt("totalBlackMatter",(int)Game_.darkMatterTotal);


	}
		

	void FixedUpdate () {

		if (Game_.isDead && !Game_.countDown && !trap) {
			this.transform.localPosition = Vector3.Lerp (this.transform.localPosition, new Vector3 (0, 20, 0), rateChange * Time.deltaTime);
			//darkMatterTittle.transform.parent.transform.localPosition = 
			//	Vector3.Lerp(darkMatterTittle.transform.parent.transform.localPosition, new Vector3 (20000,20000,0),rateChange*999*Time.deltaTime);
			//darkMatterTittle.text="";
			darkMatterTittle.transform.parent.gameObject.SetActive (false);

			//Debug.Log (Game_.time);
			buttonSet.transform.localPosition = 
				Vector3.Lerp (buttonSet.transform.localPosition, new Vector3 (0, -250, 0), rateChange * 9 * Time.deltaTime);
			
		} else if (Game_.countDown || trap) {
			trap = true;
			this.transform.localPosition = Vector3.Lerp (this.transform.localPosition, new Vector3 (0, 500, 0), rateChange * Time.deltaTime);
			//darkMatterTittle.transform.parent.transform.localPosition = 
			//	Vector3.Lerp(darkMatterTittle.transform.parent.transform.localPosition, new Vector3 (20000,20000,0),rateChange*999*Time.deltaTime);
			//darkMatterTittle.text="";
			darkMatterTittle.transform.parent.gameObject.SetActive (false);

			//Debug.Log (Game_.time);
			buttonSet.transform.localPosition = 
				Vector3.Lerp (buttonSet.transform.localPosition, new Vector3 (0, 500, 0), rateChange * 9 * Time.deltaTime);
		}

		if (!Game_.debugMode && !Game_.isDead) {
			Game_.time += Time.deltaTime;
			timer -= Time.deltaTime;
			displaySpeed = Game_.calcSpeed ();
			//displaySpeed = 100/(1+(Mathf.Exp((float) -0.08f * (Game_.time-60))));
			Game_.starSpeed = Game_.calcSpeed();//displaySpeed * 0.24f;

		} else {
			//Game_.time = Game_.debugTime;
			timer = -1;
		}


		if (displaySpeed > 90) {
			Camera.GetComponent<Camera> ().backgroundColor = Color.Lerp (Camera.GetComponent<Camera>().backgroundColor,colorTo,Time.deltaTime*.01f);
		}

		if (timer < 0) {
			if (displaySpeed < 100) {
				this.GetComponent<Text> ().text = "" + Game_.Adjust (displaySpeed-Game_.startTime) + "%";
			} else {
				this.GetComponent<Text> ().text = "HYPERSPACE";
				subText.GetComponent<Text> ().text = "velocity has been achieved!";
			}
			timer = timerCap;
		}





		if (Game_.darkMatter >= Game_.darkMatterCapacity) {
			Game_.darkMatter = Game_.darkMatterCapacity;
			//PlayerPrefs.SetInt("darkMatter",Game_.darkMatter);
		}
		darkMatterTittle.text = Game_.darkMatter+" kg";
	}
}
