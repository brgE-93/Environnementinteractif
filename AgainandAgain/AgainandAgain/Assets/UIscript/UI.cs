using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI : MonoBehaviour {
	public Button Btn;
	// Use this for initialization
	void Start () {
		Button btn = Btn.GetComponent < Button> ();
		btn.onClick.AddListener(AccessScene);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void AccessScene(){
		Debug.Log ("je clique ");
		SceneManager.LoadScene ("place");
	}
}
