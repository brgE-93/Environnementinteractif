using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PopUp : MonoBehaviour {
	public string myString;
	public Text myText;
	public bool displayInfo;
	public float fadeTime;
	public Transform Ethan;
	public Image image;

	// Use this for initialization
	void Start () {

		//myText = GameObject.Find ("Text").GetComponent<Text> ();
		myText.color = Color.clear; // invisible des le debut
		//image = GameObject.Find ("Image").GetComponent<Image> ();
		image.enabled = false;

	}

	// Update is called once per frame
	void Update () {
		FadeText ();
		/*if (Input.GetKeyDown (KeyCode.Escape)) {

			Screen.lockCursor = false;

		}*/

	}
	void OnMouseOver(){
		displayInfo = true;

	}
	void OnMouseExit(){
		displayInfo = false;
	}

	void FadeText(){
		//if (displayInfo) {
		if (Vector3.Distance(Ethan.position,transform.position)< 4.0f){
			//myText.text = myString;
			myText.color = Color.Lerp (myText.color, Color.black, fadeTime * Time.deltaTime);
			image.enabled = true;
            if( name == "peasantmanbutter")
                EthanPlayer.etatEthan = 1; //mode ethan kill butterfly
            if (name == "peasantmancut") 
                EthanPlayer.etatEthan = 2; //mode ethan traverse riviere
            //Debug.Log("MODE  " + EthanPlayer.etatEthan);
        } else {
			myText.color = Color.Lerp (myText.color, Color.clear, fadeTime * Time.deltaTime);
			image.enabled = false;
			
		}








	}
}