using UnityEngine;
using System.Collections;

public class KillButterfly : MonoBehaviour {
	public Rigidbody Fireball;
	public Transform muzzle;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {			
			Rigidbody c = Rigidbody.Instantiate (Fireball, muzzle.position, muzzle.rotation)
			as Rigidbody;
			c.AddForce (muzzle.forward * 2000);
	
		}
	}
}
