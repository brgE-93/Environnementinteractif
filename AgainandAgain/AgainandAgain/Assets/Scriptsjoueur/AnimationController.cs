using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour {
	public Transform trRightHand;
	public  Transform leftfoot;
	public int mode = 0; // mode neutre  [0: rien, 1: lache objet, 2 : lance objet, 3 : escalade monter, 4 : escalade descendre]
	public GameObject goPickUp = null;
	// Use this for initialization
	Animator m_Animator;
	public GameObject HautDeLaStatut;
	private Vector3 startPos;
	private Vector3 endPos;
	private float distance = 11f;
	private float lerpTime = 10f;
	private float currentLearpTime = 0f;
	private bool keyHit = false;
	private float Perc;
	public GameObject rb;
	public int cptcut=0;
	
	public static bool objetlivre;

	void Start () {
		
		m_Animator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	// le start position ne se remet pas a jour
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.O))
			
		{	m_Animator.SetBool ("isclimbing", true);
			startPos = transform.position;
			endPos = transform.position + Vector3.up * distance;

			//Debug.Log ("je climb");

	
			keyHit = true;

		}
		if (keyHit == true) {
			m_Animator.SetBool ("isclimbing", true);
			currentLearpTime += Time.deltaTime;
			if (currentLearpTime >= lerpTime) {
				currentLearpTime = lerpTime;
				//keyHit = false;
			}
			 Perc = currentLearpTime / lerpTime;

			Debug.Log ("startpos" + startPos);
			transform.position = Vector3.Lerp (startPos, endPos, Perc);
			Debug .Log(startPos + "starpos"+endPos);
		
		}

		//ici c'est pour redescendre et l'annimation s'arrete
		if (Input.GetKeyDown(KeyCode.D) ){
			keyHit = false;
		
			transform.position = Vector3.Lerp ( transform.position,startPos, Perc);
			m_Animator.SetBool ("isclimbing", false);


		}
		//quand il atteind le haut l'annimation s'arrete 
		if (transform.position == endPos) {
			m_Animator.SetBool ("isclimbing", false);
		}



		// p pour pick u
		if (Input.GetKeyDown(KeyCode.P)){

			m_Animator.Play ("Picking Up");	
		
				Debug.Log ("je pick up");
				
		
			if (trRightHand.childCount > 1) {
				modeManager(1);
			} else {
				modeManager(0);
			}
		}


		//la partie pour couper l'arbre faut trouver par quele moyen on voudrait la stopper , soit un comoteur
		if (Input.GetKeyDown (KeyCode.W)) {
			cptcut++;
			GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX| RigidbodyConstraints.FreezeRotationY| RigidbodyConstraints.FreezeRotationZ ;
			m_Animator.SetBool ("isswiping", true);

		}


		if (cptcut > 1) {
			if (Input.GetKeyDown (KeyCode.W)) {
				m_Animator.SetBool ("isswiping", false);
				cptcut = 0;
				
			}
			
		}



        

    }



	void OnCollisionEnter (Collision col){
		
		if (col.gameObject.tag == "pickup" || col.gameObject.tag == "pickupIA") {
			goPickUp = col.gameObject;
		}
		//trRightHand = 
	}

	void modeManager(int mode){
		if (mode == 0) {
			//Debug.Log ("colObject.transform.position  " + goPickUp.transform.position + "  trRightHand.transform.position " + trRightHand.transform.position);
			if (goPickUp != null) {
				goPickUp.transform.parent = trRightHand.transform;
				goPickUp.transform.position = trRightHand.transform.position;
				trRightHand.GetComponent<Collider> ().enabled = false;
				if (goPickUp.name == "Objetlivre") {
					objetlivre = true;
				}
				
				mode = -1;
			}
		} 
		if (mode == 1) {  //
			Debug.Log("1: tient un objet dans la main");
		
			trRightHand.GetChild (1).position = new Vector3(trRightHand.GetChild (1).position.x,leftfoot.position.y,trRightHand.GetChild (1).position.z);
			Transform obj =  trRightHand.GetChild (1);
			trRightHand.GetChild (1).parent = null;
		

		
			mode =-1;
		}

		if (mode == 2) {
			Debug.Log("2 : lance objet");
		} 
	}
}
