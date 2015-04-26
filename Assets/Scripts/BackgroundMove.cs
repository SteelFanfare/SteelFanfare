using UnityEngine;
using System.Collections;

public class BackgroundMove : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		Vector3 newPos = transform.position - new Vector3(Time.deltaTime * 3, 0, 0);
		transform.position = newPos;
	}
}
