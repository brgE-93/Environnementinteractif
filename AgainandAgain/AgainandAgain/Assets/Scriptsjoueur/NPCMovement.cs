using UnityEngine;
using System.Collections;

public class NPCMovement : MonoBehaviour {

	NavMeshAgent agent ;
	Animator animator;
	public Transform destination;
	[Range(0.2f,2.5f)]
	public float speed = 1.0f;

	// Use this for initialization
	void Start (){
		agent = GetComponent<NavMeshAgent>();
		agent.destination = destination.position;
	}
	void Update(){
		if( animator != null || ( animator = GetComponent<Animator>())){
			animator.SetFloat("Speed",speed);
			animator.speed = speed;
			agent.velocity = animator.velocity;
			if(agent.desiredVelocity.magnitude != 0.0f)
				transform.rotation = Quaternion.LookRotation(agent.desiredVelocity);

			if(agent.remainingDistance < 1.0f){
				animator.SetFloat("Speed",0.0f);
				animator.speed = 1.0f;
			}
		}
			}
			}
