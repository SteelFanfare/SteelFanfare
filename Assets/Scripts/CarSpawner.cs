using UnityEngine;
using System.Collections;

public class CarSpawner : MonoBehaviour {

	public float HautY = 2.50f;
	public float BasY = -3.0f;
	public int delay = 5;
	public float carSpeed = 2;

	public Rigidbody2D car;

	private float recharge;

	void Start() {
		recharge = delay;
	}
	
	void Update () {
		if (recharge > 0.0f) {
			recharge -= Time.deltaTime * 5;
		} else {
			SpawnCar();
			recharge = delay;
		}
	}

	void SpawnCar() {
		bool isHaut = Random.value > 0.5f;

		Vector3 position = new Vector3 (
			isHaut ? 12.0f : -12.0f,
			isHaut ? HautY : BasY
		);
		
		Quaternion orientation = new Quaternion (
			0,
			0,
			isHaut ? -180 : 0,
			0
		);

		float speed = isHaut ? -carSpeed : carSpeed;

		Rigidbody2D newCar = (Rigidbody2D)Instantiate (car, position, orientation);
		newCar.velocity = new Vector2(speed, 0);
	}
}
