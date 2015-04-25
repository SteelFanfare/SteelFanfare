using UnityEngine;
using System.Collections;

public class PNJ : MonoBehaviour {

    //This is the "set" of all possible status effects
    public enum PNJ_Type
    {
        Electro_FAN,
        Rock_FAN,
        HipHop_FAN
    }

    //Now we can make a variable using that set as its type!
    public PNJ_Type PNJ_Status;


    private Rigidbody2D m_rigid;
    private GameObject leader;
    public float speed;

    void Awake()
    {
        m_rigid = transform.GetComponent<Rigidbody2D>();
        leader = GameObject.Find("GroupeJoueur").GetComponent<CharacControl>().characters[0];
    }

    void Update()
    {

        Vector3 dir = transform.position - leader.transform.position;
        dir.Normalize();


        // Vers le leader
        m_rigid.velocity = -dir * speed * Time.deltaTime;


        //vers l'exterieur
        //m_rigid.velocity = dir * speed * Time.deltaTime;






        if (PNJ_Status == PNJ_Type.Electro_FAN)
        {
            
        }
        else if (PNJ_Status == PNJ_Type.Rock_FAN)
        {
            
        }
        else if (PNJ_Status == PNJ_Type.HipHop_FAN)
        {
            
        }
    }
}
