// Patrol.cs
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PatrollingBehaviour : GeneralIABehaviours{

	public GameObject[] points;
	public GameObject[] target;
	private int destPoint = 0;
	private NavMeshAgent agent;
	public IAHumanController iaHumanC;
	public bool isColliderLayerActive = true;
	public List<GameObject> cutObject;
	public Animator m_Animator;

	public PatrollingBehaviour(IARoot ia) : base (ia){
		iaHumanC = (IAHumanController)ia;
		agent = iaHumanC.navIA;//GetComponent<NavMeshAgent>();
		points= GameObject.FindGameObjectsWithTag ("RandomTarget");
		 cutObject = new List<GameObject> ();
        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        m_Animator = iaHumanC.GetComponent<Animator>();
        agent.autoBraking = false;
      
        GotoNextPoint();
	}


	public override void Run() {
        m_Animator.SetBool("issleeping", false);
        m_Animator.SetBool("isPicking", false);
        m_Animator.SetBool("isWalking", true);
        agent.Resume();
        bool con = !agent.pathPending && agent.remainingDistance < 0.5f;
      //Debug.Log("Dans Patrolling");
		//m_Animator.SetBool ("isWalking", true);
        if (!agent.pathPending && agent.remainingDistance < 0.5f) { 
			GotoNextPoint();
            
        }
    }

    public override void UpdateDestination()
    {
        agent.Resume();
     
    }

    void GotoNextPoint() {
		// Returns if no points have been set up
		if (points.Length == 0)
			return;

        // Set the agent to go to the currently selected destination.
        agent.autoBraking = true;
        agent.destination = points[Random.Range(0, points.Length-1)].transform.position;

		// Choose the next point in the array as the destination,
		// cycling to the start if necessary.
		//destPoint = (destPoint + 1) % points.Length;
	}

	public override int PriorityMode(){
        //return (EthanPlayer.etatEthan == 0) ? 1 : 0;
        return 1;

    }

	void Reset(){
		//points = null;
		//target = null;
	}

}