using UnityEngine;
using System.Collections;

public class PickupManager : MonoBehaviour {

	public int hoverDelay = 2;
	public int progressSpeed = 5;

	private float progress = 0.0f;
	private float recharge = 0.0f;

	private Manager manager;

	void Awake () 
	{
		manager = GameObject.Find("_manager").GetComponent<Manager>();
	}

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
		manager.addCharacter (this.GetComponent<Rigidbody2D>().position);
		Destroy(this.gameObject);
	}

	// Limit the calls of playerHover
	void Update() {
		if (recharge > 0.0f) {
			recharge -= Time.deltaTime * 5;
		}
	}
}
