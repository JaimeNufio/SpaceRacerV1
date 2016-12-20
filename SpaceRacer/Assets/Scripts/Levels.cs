using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour {

	public Text ammo,hp,damage,rpm,speedreport,
	ammo1,hp1,damage1,rpm1;

	float lastDarkMatterTotal;


	void thing () {

		ammo1.text = "AMMO:\nLVL " + (PlayerPrefs.GetInt ("ammoLVL")+1);
		ammo.text = Mathf.Pow (2, Game_.ammoLVL)*50+"KG";
		if (Mathf.Pow (2, Game_.ammoLVL) * 50 > PlayerPrefs.GetInt ("totalBlackMatter")) {
			ammo.color = Color.red;
		} else {
			ammo.color = Color.yellow;
		}
		damage1.text = "DAMAGE:\nLVL "+(PlayerPrefs.GetInt("damageLVL")+1);
		damage.text = Mathf.Pow (2, Game_.damageLVL)*50+"KG";
		if (Mathf.Pow (2, Game_.damageLVL) * 50 > PlayerPrefs.GetInt ("totalBlackMatter")) {
			damage.color = Color.red;
		} else {
			damage.color = Color.yellow;
		}
		rpm1.text = "RPM:\nLVL "+(PlayerPrefs.GetInt("rpmLVL")+1);
		rpm.text = Mathf.Pow (2, Game_.rpmLVL)*50+"KG";
		if (Mathf.Pow (2, Game_.rpmLVL) * 50 > PlayerPrefs.GetInt ("totalBlackMatter")) {
			rpm.color = Color.red;
		} else {
			rpm.color = Color.yellow;
		}
		hp1.text = "HEALTH:\nLVL "+(PlayerPrefs.GetInt("hpLVL")+1);
		hp.text = Mathf.Pow (2, Game_.hpLVL)*50+"KG";
		if (Mathf.Pow (2, Game_.hpLVL) * 50 > PlayerPrefs.GetInt ("totalBlackMatter")) {
			hp.color = Color.red;
		} else {
			hp.color = Color.yellow;
		}
		speedreport.text = "RECORD SPEED:\n"+PlayerPrefs.GetFloat("maxSpeed")+"% c";
		lastDarkMatterTotal = Game_.darkMatterTotal;

	}
	// Use this for initialization
	void Start () {
		thing ();
	}

	void Update(){
		thing();
	}

	public void shit(){
		PlayerPrefs.SetInt ("hpLVL",(int)Game_.hpLVL);
		PlayerPrefs.SetInt ("damageLVL",(int)Game_.damageLVL);
		PlayerPrefs.SetInt ("rpmLVL",(int)Game_.rpmLVL);
		PlayerPrefs.SetInt ("ammoLVL",(int)Game_.ammoLVL);
		Game_.darkMatterTotal = PlayerPrefs.GetInt ("totalBlackMatter");
		SceneManager.LoadScene ("MainGame");
	}

	public void HP(){
		float cost = Mathf.Pow (2, Game_.hpLVL)*50;
		if (PlayerPrefs.GetInt("totalBlackMatter") >= cost){
			PlayerPrefs.SetInt("totalBlackMatter",(int)(PlayerPrefs.GetInt("totalBlackMatter")-cost));
			Game_.hpLVL++;
			if (Game_.hpLVL > PlayerPrefs.GetInt ("hpLVL")) {
				PlayerPrefs.SetInt ("damageLVL", (int)Game_.hpLVL);
			}
			cost = Mathf.Pow (2, Game_.hpLVL)*50;
		}
		thing ();
	}
	public void AMMO(){
		float cost = Mathf.Pow (2, Game_.ammoLVL)*50;
		if (PlayerPrefs.GetInt("totalBlackMatter") >= cost){
			PlayerPrefs.SetInt("totalBlackMatter",(int)(PlayerPrefs.GetInt("totalBlackMatter")-cost));
			Game_.ammoLVL++;
			if (Game_.damageLVL > PlayerPrefs.GetInt ("ammoLVL")) {
				PlayerPrefs.SetInt ("ammoLVL", (int)Game_.ammoLVL);
			}
			cost = Mathf.Pow (2, Game_.ammoLVL)*50;
		}
		thing ();
	}
	public void RPM(){
		float cost = Mathf.Pow (2, Game_.rpmLVL)*50;
		if (PlayerPrefs.GetInt("totalBlackMatter") >= cost){
			PlayerPrefs.SetInt("totalBlackMatter",(int)(PlayerPrefs.GetInt("totalBlackMatter")-cost));
			Game_.rpmLVL++;
			if (Game_.rpmLVL > PlayerPrefs.GetInt ("rpmLVL")) {
				PlayerPrefs.SetInt ("rpmLVL", (int)Game_.damageLVL);
			}
			cost = Mathf.Pow (2, Game_.rpmLVL)*50;
		}
		thing ();
	}
	public void DMG(){
		float cost = Mathf.Pow (2, Game_.damageLVL)*50;
		if (PlayerPrefs.GetInt("totalBlackMatter") >= cost){
			PlayerPrefs.SetInt("totalBlackMatter",(int)(PlayerPrefs.GetInt("totalBlackMatter")-cost));
			Game_.damageLVL++;
			if (Game_.damageLVL > PlayerPrefs.GetInt ("damageLVL")) {
				PlayerPrefs.SetInt ("damageLVL", (int)Game_.damageLVL);
			}
			cost = Mathf.Pow (2, Game_.damageLVL)*50;
		}
		thing ();
	}

}
