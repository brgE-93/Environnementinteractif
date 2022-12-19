using UnityEngine;
using System.Collections;

public class PickUpIABehaviour : GeneralIABehaviours {
    public Transform trRightHand;
    //public static bool isPicked = false;
  // public float distanceObjet = 99999.0f;


    public Animator m_Animator;
    private NavMeshAgent agent;
    public IAHumanController iaHumanC;
    public GameObject[] points;
    public GameObject target;
    //private int destPoint = 0;
    private bool iscoll;
    private Transform trMainGauche;


    public PickUpIABehaviour(IARoot ia) : base (ia){
        //m_Animator = GetComponent<Animator>();
        iaHumanC = (IAHumanController)ia;
        m_Animator = iaHumanC.GetComponent<Animator>();
        trMainGauche = iaHumanC.trLeftHand;
        iscoll = false;
        m_Animator.SetBool("isWalking", false);
    }


    // Update is called once per frame
    public override void Run() {

        if (!iscoll && iaHumanC.objectAround != null)
        {

            foreach (Objet obj in iaHumanC.objectAround)
            {
                //Debug.Log("VA RAMASSER OBJET : " + obj.gameObject.name);
                if (obj.gameObject.name == "HacheIA")
                {
                    iaHumanC.goPickUp = obj.gameObject;
                    iscoll = true;
                }
            }
        }
        

        //Debug.Log("runnnnnnnnENTRE EN COLISION !!");
        if (iscoll && !iaHumanC.etatjeu.attrape)
		{ Debug.Log("ENTRE EN COLISION !!");
            Debug.Log(iaHumanC.goPickUp.tag + " - ");
            if (trMainGauche.childCount > 5)
            {
                m_Animator.SetBool("isPicking", false);
                iaHumanC.etatjeu.attrape = true;
                iaHumanC.etatjeu.isPicked = true;
                iscoll = false;
                Debug.Log("is NOT picking");
                iaHumanC.goPickUp.transform.position = trMainGauche.position;
                iaHumanC.etatjeu.enPosition = false;
                //iaHumanC.initDestination = true;
                iaHumanC.etatjeu.arrivee = false;
                EthanPlayer.etatEthan = 3;
                //transform.Rotate(new Vector3(0, 0, 0) * Time.deltaTime);
            }
            else { 
               m_Animator.SetBool("isPicking", true);
                Debug.Log("is picking");
            }

            
            if ( Vector3.Distance(trMainGauche.position, iaHumanC.goPickUp.transform.position) <1.9f)
            //if (distanceObjet  <  Vector3.Distance(trMainGauche.position, goPickUp.transform.position) + 0.1f)
            {   //
                iaHumanC.goPickUp.transform.parent = trMainGauche.transform;
                iaHumanC.goPickUp.transform.position = trMainGauche.transform.position;                
                //goPickUp.Transform.Rotate = new Vector3(0, 0, 0);

            }
         
            
        
            }
        
    }


    public override int PriorityMode()
    {
        //Debug.Log("EN POSITION DANS PICK UP IA BEHAVIOR" + iaHumanC.etatjeu.enPosition);
        return ((EthanPlayer.etatEthan == 2 || EthanPlayer.etatEthan == 3) && iaHumanC.etatjeu.enPosition && !iaHumanC.etatjeu.isPicked) ? 1 : 0;
    }


}
