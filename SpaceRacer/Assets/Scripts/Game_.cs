using UnityEngine;
using System.Collections;

public static class Game_ {

	public static int rockCount = 10;

	public static float darkMatter = 0, darkMatterTotal, darkMatterValue = 1, 
	displaySpeed, starSpeed, starSpeedMult = 0.01f,
	time = 0, startTime = 0.5f,
	damage = 0.25f,countTime = .2f,
	health = 100, maxHealth = health, fire = 100, maxFire = fire,
	lightSpeed = .93f, displayUpdate = 0.15f,

	//Debug Values:
	debugTime = 100,

	//Dependent on Upgrades
	hpLVL = 1, rpmLVL = 1, ammoLVL = 1, damageLVL = 1,



	darkMatterCapacity = 999//Depricated

	;
	public static bool hyperSpace,debugMode,isDead = false,menuUp = false,countDown = false;

	public static void registerStats(){
		hpLVL = PlayerPrefs.GetInt ("hpLVL");
		damageLVL = PlayerPrefs.GetInt ("damageLVL");
		ammoLVL = PlayerPrefs.GetInt ("ammoLVL");
		rpmLVL = PlayerPrefs.GetInt ("rpmLVL");
		maxHealth = 100+((hpLVL-1)*20);
		maxFire = 100 + ((hpLVL-1)* 20);
		damage =  0.25f+((damageLVL-1)*.1f);
		countTime = 0.2f-((rpmLVL-1)*.02f);
		health = maxHealth;
		fire = maxFire;
	}


	public static float round(float num){
		return Mathf.Round (num * 100f) / 100f;
	}

	public static float calcSpeed(){
		float thing = 100/(1+(150*Mathf.Exp((float) -0.03f * (Game_.time))));

		//Debug.Log (thing*starSpeedMult);
		return thing+startTime;
	}

	public static void gotDarkMatter (){
		Game_.darkMatter += Game_.darkMatterValue;
		Game_.darkMatterTotal += Game_.darkMatterValue;
		PlayerPrefs.SetInt ("totalBlackMatter", (int)Game_.darkMatterTotal);
	}

	public static float Adjust (float num){
		return Mathf.Round (num*100f)/100f;
	}

	public static void initiStats(){

		if (PlayerPrefs.GetInt ("hpLVL") < 1) {
			PlayerPrefs.SetInt ("hpLVL", 1);
		}
		if (PlayerPrefs.GetInt ("rpmLVL") < 1) {
			PlayerPrefs.SetInt ("rpmLVL", 1);
		}
		if (PlayerPrefs.GetInt ("damageLVL") < 1) {
			PlayerPrefs.SetInt ("damageLVL", 1);
		}
		if (PlayerPrefs.GetInt ("ammoLVL") < 1) {
			PlayerPrefs.SetInt ("ammoLVL", 1);
		}
		if (PlayerPrefs.GetInt ("maxSpeed") < 1) {
			PlayerPrefs.SetInt ("maxSpeed", 0);
		}

	}

}
