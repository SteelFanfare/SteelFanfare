using UnityEngine;
using System.Collections;

public class PNJ_Trigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "PNJ")
        {
            if (other.transform.GetComponent<PNJ>().evangelisable == true)
            {
                //on rajoute 1 point
                GameObject.Find("_manager").GetComponent<Manager>().score++;


                other.transform.gameObject.GetComponent<SpriteRenderer>().color = Color.white;


                other.transform.GetComponent<PNJ>().enabled = false;
                other.transform.GetComponent<Rigidbody2D>().isKinematic = true;
                other.transform.GetComponent<Collider2D>().isTrigger = true;
                other.transform.tag = "Background";
                other.transform.gameObject.layer = 9;
                other.transform.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Background";
            }
        }
    }
}
    