using UnityEngine;
using System.Collections;

public class Procedural : MonoBehaviour {

    public GameObject[] blocs;
    public GameObject spawner;

    private int rand;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Background")
        {
            rand = Random.Range(0, blocs.Length);
            Instantiate(blocs[rand], spawner.transform.position, Quaternion.identity);

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Background")
        {
            Destroy(other.gameObject);
        }
    }
}
