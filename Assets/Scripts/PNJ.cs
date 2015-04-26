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

    #region vieux objets en public
    public GameObject Electro_Object;
    public GameObject Rock_Object;
    public GameObject HipHop_Object;

    public GameObject Ticket_Object_Electro;
    public GameObject Ticket_Object_Rock;
    public GameObject Ticket_Object_HipHop;
    #endregion

    private Manager manager;
    public bool evangelisable;
    private float delta;

    public bool canHearMusic = false;

	private bool dying = false;

    void Awake()
    {
        manager = GameObject.Find("_manager").GetComponent<Manager>();
        m_rigid = transform.GetComponent<Rigidbody2D>();
        leader = GameObject.Find("GroupeJoueur").GetComponent<CharacControl>().characters[0];
    }

    void Start()
    {
        Ticket_Object_Electro.GetComponent<SpriteRenderer>().enabled = false;
        Ticket_Object_Rock.GetComponent<SpriteRenderer>().enabled = false;
        Ticket_Object_HipHop.GetComponent<SpriteRenderer>().enabled = false;

        if (PNJ_Status == PNJ_Type.Electro_FAN)
        {
            Electro_Object.SetActive(true);
            Rock_Object.SetActive(false);
            HipHop_Object.SetActive(false);
        } 
        else if(PNJ_Status == PNJ_Type.Rock_FAN)
        {
            Electro_Object.SetActive(false);
            Rock_Object.SetActive(true);
            HipHop_Object.SetActive(false);
        }
        else if (PNJ_Status == PNJ_Type.HipHop_FAN)
        {
            Electro_Object.SetActive(false);
            Rock_Object.SetActive(false);
            HipHop_Object.SetActive(true);
        }
    }

    void Update()
    {
        delta = Time.deltaTime;

        leader = GameObject.Find("GroupeJoueur").GetComponent<CharacControl>().
            characters[GameObject.Find("GroupeJoueur").GetComponent<CharacControl>().first];
       
        Vector3 dir = transform.position - leader.transform.position;
        dir.Normalize();

        #region canHear
        if (canHearMusic)
        {
            if (PNJ_Status == PNJ_Type.Electro_FAN)
            {
                if (manager.activeRadio == 0) //electro
                {
                    //aime
                    evangelisable = true;
                    transform.tag = "PNJ";
                    m_rigid.velocity = -dir * 400 * delta;
                }
                else  if (manager.activeRadio == 1) //rock
                {
                    //aime pas
                    evangelisable = false;
                    transform.tag = "PNJ";
                    m_rigid.velocity = dir * 100 * delta;
                }
                else if (manager.activeRadio == 2) //HipHop
                {
                    evangelisable = false;
                    m_rigid.velocity = Vector2.zero;
                    Vector3 newPos = transform.position - new Vector3(delta * 3, 0, 0);
                    transform.position = newPos;
                }
                else if (manager.activeRadio == 3) //NoRadio
                {
                    evangelisable = false;
                    m_rigid.velocity = Vector2.zero;
                    Vector3 newPos = transform.position - new Vector3(delta * 3, 0, 0);
                    transform.position = newPos;
                }
                
            }
            else if (PNJ_Status == PNJ_Type.Rock_FAN)
            {
                if (manager.activeRadio == 0) //electro
                {
                    evangelisable = false;
                    m_rigid.velocity = Vector2.zero;
                    Vector3 newPos = transform.position - new Vector3(delta * 3, 0, 0);
                    transform.position = newPos;
                }
                else if (manager.activeRadio == 1) //rock
                {
                    //aime
                    evangelisable = true;
                    transform.tag = "PNJ";
                    m_rigid.velocity = -dir * 400 * delta;
                }
                else if (manager.activeRadio == 2) //HipHop
                {
                    evangelisable = false;
                    //aime pas
                    transform.tag = "PNJ";
                    m_rigid.velocity = dir * 100 * delta;
                }
                else if (manager.activeRadio == 3) //NoRadio
                {
                    evangelisable = false;
                    m_rigid.velocity = Vector2.zero;
                    Vector3 newPos = transform.position - new Vector3(delta * 3, 0, 0);
                    transform.position = newPos;
                }
            }
            else if (PNJ_Status == PNJ_Type.HipHop_FAN)
            {
                evangelisable = false;
                if (manager.activeRadio == 0) //electro
                {
                    //aime pas
                    transform.tag = "PNJ";
                    m_rigid.velocity = dir * 100 * delta;
                }
                else if (manager.activeRadio == 1) //rock
                {
                    evangelisable = false;
                    m_rigid.velocity = Vector2.zero;
                    Vector3 newPos = transform.position - new Vector3(delta * 3, 0, 0);
                    transform.position = newPos;
                }
                else if (manager.activeRadio == 2) //HipHop
                {
                    //aime
                    evangelisable = true;
                    transform.tag = "PNJ";
                    m_rigid.velocity = -dir * 400 * delta;
                }
                else if (manager.activeRadio == 3) //NoRadio
                {
                    evangelisable = false;
                    m_rigid.velocity = Vector2.zero;
                    Vector3 newPos = transform.position - new Vector3(delta * 3, 0, 0);
                    transform.position = newPos;
                }
            }
        }
        else
        {
            m_rigid.velocity = Vector2.zero;
            Vector3 newPos = transform.position - new Vector3(delta * 3, 0, 0);
            transform.position = newPos;
        }
        #endregion

    }
    void Squish()
	{
		if (!dying) {
			dying = true;

			Invoke ("Mort", 0.2f);
		}
    }

    void Mort()
    {
		manager.PNJDead++;
		Destroy (transform.gameObject);
    }


    public void activation(int i)
    {
        if (i == 0)
            Ticket_Object_Electro.GetComponent<SpriteRenderer>().enabled = true;
        else if (i == 1)
            Ticket_Object_Rock.GetComponent<SpriteRenderer>().enabled = true;
        else if (i == 2)
            Ticket_Object_HipHop.GetComponent<SpriteRenderer>().enabled = false;
        else
            Debug.Log("ERROR");
    }
}
