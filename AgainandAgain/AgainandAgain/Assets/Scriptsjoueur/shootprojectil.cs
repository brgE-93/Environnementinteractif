
using UnityEngine;
using System.Collections;

public class shootprojectil : MonoBehaviour {
	/*public ParticleSystem particule ;
	public bool triggerBall;
	public float timeStartFire = 0f;*/
	public Rigidbody FireMagic;
	public Transform Muzzle;
	// Use this for initialization
	void Start () {
		//particule = GetComponent<ParticleSystem> ();
	
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")){
			Rigidbody c = Rigidbody.Instantiate (FireMagic, Muzzle.position, Muzzle.rotation)
				as Rigidbody;
			c.AddForce (Muzzle.forward * 2000);







			/*timeStartFire = Time.deltaTime;
			particule.Play();*/
		}
		/*timeStartFire += Time.deltaTime * 0.5f;
		if (timeStartFire > 1 ) {
			particule.Stop();
			timeStartFire = 0;
		}*/

	}
	/*void onTriggerEnter(Collider other){
		Debug.Log (other.ToString());
		/*if (other.name = "butterfly2") {
			
			Destroy (other);
		}*/

	//}*/

	/*void OnParticleCollision(GameObject other) {  
		//Debug.Log ("collision");
		//Debug.Log (other.ToString());
		Debug.Log (other.transform.GetComponent<ParticleSystem>().tag );
		if (other.tag == "papillon") {
			
			Debug.Log ("collision");
			//Debug.Log (other.transform.name);
			Destroy (other.transform);
		
		}
			
	}*/
}
