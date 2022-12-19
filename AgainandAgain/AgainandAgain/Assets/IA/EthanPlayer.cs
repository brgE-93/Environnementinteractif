using UnityEngine;
using System.Collections;

public class EthanPlayer : MonoBehaviour {

	public static int etatEthan; // defini son mode de quete : 0 rien | 1: papillon | 2: coupee arbre | 3: eteindre maison
                                 // Use this for initialization
                                 /*
                                  * mode 0 => 
                                  * mode 1 => triggerbutterfly
                                  * mode 2 => 
                                  * mode 3 => 
                                  */
    public static int moodEthan;
    void Start () {
		etatEthan = 0;
		moodEthan = Random.Range(0,100);

    }
	void Update(){
		//Debug.Log ("MODE ETHAN" + etatEthan);
	}
}
