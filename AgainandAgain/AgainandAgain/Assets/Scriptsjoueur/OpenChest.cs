using UnityEngine;
using System.Collections;

public class OpenChest : MonoBehaviour {
	public GameObject topchest ;
    public static bool objetscecret;
    public enum State {
		open,
		close,
		inbetween}
	public State state;
	// Use this for initialization
	void Start () {
		state = OpenChest.State.close;
	
	
	}
	
	// Update is called once per frame
	void Update () {
		OnMouseEnter ();
	
	}
	public void OnMouseEnter(){
		//Debug.Log ("enter");
		touch ();
	}
	public void OnMouseExit(){
		//Debug.Log ("exit");
	}
	public void touch(){
		if (Input.GetMouseButtonDown(1)){
			if (state == OpenChest.State.close) {
				//Debug.Log ("ouvr etoi ");
				Open ();
			}
		} else {
			Close ();
		}
	}

	private void Open(){
		topchest.transform.Rotate(new Vector3(-300.0f, 0f, 0f) *100*Time.deltaTime);
		state = OpenChest.State.open;
        objetscecret = true;


    }
	public void Close(){

		state = OpenChest.State.close;
	}
}
