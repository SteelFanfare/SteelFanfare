using UnityEngine;
using System.Collections;

public class PickupManager : MonoBehaviour {

	public int hoverDelay = 2;
	public int progressSpeed = 5;

	private float progress = 0.0f;
	private float recharge = 0.0f;
	
	// Update the progression when the player
	void OnPlayerHover () 
	{
		if (recharge > 0.0f) {
			return;
		}

		progress += progressSpeed * 100 * Time.deltaTime;

		recharge = hoverDelay;

		if (progress >= 100.0f) {
			Complete ();
		}
	}

	void Complete()
	{
		this.gameObject.SetActive (false);
	}

	// Limit the calls of playerHover
	void Update() {
		if (recharge > 0.0f) {
			recharge -= Time.deltaTime * 5;
		}
	}
}
