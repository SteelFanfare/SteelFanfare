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

	// Update the progression when the player hovers the collectuble
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
		manager.addCharacter ();
		Destroy(this.gameObject);
	}

	// Limit the calls of playerHover
	void Update() {
        Vector3 newPos = transform.position - new Vector3(Time.deltaTime * 3, 0, 0);
        transform.position = newPos;

		if (recharge > 0.0f) {
			recharge -= Time.deltaTime * 5;
		}
	}

	// Scales the progression
	void UpdateProgressionBar() {
		Transform progressionBar = this.transform.Find("ProgressionHolder");
		float scale = progress * 0.01f;

		Debug.Log (progress);


		progressionBar.localScale = new Vector3 (1.0f, scale, 1.0f);
	}
}
