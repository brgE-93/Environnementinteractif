using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuprincipal : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void retourmenu(){
		SceneManager.LoadScene ("Menu");
	}
	public void play (){
		SceneManager.LoadScene ("place");
	}
	public void quit(){

	
		#if UNITY_EDITOR
		// Application.Quit() does not work in the editor so 
		// UnityEditor.EditorApplication.isplaying need to be set to false to end game
		UnityEditor.EditorApplication.isPlaying = false;
		#else 
	Application.Quit();
		#endif
	}
	public void help(){
		
		SceneManager.LoadScene ("help");
	}
}
