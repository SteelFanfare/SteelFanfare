using UnityEngine;
using System.Collections;

public class PNJ_Trigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.tag == "PNJ")
        {
            other.transform.GetComponent<PNJ>().enabled = false;
            other.transform.gameObject.layer = 9;
        }
    }
}
