using UnityEngine;
using System.Collections;

public class PutOutFire : MonoBehaviour {
	RaycastHit hit;
	public static bool FeuEteind = false;
	public int compteur = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawRay (this.transform.position, this.transform.forward * 3, Color.red);

	
			
	}

	// pour les collisions avec les particules comme le feu : fonction de unity 
	void OnParticleCollision(GameObject other) {  
		compteur = compteur + 1;
		
		if (other.tag == "eteindre") {
			Debug.Log("Distance ethan-feu " + Vector3.Distance(other.transform.position,transform.position));
			Debug.Log ("j'eteind le feu ");
			//if ( Vector3.Distance(other.transform.position,transform.position)==4f)
				other.transform.GetComponent<ParticleSystem>().Stop(); 
			if (compteur == 2) {
				FeuEteind = true;
			}
			// recuperer les particule de feu et mettre leur activiter à false 
		}

	}

}
