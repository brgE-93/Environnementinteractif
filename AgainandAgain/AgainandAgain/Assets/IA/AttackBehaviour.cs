using UnityEngine;
using System.Collections;

public class AttackBehaviour : GeneralIABehaviours {
	// script pour tuer les papillons 
	//public Rigidbody Fireball;
	//public Transform StartingPoint;
	public int cptBall = 0;


	public Animator m_Animator;
	private NavMeshAgent agent;
	public IAHumanController iaHumanC;
	public GameObject[] points;
	public GameObject target;
	private int destPoint = 0;
    


    public AttackBehaviour(IARoot ia) : base (ia){
		//m_Animator = GetComponent<Animator>();
		iaHumanC = (IAHumanController)ia;
		agent = iaHumanC.navIA;//GetComponent<NavMeshAgent>();
		//agent.stoppingDistance =
		// Disabling auto-braking allows for continuous movement
		// between points (ie, the agent doesn't slow down as it
		// approaches a destination point).
		agent.autoBraking = true;
        agent.Resume();
        //StartingPoint = iaHumanC.GetComponent

    }


    public override void Run()
    {

        
         if ( iaHumanC.butterflyAround != null)
        {
            foreach(Joueur bfly in iaHumanC.butterflyAround)
            {
                if(bfly != null)
                {
                    agent.autoBraking = true;
                    agent.destination = new Vector3(bfly.transform.position.x, iaHumanC.transform.position.y, bfly.transform.position.z);
                    agent.Resume();
                    //Debug.Log("=========> BUTTERFLY FOLLOWING   agent.destination    " + agent.destination);

                    break;
                }
            }

         }
         
        if (iaHumanC.getButterFlyNumber() == 0)
        {
            //EthanPlayer.etatEthan = 0;
            iaHumanC.etatjeu.enPosition = false;
            //iaHumanC.initDestination = true;
        }

       // Debug.Log ("Dans AttackB    " + iaHumanC.getButterFlyNumber());
        if (cptBall % 50 == 0)
        {
            //Rigidbody c = Rigidbody.Instantiate(Fireball, StartingPoint.position, StartingPoint.rotation) as Rigidbody;
			Rigidbody c = Rigidbody.Instantiate(iaHumanC.Fireball, iaHumanC.StartingPoint.position, iaHumanC.StartingPoint.rotation) as Rigidbody;
            c.AddForce(iaHumanC.GetComponent<Transform>().forward * 1000);
        }
       cptBall = cptBall + 1;


        // si ia plus dans la zone des butterfly, enPlace = false et retourne en mode destination  => definir une zone acceptable


    }


    public override int PriorityMode(){
		return (EthanPlayer.etatEthan == 1 && iaHumanC.etatjeu.enPosition) ? 1 : 0;
	}


}
