using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class DayNightCycle : MonoBehaviour {
	public  float time;
	public TimeSpan currenttime;
	public Transform sunTransform;
	public Light sun;
	public Text timetext;
	public   int days;
	public float intensity;
	public Color fogday = Color.grey;
	public Color fognight = Color.black;
	public int speed;
	public static string[]  temptime= new string[2];
	public GameObject mauvaisehumeur;
	public GameObject bonnehumeur;

	
	// Update is called once per frame
	void Update () {
		ChangeTime ();
	}

	public void ChangeTime(){
		string txtHumeur = "";
		time += Time.deltaTime * speed;
		if (time > 72000) {
			days += 1;
			time = 21600;
		}
		currenttime = TimeSpan.FromSeconds (time);
		  temptime = currenttime.ToString ().Split (":" [0]);
		//Debug.Log ("Timmeee"+ temptime[0]);
		if (EthanPlayer.moodEthan < 60) {
			bonnehumeur.SetActive (true);
			 txtHumeur = "BONNE HUMEUR";
		} else {
			 txtHumeur = "MAUVAISE HUMEUR";
			mauvaisehumeur.SetActive (true);
		}


		timetext.text = "Jours " + (PlayerPrefs.GetFloat("Days") + " - Heures " + temptime [0] + ":" + temptime [1]) + " - " + txtHumeur;

		sunTransform.rotation = Quaternion.Euler (new Vector3 ((time - 21600) / 86400 * 360, 0, 0));
		if (time < 43200) {
			intensity = 1 - (43200 - time)/43200-10000;
		} else {
			intensity = 1 - ((43200 - time)/43200*-1)-10000;
		}

		RenderSettings.fogColor = Color.Lerp (fognight, fogday, intensity * intensity);

		sun.intensity = intensity;
	}
}
