using UnityEngine;
using System.Collections;

public class SleepBehaviour : GeneralIABehaviours{

    public Animator m_Animator;
    private NavMeshAgent agent;
    public IAHumanController iaHumanC;


    public SleepBehaviour(IARoot ia) : base (ia){
        //m_Animator = GetComponent<Animator>();
        iaHumanC = (IAHumanController)ia;
        m_Animator = iaHumanC.GetComponent<Animator>();
       
        m_Animator.SetBool("isWalking", false);

       
    }
    //issleeping a false dansle prochain comportement 
    public override void Run()
    {
        m_Animator.SetBool("issleeping", true);
        Debug.Log("EthanPlayer.etatEthan" + EthanPlayer.etatEthan);
        if (EthanPlayer.etatEthan == 0)
        {
            //EthanPlayer.etatEthan = 0;
            iaHumanC.etatjeu.enPosition = false;
            m_Animator.SetBool("issleeping", false);
            //iaHumanC.initDestination = true;
        }
        
    }
    public override int PriorityMode()
    {
        //Debug.Log("EN POSITION DANS PICK UP IA BEHAVIOR" + iaHumanC.etatjeu.enPosition);
        return (iaHumanC.etatjeu.enPosition && EthanPlayer.moodEthan > 50) ?1:0;
        //return (EthanPlayer.etatEthan == 1 && iaHumanC.etatjeu.enPosition) ? 1 : 0;
    }

}
