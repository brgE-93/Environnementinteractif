using UnityEngine;
using System.Collections;

public class GeneralIABehaviours {
	public IARoot ia;

    public GeneralIABehaviours (IARoot ia){
		this.ia = ia;
    }

	public virtual void Run(){
		// ici qu'on oriente nos ia face au objet  ou autre ia ou ethan avec lesquel ils vont interagir
		//managerorientation
	}

	public void HumanObjectFacing(){
		//if (ia.iaAround) {
			//Quaternion newRotation;
			//Vector3 direction = ia..transform.position;
		//	newRotation = Quaternion.LookRotation (newData);
		//}

	}

    public virtual void UpdateDestination()
    {

    }

    public virtual int PriorityMode()
    {
        return -1;
    }

	public virtual void Setup(){
	}
	public virtual void Reset(){
	}

}
