using UnityEngine;
using System.Collections;

public class IAHumanController : IARoot {

	public float rayon = 1f;
    public GameObject goPickUp = null;
	public Rigidbody Fireball;
	public Transform StartingPoint;
	public Animator m_Animator;
    public Transform trLeftHand;

    public override void Start () {
		base.Start ();// on initialise avce toutes les variable qu'on initialise de maniere generale dans IARoot
		//regarder plus tard si on a besoin de recupere d'autres composants exterieures
		m_Animator = GetComponent<Animator>();
	}

    public void DestroyPickUp()
    {
        goPickUp.transform.parent = null;
        Destroy(goPickUp);
    }


	public override void SetEtatEthan(){
		Collider[] hitCollider = Physics.OverlapSphere (transform.position, rayon, layer);

		foreach (Collider c in hitCollider) {

			float distance = Vector3.Distance (transform.position, c.gameObject.transform.position);//pour l'instant inutile
			if (c.CompareTag ("Player")) {
				//Debug.Log ("collision ethan"+c.gameObject.transform.position);
				ethanAround = c.gameObject.GetComponent<EthanPlayer> ();
			}
		}
	}

	public override void SetIAHumanAround (){
		Collider[] hitCollider = Physics.OverlapSphere (transform.position, rayon, layer); //, rayon, layer);

		foreach (Collider c in hitCollider) {
			float distance = Vector3.Distance (transform.position, c.gameObject.transform.position);//pour l'instant inutile
			Joueur j = c.gameObject.GetComponent<Joueur> ();
			if (j== null) {
				continue;	
			}
			if (j.isHuman == 1 && !iaAround.Contains (j)) {
				//Debug.Log ("collision IA");
				iaAround.Add (j);
			}
		}
	}



	public override void SetIAButterFlyAround (){
		Collider[] hitCollider = Physics.OverlapSphere (transform.position, rayon, layer);

		foreach (Collider c in hitCollider) {
			float distance = Vector3.Distance (transform.position, c.gameObject.transform.position);//pour l'instant inutile
			Joueur j = c.gameObject.GetComponent<Joueur> ();
			if (j== null) {
				continue;	
			}
			if (j.isHuman == 0 && !butterflyAround.Contains (j)) {
				butterflyAround.Add(j);
			}
		}
	}

    public  int getButterFlyNumber()
    {
        foreach (Joueur goBF in butterflyAround)
        {
            if (goBF != null)
                return 1;
        }
        return 0;
    }

	public override void SetObjetAround (){
		Collider[] hitCollider = Physics.OverlapSphere (transform.position, rayon, layer);

		foreach (Collider c in hitCollider) {
			
			float distance = Vector3.Distance (transform.position, c.gameObject.transform.position);//pour l'instant inutile
			//Debug.Log ("collision objet" + c.gameObject.name + "  distance " + distance);
			Objet j = c.gameObject.GetComponent<Objet> ();
			if (j== null) {
				continue;	
			}
			if (j.isItem == true && !objectAround.Contains (j)) {
				objectAround.Add (j);
			}
		}
	}
		

	public override void SetBehaviours(){
	    behaviors.Add (new PatrollingBehaviour (this));
		behaviors.Add (new AttackBehaviour (this));
        behaviors.Add (new PickUpIABehaviour(this));
        behaviors.Add (new CutBehaviour(this));
        //behaviors.Add(new EteindreBehaviour(this));
        behaviors.Add(new SleepBehaviour(this));
        behaviors.Add (new DestinationBehavior(this));
        

	}
}
