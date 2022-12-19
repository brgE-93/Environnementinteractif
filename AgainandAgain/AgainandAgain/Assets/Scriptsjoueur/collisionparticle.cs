using UnityEngine;
using System.Collections;

public class collisionparticle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision col){
		///Debug.Log("avant le tag");
		if (col.gameObject.tag == "particulee") {

			//Debug.Log("jsuis en collision");
			Destroy (this.gameObject);
		}

	}

}
