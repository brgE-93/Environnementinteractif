using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
public GameObject carte1;
public GameObject carte2;
public GameObject carte3;
public GameObject carte4;
public GameObject carte5;
public GameObject carte6;
public GameObject portefinal;
public int WinGame;
public GameObject tree;
private bool AllCarte=false;
private float f;
public GameObject popupperdu;

public GameObject popup ;
		// Use this for initialization
	void Start () {
        // Random.Range(0, 1);
        //	WinGame=0;
    }
	
	// Update is called once per frame
	void Update () {
		Inventory ();
		ShowFinalDoor ();
        
    }

    public void quitterpopup()
    {
        popup.SetActive(false);
        Debug.Log("hiozhieh");
    }

    public void Inventory ()
	{// a completer avec les autres actions ici ya que eteindre feu et tuer paipllons pour l'instant 
		if (Flocking.cptPapillons == 0) {
			//Debug.Log ("ya plus de papillons j'active ma carte"+GameObject.Find ("/carte1"));
			carte1.SetActive (true);
			//WinGame += 1;

		}
		if (PutOutFire.FeuEteind == true) {
			carte2.SetActive (true);
			//WinGame += 1;

		}
		if (AnimationController.objetlivre == true) {
			carte3.SetActive (true);
		}
		if (OpenChest.objetscecret == true) {

			carte4.SetActive (true);
		}
        if (FallTree.cuttree == true)
        {
            carte5.SetActive(true);
            carte6.SetActive(true);

        }


    }

	public void ShowFinalDoor(){
		int tps = 25;
       //Debug.Log("TOTO IN SHOW FINAL DOOR");
		//pour l'instant on dit que lorsque le compteur est a 2 alors on detruit la porte qui cache le portail ou il pourra se teleporter et on affiche un popup avec la caret final 
		if (Flocking.cptPapillons == 0 && PutOutFire.FeuEteind == true && OpenChest.objetscecret == true && AnimationController.objetlivre == true && FallTree.cuttree == true)
        {//je voulais le faire avec un compteur mais il sincrement à l'infini car les condition du inventory tourne en boucle dans le update 
			Destroy (portefinal);
			popup.SetActive (true);
			AllCarte = true;
		}

		if (DayNightCycle.temptime [0] != null) {
			//float t = float.Parse(DayNightCycle.temptime[0]) *10000+ float.Parse(DayNightCycle.temptime[1]) *100f+float.Parse(DayNightCycle.temptime[2]);
			float t = float.Parse(DayNightCycle.temptime[0]) *100+ float.Parse(DayNightCycle.temptime[1]);
			float f = float.Parse (DayNightCycle.temptime [0]);
		
			//Debug.Log (" TEMPS JOUR " + PlayerPrefs.GetFloat ("temps"));
			if (f == tps && (tps * 100) == t && !AllCarte) {
				PlayerPrefs.SetFloat("temps", t);
				popupperdu.SetActive(true);
            }
		}

	}
	
	public void retourmenu(){
		SceneManager.LoadScene ("Menu");
	}
	public void play (){
		PlayerPrefs.SetFloat("Days", 0f);
		SceneManager.LoadScene ("place");
	}
	public void replay(){
		Debug.Log ("je replay");

		PlayerPrefs.SetFloat("Days", PlayerPrefs.GetFloat("Days") +1f);
		PutOutFire.FeuEteind = false;
		AnimationController.objetlivre = false;
		OpenChest.objetscecret = false;
		FallTree.cuttree = false;
		initTreePosition ();
		SceneManager.LoadScene ("place");
	}

	public void quit(){
        PlayerPrefs.SetFloat("Days" , 0);
		Application.Quit ();
	}

	public void help(){
		
	}

	public void initTreePosition(){
		tree.transform.position = new Vector3 (80, 0, 3);
		tree.transform.Rotate(new Vector3 (-90,113,0));
		tree.transform.localScale = new Vector3 (23,23,46.1f);
	}
}
