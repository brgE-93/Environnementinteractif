using UnityEngine;
using System.Collections;

public class teleport : MonoBehaviour {

	Vector3 destination;
	void OnCollisionEnter (Collision col){

		if (this.name == "Quad") {
			
			destination = GameObject.Find ("quad2").transform.position;
		} else {
			destination = GameObject.Find ("Quad").transform.position;
		}
		col.transform.position = destination - Vector3.forward*3;
	
	}
}
