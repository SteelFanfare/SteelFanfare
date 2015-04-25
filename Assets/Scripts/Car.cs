using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {

	public int lifetime = 2;
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
			Debug.Log ("Squish");
			Destroy(other);
		}
	}
}
