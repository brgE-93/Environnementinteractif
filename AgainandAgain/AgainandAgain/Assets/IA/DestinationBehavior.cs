// Patrol.cs
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class DestinationBehavior : GeneralIABehaviours{
	public Animator m_Animator;
	private NavMeshAgent agent;
	public IAHumanController iaHumanC;
	public GameObject[] points;
	public GameObject target;
	private int destPoint = 0;
    

    public DestinationBehavior(IARoot ia) : base (ia){
        
        iaHumanC = (IAHumanController)ia;
		agent = iaHumanC.navIA;//GetComponent<NavMeshAgent>();
        m_Animator = iaHumanC.GetComponent<Animator>();
        //agent.stoppingDistance =
        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).

    }
/*
    public override void UpdateDestination()
    {
        agent.autoBraking = true;
        agent.destination = iaHumanC.nextDestination;
        agent.Resume();
        Debug.Log("DESTINATION =========>   agent.destination    " + agent.destination);
    }
    */
    public override void Run() {
        m_Animator.SetBool("isWalking", true);
        m_Animator.SetBool("isPicking", false);
        //Debug.Log ("enPosition  " + iaHumanC.etatjeu.enPosition);
        //Debug.Log(ia.name + "   NEXTDESTINATION   " + agent.destination + "TRANSFORM IAHUMAN : " + iaHumanC.transform.position + " reste : " + Vector3.Distance(iaHumanC.transform.position, agent.destination));
        // Debug.Log("DESTINATION  " + agent.destination);
        if (iaHumanC.etatjeu.enPosition == false) {
            
            if (Vector3.Distance (iaHumanC.transform.position, agent.destination) < 2.5f) {
				agent.Stop ();
				Debug.Log ("arrivee");
                m_Animator.SetBool("isWalking", false);
                iaHumanC.etatjeu.arrivee = true;
			}
			if (iaHumanC.etatjeu.arrivee) {
				ManagerOrientation ();
                iaHumanC.etatjeu.arrivee = false;

                //Debug.Log ("rot");
                iaHumanC.etatjeu.enPosition = true;
			}
	
		}
	}

	public void ManagerOrientation(){
	Vector3 direction = agent.destination - iaHumanC.transform.position;
	//Debug.Log ("DIRECTION :" + direction + ia.transform.rotation);
	if ((direction.x * direction.y * direction.z) > 0) {
            iaHumanC.transform.rotation = new Quaternion (0, -direction.y, 0, 0);//Quaternion.Lerp(ia.transform.rotation, newRot,0.05f);
		}
	}

    public bool positionObjet()
    {
        
        if (iaHumanC.objectAround != null && EthanPlayer.etatEthan > 1)
        {
            int cptHache = 0;

            foreach (Objet obj in iaHumanC.objectAround)
            {
               // Debug.Log(ia.name + " OBJET DANS SAC : " + obj.gameObject.name);

                if (EthanPlayer.etatEthan == 2 && obj.gameObject.name.Contains("HacheIA"))
                {
                    cptHache++;
                    Debug.Log(" ISAVAILABLE " + obj.isAvailable);
                    if (obj.isAvailable) {
                        obj.isAvailable = false;
                        agent.autoBraking = true;
                        agent.destination = obj.gameObject.transform.position;
                        agent.Resume();
                       // Debug.Log(ia.name + "=========>   agent.destination    " + agent.destination);
                        return true;
                    }
                    if (cptHache == 2)
                    {
                        return true;
                    }

                }
                if (EthanPlayer.etatEthan == 3 && obj.gameObject.name == "TreeToCut")
                {
                    agent.autoBraking = true;
                    agent.destination = obj.gameObject.transform.position;
                    agent.Resume();
                    //Debug.Log(ia.name + "=========>TREETOCUT ==================>   agent.destination    " + agent.destination);
                    return true;
                }
            }
        }
        
        if (EthanPlayer.etatEthan == 1)
        {
            agent.autoBraking = true;
            agent.destination = GameObject.Find("PointPapillon").transform.position;//new Vector3(-4f, iaHumanC.transform.position.y, 21f); 
            agent.Resume();
            //Debug.Log(ia.name + "=========>   agent.destination    " + agent.destination);
            return true;
            
         }
       // Debug.Log("PAS D OBJET");
        return false;
    }

    public override int PriorityMode(){
        // Debug.Log("EN POSITION DANS DESTINATION BEHAVIOR" + EthanPlayer.etatEthan + " posi " +  iaHumanC.etatjeu.enPosition + " positionObjet() " + positionObjet());
        //return (EthanPlayer.etatEthan > 0 && !iaHumanC.etatjeu.enPosition) ? 1 : 0;
        return (EthanPlayer.etatEthan > 0 && !iaHumanC.etatjeu.enPosition && positionObjet()) ? 1 : 0;
    }

	void Reset(){
		//points = null;
		//target = null;
	}


}