﻿using UnityEngine;
using System.Collections;

public class PickUpObjects : MonoBehaviour {
	bool beingCarried = false;
	private bool touched = false;
	public Transform player;
	public Transform playerCam;
	public float throwForce = 10;
	bool hasPlayer = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		float dist = Vector3.Distance(gameObject.transform.position, player.position);//recupere distance entre le player et l'object 
		if (dist <= 2.5f)
		{
			hasPlayer = true;
		}

		else
		{
			hasPlayer = false;
		}

		if (hasPlayer && Input.GetMouseButtonDown(2))
		{
			GetComponent<Rigidbody>().isKinematic = true;
			transform.parent = playerCam;
			beingCarried = true;
		}

		if (beingCarried) {
			if (touched) {
				GetComponent<Rigidbody> ().isKinematic = false;
				transform.parent = null;
				beingCarried = false;
				touched = false;
			}
			if (Input.GetMouseButtonDown (0)) {
				GetComponent<Rigidbody> ().isKinematic = false;
				transform.parent = null;
				beingCarried = false;
				GetComponent<Rigidbody> ().AddForce (playerCam.forward * throwForce);
			} else if (Input.GetMouseButtonDown (1)) {
				GetComponent<Rigidbody> ().isKinematic = false;
				transform.parent = null;
				beingCarried = false;
			}




		}

	}





























	void OnTriggerEnter()
	{
		if (beingCarried)
		{
			touched = true;
		}
	}

}
