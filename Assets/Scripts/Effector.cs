using UnityEngine;
using System.Collections;

public class Effector : MonoBehaviour {

    private Manager manager;

	void Awake () 
    {
        manager = GameObject.Find("_manager").GetComponent<Manager>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        Vector3 newPos = transform.position - new Vector3(Time.deltaTime * 3, 0, 0);
        transform.position = newPos;
	}

    void OnPlayerEnter(GameObject character)
    {
		Debug.Log ("Contact kill");
		manager.killCharacter (character);
    }
}
