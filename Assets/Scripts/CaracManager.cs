using UnityEngine;
using System.Collections;

public class CaracManager : MonoBehaviour {

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "Pick Up") {
			other.gameObject.SendMessage ("OnPlayerHover", null, SendMessageOptions.DontRequireReceiver);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Effector") {
			other.gameObject.SendMessage("OnPlayerEnter");
		}
	}
}
