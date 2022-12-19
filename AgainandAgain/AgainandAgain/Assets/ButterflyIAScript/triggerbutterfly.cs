using UnityEngine;
using System.Collections;

public class triggerbutterfly : MonoBehaviour {
	public GameObject ethan;
	//
	//public GameObject sphere;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		

	}
	void OnTriggerEnter(Collider other) {
		Debug.Log (" mur");
		if (other.tag == "triggerB") {
			EthanPlayer.etatEthan = 1; // Ethan en mode kill butterfly
			//Flocking.goalPreFab.transform.parent = ethan.transform;
			//sphere.transform.parent=ethan.transform;
			Destroy (other.gameObject);
			Debug.Log ("detruit mur");
		}

	}
}
