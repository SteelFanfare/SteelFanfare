using UnityEngine;
using System.Collections;

public class BackgroundManager : MonoBehaviour {

    public float speed;
    public GameObject[] backgrounds; //Array qui contient tous les BG

    private float delta;

    void Start()
    {
        backgrounds = GameObject.FindGameObjectsWithTag("Background");
    }


	void Update () 
    {
        delta = Time.deltaTime;

        for (int i = 0; i < backgrounds.Length; i++)
        {
            Vector3 newPos = backgrounds[i].transform.position - new Vector3(speed * delta, 0, 0);
            backgrounds[i].transform.position = newPos;
        }
	}
}
