using UnityEngine;
using System.Collections;

public class Effector : MonoBehaviour {

    private Manager manager;
    private CharacControl caracControl;

	void Awake () 
    {
        manager = GameObject.Find("_manager").GetComponent<Manager>();
        caracControl = GameObject.Find("GroupeJoueur").GetComponent<CharacControl>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnPlayerEnter(GameObject character)
    {
        manager.lifes--;

        int i = 0;
        while (caracControl.characters[i].gameObject != character)
        {
            i++;
        }

       caracControl.characters[i].SetActive(false);

    }
}
