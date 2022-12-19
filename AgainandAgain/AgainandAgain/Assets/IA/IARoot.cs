using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class IARoot : MonoBehaviour {
	// liste de behaviours 
	public List<GeneralIABehaviours> behaviors;
	public Joueur currentplayer;
	//le behaviour courant
	public GeneralIABehaviours currentBehaviour;
	//liste des closest IA
	public List<Joueur> iaAround;
	//liste des papillons
	public List<Joueur> butterflyAround;

	//public Vector3 nextDestination;

	// le navmesh ?
	[HideInInspector] public UnityEngine.NavMeshAgent navIA;
	// un gamemanager qui nou spermettera de gerer la fin du temps (avec l'inventaire  et la teleporattion)
	[HideInInspector] public GameManager gameManager;
	// ethan
	public EthanPlayer ethanAround;

    public EtatJeu etatjeu;

    public bool initDestination;

    // liste des objets avec lequel il peut interagir (hache, arbre, saut, maison)
    public List<Objet> objectAround;
	[HideInInspector]  public int layer;

	// Use this for initialization
	public virtual void Start () {
		layer = LayerMask.GetMask ("CollisionLayer");
        etatjeu = new EtatJeu();
        //on initialise tt nos varibale 
        iaAround = new List<Joueur>();
		butterflyAround = new List<Joueur>();
		ethanAround = GetComponent<EthanPlayer>();
		objectAround = new List<Objet>();
		behaviors = new List<GeneralIABehaviours>();
		navIA = GetComponent<UnityEngine.NavMeshAgent>();
		gameManager = FindObjectOfType<GameManager> ();
	//	nextDestination = new Vector3 (0, 0, 0);
		SetBehaviours ();
	}

	public virtual void SetEtatEthan(){

	}

	public virtual void SetIAHumanAround(){

	}

	public virtual void SetIAButterFlyAround(){

	}

	public virtual void SetObjetAround(){

	}


	public virtual void SetBehaviours(){
	}


   /* public void setDestination(Vector3 target)
    {
        Debug.Log("  VALEUR SET " + target);
            nextDestination = target;
    }
    */
	public  void SelectBehaviours()// a redefinir dans les controllers adapter
	{
		GeneralIABehaviours nextBehaviour = null;
		int maxPriority = 0;

		foreach (GeneralIABehaviours iaBehaviour in behaviors){


			int nextPriority = iaBehaviour.PriorityMode ();

			// on met a jour la priorite maximale
			if (nextPriority >= maxPriority) {
				nextBehaviour = iaBehaviour;
               // Debug.Log(" COURRENT BEHAVIOR " + iaBehaviour.ToString());
                maxPriority = nextPriority;
			}
		}
        //Debug.Log("currentBehaviour  : " + currentBehaviour + "   NEXTBEHAVIOR   " + nextBehaviour + "   etatEthan " + EthanPlayer.etatEthan + "  ENPOSITION  " + etatjeu.enPosition + "   ISPICKED " + etatjeu.isPicked);// + " nextDestination " + nextDestination);	
                                                                                                                                                                                                                       // !!!!!!!!!  TODO : il faudra surement faire un test pour reset et setup du currentBehavior   A EVALUER !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        if ((currentBehaviour != null && currentBehaviour.PriorityMode() <= maxPriority) || (currentBehaviour == null)){
            //Debug.Log("currentBehaviour  : " + currentBehaviour + "   NEXTBEHAVIOR   "  +nextBehaviour + "   etatEthan " + EthanPlayer.etatEthan+ "  ENPLACE  " + etatjeu.enPosition + "   ISPICKED " + etatjeu.isPicked);// + " nextDestination " + nextDestination);	
            currentBehaviour = nextBehaviour;
		}
        
	}
    /*
    private void SetConfigBehaviour()
    {
        if (EthanPlayer.etatEthan == 1) {

            nextDestination = new Vector3(-4f, transform.position.y, 21f);
            currentBehaviour.UpdateDestination();
        }

        if (EthanPlayer.etatEthan == 2 && !etatjeu.enPosition && !etatjeu.isPicked)   // IA se deplace vers la hache pour ramasser
        {
            nextDestination = new Vector3(75f, transform.position.y, 53f);
            currentBehaviour.UpdateDestination();
        }

        if (EthanPlayer.etatEthan == 2 && !etatjeu.enPosition && etatjeu.isPicked)   // IA se deplace vers arbre pour le couper
        {
            nextDestination = new Vector3(83.4f, transform.position.y, 47.4f);
            currentBehaviour.UpdateDestination();
        }

//        Debug.Log("TOTO");
        Debug.Log("PLAYERMODE  " + EthanPlayer.etatEthan + "  initDestination   " + initDestination + " enPosition  " + etatjeu.enPosition + "  isPicked  " +  etatjeu.isPicked + "  arrivee  " + etatjeu.arrivee + "  attrape  " + etatjeu.attrape);

        if (EthanPlayer.etatEthan == 0 && initDestination)
        {
            currentBehaviour.UpdateDestination();
            initDestination = false;
        }

    }
    */
    // Update is called once per frame
    void Update () {
		
		// on reinitialise notre liste de IA et ethan aux alentours
		// ici on choisi le prochain behaviours et on lexecute à ce niveau 
		// ici le changement de target navmesh ?
		SetEtatEthan();

        SetIAHumanAround ();
		SelectBehaviours();
        //SetConfigBehaviour(); 
        SetIAButterFlyAround ();
		SetObjetAround ();
		currentBehaviour.Run();
	
	}
}
