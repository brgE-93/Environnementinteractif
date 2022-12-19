using UnityEngine;
using System.Collections;

public class MOVE : MonoBehaviour {
	private Rigidbody rb;
	public float speed ;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		rb.MovePosition (this.transform.position + new Vector3 (h * speed, 0, v * speed));
	}
}
