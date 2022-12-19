using UnityEngine;
using System.Collections;

public class RandomAIWalk : MonoBehaviour {
	public GameObject[] target;
	// Use this for initialization
	void Awake () {
		target = GameObject.FindGameObjectsWithTag ("RandomTarget");

		Debug.Log (target.Length);
		foreach (GameObject g in target) {
			Debug.Log (g);
		}
	}
	

}
