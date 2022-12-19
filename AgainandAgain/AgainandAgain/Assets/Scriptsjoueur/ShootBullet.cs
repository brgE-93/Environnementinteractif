using UnityEngine;
using System.Collections;

public class ShootBullet : MonoBehaviour {
	public Rigidbody bullet = null;
	public float bulletSpeed = 500f;
	public Rigidbody FireMagic;
	public Transform Muzzle;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			
			//GameObject shoot = GameObject.Instantiate (bullet, transform.position + (transform.forward * 2), transform.rotation) as GameObject;

			//shoot.GetComponent<Rigidbody>().AddForce (transform.forward * bulletSpeed);
			Debug.Log("yooo1");
			Rigidbody c = Rigidbody.Instantiate (bullet, Muzzle.position, Muzzle.rotation)
				as Rigidbody;
			Debug.Log("yooo2");
			if (c != null) {
				c.AddForce (Muzzle.forward * 1250);
			}
		}
	}

}
