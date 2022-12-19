using UnityEngine;
using System.Collections;

public class FallTree : MonoBehaviour {
    public static int nbVie ;
    public Vector3 rotationFinale;
    public static bool estTombe = false;
    public static bool cuttree = false;
    // Use this for initialization
    void Start () {
       // rotationFinale = new Vector3(transform.rotation.x , transform.rotation.y, transform.rotation.z);
		nbVie =35;
    }
	
	// Update is called once per frame
	void Update () {
       // Debug.Log("init   " + transform.rotation.x + " nbVie : " + nbVie);
        
	    if (transform.rotation.x < 0 && nbVie <= 0)

        {
            cuttree = true;
			Debug.Log ("je suis tombee"+nbVie+transform.rotation.x);
            //transform.Rotate = new Vector3(transform.rotation.x + 90, transform.rotation.y, transform.rotation.z);
            transform.Rotate(new Vector3(transform.rotation.x +55, transform.rotation.y , transform.rotation.z) * Time.deltaTime * 5);
            transform.localScale= new Vector3(45, 5, transform.localScale.z);
            EthanPlayer.etatEthan = 0;
        }


    }

    void OnCollisionEnter(Collision col)
    {
      //  Debug.Log("TREEEEEEEEEE " + col.gameObject.tag);
        if (col.gameObject.tag == "pickupIA" || col.gameObject.tag == "Player")
        {
            
            nbVie = nbVie - 1;
       //  Debug.Log("FallTree.nbVie " + FallTree.nbVie);
            //TreeObject.niveauvie  => recuperer script Tree et sa variable static  !!! compter quand la hache entre en collision
        }
    }


}
