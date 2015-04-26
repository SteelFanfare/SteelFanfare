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
            if (other.transform.GetComponent<PNJ>().evangelisable == true)
            {
                //on rajoute 1 point
                GameObject.Find("_manager").GetComponent<Manager>().score++;

                other.SendMessage("activation", (int)other.transform.GetComponent<PNJ>().PNJ_Status);

                other.transform.GetComponent<PNJ>().enabled = false;
                other.transform.GetComponent<Rigidbody2D>().isKinematic = true;
                other.transform.GetComponent<Collider2D>().isTrigger = true;
                other.transform.tag = "Background";
                other.transform.gameObject.layer = 9;

				GameObject.Find ("PickUpSound").GetComponent<AudioSource>().Play();
            }
        }
    }
}
    