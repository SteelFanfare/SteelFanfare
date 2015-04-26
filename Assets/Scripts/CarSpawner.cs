using UnityEngine;
using System.Collections;

public class CarSpawner : MonoBehaviour {

	public float HautY = 2.50f;
	public float BasY = -3.0f;
	public int delay = 5;
	public float carSpeed = 15;

	public Rigidbody2D[] cars;
    private int rand;

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

        rand = Random.Range(0, cars.Length);

		bool isHaut = Random.value > 0.5f;

		Vector3 position = new Vector3 (
			isHaut ? 12.0f : -12.0f,
			isHaut ? HautY : BasY
		);
		
		

		float speed = isHaut ? -carSpeed : carSpeed;

		Rigidbody2D newCar = (Rigidbody2D)Instantiate (cars[rand], position, Quaternion.identity);

        if (isHaut)
        {
            newCar.transform.localScale = new Vector3(0.5f, 0.5f, 1);
        }
		newCar.velocity = new Vector2(speed, 0);
	}
}
