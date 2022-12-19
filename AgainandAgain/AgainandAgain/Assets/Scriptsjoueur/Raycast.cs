using UnityEngine;
using System.Collections;

public class Raycast : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawRay (this.transform.position, this.transform.forward * 3, Color.magenta);
	}
}
