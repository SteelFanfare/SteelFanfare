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

    private Manager manager;
    public bool evangelisable;

    void Awake()
    {
        manager = GameObject.Find("_manager").GetComponent<Manager>();
        m_rigid = transform.GetComponent<Rigidbody2D>();
        leader = GameObject.Find("GroupeJoueur").GetComponent<CharacControl>().characters[0];
    }

    void Update()
    {

        Vector3 dir = transform.position - leader.transform.position;
        dir.Normalize();



        if (PNJ_Status == PNJ_Type.Electro_FAN)
        {
            if (manager.activeRadio == 0) //electro
            {
                //aime
                evangelisable = true;
                transform.tag = "PNJ";
                m_rigid.velocity = -dir * speed * Time.deltaTime;
            }
            else  if (manager.activeRadio == 1) //rock
            {
                //aime pas
                evangelisable = false;
                transform.tag = "PNJ";
                m_rigid.velocity = dir * speed * Time.deltaTime;
            }
            else if (manager.activeRadio == 2) //HipHop
            {
                evangelisable = false;
                transform.tag = "Background";
                m_rigid.velocity = Vector2.zero;
            }
            else if (manager.activeRadio == 3) //NoRadio
            {
                evangelisable = false;
                transform.tag = "Background";
                m_rigid.velocity = Vector2.zero;
            }
                
        }
        else if (PNJ_Status == PNJ_Type.Rock_FAN)
        {
            if (manager.activeRadio == 0) //electro
            {
                evangelisable = false;
                transform.tag = "Background";
                m_rigid.velocity = Vector2.zero;
            }
            else if (manager.activeRadio == 1) //rock
            {
                //aime
                evangelisable = true;
                transform.tag = "PNJ";
                m_rigid.velocity = -dir * speed * Time.deltaTime;
            }
            else if (manager.activeRadio == 2) //HipHop
            {
                evangelisable = false;
                //aime pas
                transform.tag = "PNJ";
                m_rigid.velocity = dir * speed * Time.deltaTime;
            }
            else if (manager.activeRadio == 3) //NoRadio
            {
                evangelisable = false;
                transform.tag = "Background";
                m_rigid.velocity = Vector2.zero;
            }
        }
        else if (PNJ_Status == PNJ_Type.HipHop_FAN)
        {
            evangelisable = false;
            if (manager.activeRadio == 0) //electro
            {
                //aime pas
                transform.tag = "PNJ";
                m_rigid.velocity = dir * speed * Time.deltaTime;
            }
            else if (manager.activeRadio == 1) //rock
            {
                evangelisable = false;
                transform.tag = "Background";
                m_rigid.velocity = Vector2.zero;
            }
            else if (manager.activeRadio == 2) //HipHop
            {
                //aime
                evangelisable = true;
                transform.tag = "PNJ";
                m_rigid.velocity = -dir * speed * Time.deltaTime;
            }
            else if (manager.activeRadio == 3) //NoRadio
            {
                evangelisable = false;
                transform.tag = "Background";
                m_rigid.velocity = Vector2.zero;
            }
        }
    }
}
