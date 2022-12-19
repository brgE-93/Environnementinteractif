using UnityEngine;
using System.Collections;

public class Flock : MonoBehaviour {
	public float speed = 0.5f;
	float rotationSpeed = 4.0f;
	Vector3 averageHeading;
	Vector3 averagePosition; 
	float neighbourDistance = 2.0f;
	// Use this for initialization

	bool turning = false;

	void Start () {
		speed = Random.Range (1f, 5f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (transform.position, /*Vector3.zero*/Flocking.spherepos) >= Flocking.tankSize) {
			turning = true;
		} else {
			turning = false;
		}
		if (turning) {
			Vector3 direction =  Flocking.spherepos/* Vector3.zero*/- transform.position;
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (direction), rotationSpeed * Time.deltaTime);
			speed = Random.Range (2f, 5f);
		} else {
			if (Random.Range (0, 5) < 1)
				ApplyRules ();
		}


		transform.Translate (0, 0, Time.deltaTime * speed);
	}

	void ApplyRules(){
		GameObject[] gos;
		gos = Flocking.allbutterfly;
		Vector3 vcentre = Flocking.spherepos; //Vector3.zero; // le point central du groupe
		Vector3 vavoid = Vector3.zero;  //d'ecart entre chaque papillon constituant le groupe 
		float gSpeed = 0.1f;
		Vector3 goalPos = Flocking.goalPos;
		float dist;
		int groupSize = 0; // taille actuel du groupe 
	
			foreach (GameObject go in gos) {
				if (go) {
					//Debug.Log ("YOOOOO" + go);
					dist = Vector3.Distance (go.transform.position, this.transform.position);
					if (dist <= neighbourDistance) {
						vcentre += go.transform.position;
						groupSize++;

						if (dist < 1.0f) {
							vavoid = vavoid + (this.transform.position - go.transform.position);
						}

						Flock anotherFlock = go.GetComponent<Flock> ();
						gSpeed = gSpeed + anotherFlock.speed;
					}


				} 
			}
		/*			else {
				Debug.Log ("GOS LENGTH  ---> Y EN A PLUS !!" + gos.Length);
				EthanPlayer.etatEthan = 0;
			}
*/
		//Debug.Log ("TAILLE GOOOOOOOOOOOOOO : " + gos.Length);
			if (groupSize > 0) {
				vcentre = vcentre / groupSize + (goalPos - this.transform.position);
				speed = gSpeed / groupSize;

				Vector3 direction = (vcentre + vavoid) - transform.position;
				if (direction != /*Vector3.zero*/Flocking.spherepos)
					transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (direction), rotationSpeed * Time.deltaTime);
			}
		}
}


