using UnityEngine;
using System.Collections;

public class Flocking : MonoBehaviour {
	public GameObject butterfly;
	public GameObject goalPreFab;
	public GameObject ethan;
	public GameObject mur;

	static int numbutter=10;
	public static int tankSize= 2;
	public static GameObject[] allbutterfly = new GameObject[numbutter];
	protected Animator animator;
	public static Vector3 goalPos = Vector3.zero;
	public static Vector3 spherepos ;
	public GameObject arbre;
	public static int cptPapillons;

	// Use this for initialization
	public static  bool start = false;
	void Start () {
		cptPapillons = numbutter;
		if (butterfly != null) {
			
			goalPreFab.transform.parent = ethan.transform;
		
			animator = GetComponent<Animator> ();
			//spherepos = goalPreFab.transform.position;
			if (mur == null) {
				for (int i = 0; i < numbutter; i++) {
					// fixer les bords de x et y et z 
					spherepos = arbre.transform.position;
					Vector3 pos = new Vector3 (Random.Range (-tankSize, tankSize),
						             Random.Range (-tankSize, tankSize), Random.Range (-tankSize, tankSize));
					allbutterfly [i] = (GameObject)Instantiate (butterfly, transform.position + pos, Quaternion.identity);
				}
			} else {
				spherepos = goalPreFab.transform.position;
				for (int i = 0; i < numbutter; i++) {
					// fixer les bords de x et y et z 
					Vector3 pos = new Vector3 (Random.Range (-tankSize, tankSize),
						             Random.Range (-tankSize, tankSize), Random.Range (-tankSize, tankSize));
					allbutterfly [i] = (GameObject)Instantiate (butterfly, transform.position + pos, Quaternion.identity);

				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		if (butterfly != null) {
			//goalPreFab.transform.position = goalPos;
			if (Random.Range (0, 10000) < 500) {
				goalPos = new Vector3 (Random.Range (-tankSize, tankSize),
					Random.Range (-tankSize, tankSize), Random.Range (-tankSize, tankSize));

				//goalPreFab.transform.position = goalPos;
			}
			if (mur == null) {
				//spherepos = arbre.transform.position;
				spherepos = goalPreFab.transform.position;
			} else {
				//spherepos = goalPreFab.transform.position;
				spherepos = arbre.transform.position;
			}
			/*if (Random.Range (0, 1000) < 50) {
			for (int i = 0; i < numbutter; i++) {
				

				allbutterfly [i].transform.position = goalPreFab.transform.position + new Vector3 (Random.Range (-i, i), 0, 0);
			}
		}*/

		}
		cptPapillons = 0;
		for (int i = 0; i < numbutter; i++) {
			if (allbutterfly [i] != null){
				cptPapillons = cptPapillons + 1;
			}
		}
        //Debug.Log("cptPapillons  " + cptPapillons + "   EthanPlayer.etatEthan" + EthanPlayer.etatEthan );
        if (cptPapillons == 0 && EthanPlayer.etatEthan == 1)
        {
            EthanPlayer.etatEthan = 0;
        }
	}
}