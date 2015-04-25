using UnityEngine;
using System.Collections;

public class CaracManager : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log ("collision!");
		if (other.gameObject.tag == "Pick Up") {
			other.gameObject.SendMessage("OnPlayerEnter");
			other.gameObject.SetActive (false);
		} else if (other.gameObject.tag == "Effector") {
			other.gameObject.SendMessage("OnPlayerEnter");
		}
	}	

}
