using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {

	public int lifetime = 3;
	private float delay;

	void Start() {
		delay = lifetime;
	}

	void Update () {
		if (delay > 0.0f) {
			delay -= Time.deltaTime * 5;
		} else {
			Destroy (this.gameObject);
		}
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "PNJ") {
            other.gameObject.SendMessage("Squish");
		}
	}
}
