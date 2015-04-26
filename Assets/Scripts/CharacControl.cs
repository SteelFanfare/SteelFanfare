using UnityEngine;
using System.Collections;

public class CharacControl : MonoBehaviour
{

    #region variables publiques
    public GameObject[] characters; //Array des musiciens (dynamique)
    public float speed;
    public float speedFollow;
    public GameObject hand;

    public float invicibility;
    #endregion

    #region variables privées
    private Vector2 m_velocity;
    private float delta;
    private Vector3 velo;


    public int first;
    #endregion

    void Awake()
    {
        velo = Vector3.zero;
        first = 0;
    }

	int GetLeaderKey()
	{
		#region test Leader
		if (characters[0].activeInHierarchy == true)
		{
			first = 0;
		}
		else if (characters[1].activeInHierarchy == true)
		{
			first = 1;
		}
		else if (characters[2].activeInHierarchy == true)
		{
			first = 2;
		}
		else
		{
			first = 3;
		}
		#endregion

		return first;
	}

	void Update ()
    {
        #region valeurs a réassigner à chaque frame
        // car on l'utilise plusieur fois
        delta = Time.deltaTime;

        if (invicibility > 0) {
            invicibility -= delta;
		}

        // axis de manettes entre -1 et 1
        m_velocity.x = Input.GetAxis("Horizontal"); 
        m_velocity.y = Input.GetAxis("Vertical");
        #endregion

		first = GetLeaderKey ();

        #region mouvement
        //on bouge le premier directement
		characters[first].transform.GetComponent<Rigidbody2D>().velocity = m_velocity * speed * delta; 

        //les autres ont un retard
        for (int i = first+1; i < characters.Length; i++)
        {
            if (characters[i].activeInHierarchy == false)
            {
                characters[i].transform.position = characters[i-1].transform.position;
            }
            else
            {
                characters[i].transform.position = Vector3.SmoothDamp(characters[i].transform.position,
                new Vector3(characters[i - 1].transform.position.x - 1.1f, characters[i - 1].transform.position.y, characters[i - 1].transform.position.z), ref velo, speedFollow);
            }
        }

        hand.transform.position = characters[first].transform.position + new Vector3(0.5f, 0.7f, 0);

        #endregion
    }

	void LateUpdate()
	{
		first = GetLeaderKey ();

		float dist = (transform.position - Camera.main.transform.position).z;
		Vector3 bottomLeft = Camera.main.ViewportToWorldPoint (new Vector3(0.0f, 0.0f, dist));
		Vector3 topRight = Camera.main.ViewportToWorldPoint (new Vector3(1.0f, 1.0f, dist));
		
		characters [first].transform.position = new Vector3 (
			Mathf.Clamp(characters [first].transform.position.x, bottomLeft.x, topRight.x),
			Mathf.Clamp(characters [first].transform.position.y, bottomLeft.y, topRight.y),
			characters [first].transform.position.z
		);
	}
}
