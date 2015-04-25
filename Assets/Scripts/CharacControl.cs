using UnityEngine;
using System.Collections;

public class CharacControl : MonoBehaviour
{

    #region variables publiques
    public GameObject[] characters; //Array des musiciens (dynamique)
    public float speed;
    public float speedFollow;

    public float invicibility;
    #endregion

    #region variables privées
    private Vector2 m_velocity;
    private float delta;
    private Vector3 velo;


    private int first;
    #endregion

    void Awake()
    {
        velo = Vector3.zero;
        first = 0;
    }

	void Update ()
    {
        #region valeurs a réassigner à chaque frame
        // car on l'utilise plusieur fois
        delta = Time.deltaTime;

        if (invicibility > 0)
            invicibility -= delta;

        // axis de manettes entre -1 et 1
        m_velocity.x = Input.GetAxis("Horizontal"); 
        m_velocity.y = Input.GetAxis("Vertical");
        #endregion

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
        #endregion
    }
}
