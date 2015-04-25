using UnityEngine;
using System.Collections;

public class CaracManager : MonoBehaviour {

    private CharacControl carac;

    void Awake()
    {
        carac = GameObject.Find("GroupeJoueur").GetComponent<CharacControl>();
    }

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "Pick Up") {
			other.gameObject.SendMessage ("OnPlayerHover", null, SendMessageOptions.DontRequireReceiver);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.tag == "Effector") {
            if (carac.invicibility <= 0)
            {
                other.gameObject.SendMessage("OnPlayerEnter", this.gameObject);
                carac.invicibility = 1;
            }

        }
	}
}
