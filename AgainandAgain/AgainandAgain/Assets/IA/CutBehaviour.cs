using UnityEngine;
using System.Collections;

public class CutBehaviour : GeneralIABehaviours
{
    public Animator m_Animator;
    //private NavMeshAgent agent;
    public IAHumanController iaHumanC;
    //public GameObject[] points;
    //public GameObject target;
    //private int destPoint = 0;
    //private bool iscoll;
    private bool activateAnim = false;


    public CutBehaviour(IARoot ia) : base(ia)
    {
        iaHumanC = (IAHumanController)ia;
        m_Animator = iaHumanC.GetComponent<Animator>();

    }

    public override void Run()
    {
        m_Animator.SetBool("isWalking", false);
        Debug.Log("CUTBEHAVIOR !!");
        if (activateAnim == false)
        {
            m_Animator.SetBool("isWiping", true);
            activateAnim = true;
        }
        if (FallTree.nbVie <= 0)
        {
            Debug.Log("ARBRE TOMBE !!" + FallTree.nbVie);
            m_Animator.SetBool("isWiping", false);
            //PickUpIA.goObjectPicked.transform.parent=null;
            //Destroy(PickUpIA.goObjectPicked);
            if (iaHumanC.goPickUp != null)
            {
                iaHumanC.DestroyPickUp();
            }
            iaHumanC.initDestination = true;
            iaHumanC.etatjeu.enPosition = false;
            iaHumanC.etatjeu.isPicked = false;


        }
    }
    
    public override int PriorityMode()
    {

        return (EthanPlayer.etatEthan == 3 && iaHumanC.etatjeu.enPosition && iaHumanC.etatjeu.isPicked) ? 1 : 0;
    }
}
