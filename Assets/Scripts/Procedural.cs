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
        InvokeRepeating("spawnBG", 0, 17.8f);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Background" || other.tag == "PNJ" || other.tag == "Effector" || other.tag == "PickUp")
        {
            Destroy(other.gameObject);
        }
    }

    void spawnBloc()
    {
        rand = Random.Range(0, blocs.Length);
        Instantiate(blocs[rand], spawnerSituations.transform.position, Quaternion.identity);
    }
    void spawnBG()
    {
        Instantiate(background, spawnerBG.transform.position, Quaternion.identity);
    }
}
