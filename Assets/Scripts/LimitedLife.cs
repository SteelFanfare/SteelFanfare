using UnityEngine;
using System.Collections;

public class LimitedLife : MonoBehaviour {

	public float lifetime = 0.5f;

	private float delay;

	void Start() {
		delay = lifetime;
	}

	// Update is called once per frame
	void Update () {
		delay -= Time.deltaTime;

		if (delay <= 0) {
			Destroy(this.gameObject);
		}

		float alpha = delay / lifetime;
		this.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, alpha);
	}
}
