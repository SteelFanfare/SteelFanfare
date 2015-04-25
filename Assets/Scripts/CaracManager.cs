using UnityEngine;
using System.Collections;

public class CaracManager : MonoBehaviour {

	void OnCollisionStay2D(Collision2D other)
	{
		Debug ("collision");
		if (other.gameObject.tag == "Pick Up") {
			other.gameObject.SendMessage ("OnPlayerHover");
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Effector") {
			other.gameObject.SendMessage("OnPlayerEnter");
		}
	}



}
