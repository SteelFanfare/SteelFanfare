using UnityEngine;
using System.Collections;

public class BigTriggerMusic : MonoBehaviour {

	void Update () 
    {
	    
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "PNJ")
        {
            other.gameObject.GetComponent<PNJ>().canHearMusic = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "PNJ")
        {
            other.gameObject.GetComponent<PNJ>().canHearMusic = false;
        }
    }

}
