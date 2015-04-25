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
	
	}

    void OnPlayerEnter(GameObject character)
    {
		manager.killCharacter (character);
    }
}
