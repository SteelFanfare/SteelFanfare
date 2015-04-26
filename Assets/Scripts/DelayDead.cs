using UnityEngine;
using System.Collections;

public class DelayDead : MonoBehaviour 
{

    void Awake()
    {
        Invoke("Kill", 0.5f);
    }

    void Kill()
    {
        Destroy(transform.gameObject);
    }
}
