using UnityEngine;
using System.Collections;

public class Procedural : MonoBehaviour {

    public GameObject[] blocs;
    public GameObject background;
    public GameObject spawnerBG;
    public GameObject spawnerSituations;

    private int rand;

    void Start()
    {
        InvokeRepeating("spawnBloc", 0, 5.0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Background")
        {
            Instantiate(background, spawnerBG.transform.position, Quaternion.identity);
        }



    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Background")
        {
            Destroy(other.gameObject);
        }

        if (other.tag == "PNJ")
        {
            Destroy(other.gameObject);
        }
    }

    void spawnBloc()
    {
        rand = Random.Range(0, blocs.Length);
        Instantiate(blocs[rand], spawnerSituations.transform.position, Quaternion.identity);
    }
}
