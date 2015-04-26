using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    public int lifes;
    public int score;
    public int PNJDead;


    //oui c'est moche:
    public GameObject robot1;
    public GameObject robot2;
    public GameObject robot3;
    public GameObject robot4;

	public GameObject GameOver;

	private CharacControl caracControl;

    public enum radio
    {
        Electro,
        Rock,
        HipHop,
        NoRadio
    }
    public int activeRadio;
    private Text textRadio;
    private Slider slider;
    private Text scoreText;

	private GameObject textPNJLife;

	void Awake () 
    {
        //radio de base : pas de radio
        activeRadio = (int)radio.NoRadio;
        textRadio = GameObject.Find("TextRadio").GetComponent<Text>();
        textRadio.text = "radio : No-Radio";
        slider = GameObject.Find("Slider").GetComponent<Slider>();
        scoreText = GameObject.Find("TextScore").GetComponent<Text>();
		caracControl = GameObject.Find("GroupeJoueur").GetComponent<CharacControl>();
		
		Time.timeScale = 1.0f;
	}
	
	void Update ()
    {
        slider.value = PNJDead;

        if (PNJDead >= 10)
        {
            PNJDead = 0;

            int i = caracControl.characters.Length;
            while ( i > 0)
            {
                if (caracControl.characters[i-1].activeInHierarchy == false)
                {
                    i--;
                }
                else
                {
                    killCharacter(caracControl.characters[i - 1]);
                    i = 0;
                }
                
            }

        }


        scoreText.text = "Score : " + score;

        #region Input Radios
        if (Input.GetButton("A_manette"))
        {
            activeRadio = (int)radio.NoRadio;
            textRadio.text = "radio : No-Radio";

            robot1.GetComponent<Robot1Behavior>().beat = 0;
            robot2.GetComponent<Robot1Behavior>().beat = 0;
            robot3.GetComponent<Robot1Behavior>().beat = 0;
            robot4.GetComponent<Robot1Behavior>().beat = 0;
            
        }
        else if (Input.GetButton("B_manette"))
        {
            activeRadio = (int)radio.HipHop;
            textRadio.text = "radio : HipHop";

            robot1.GetComponent<Robot1Behavior>().beat = 1;
            robot2.GetComponent<Robot1Behavior>().beat = 1;
            robot3.GetComponent<Robot1Behavior>().beat = 1;
            robot4.GetComponent<Robot1Behavior>().beat = 1;
        }
        else if (Input.GetButton("X_manette"))
        {
            activeRadio = (int)radio.Electro;
            textRadio.text = "radio : Electro";

            robot1.GetComponent<Robot1Behavior>().beat = 2;
            robot2.GetComponent<Robot1Behavior>().beat = 2;
            robot3.GetComponent<Robot1Behavior>().beat = 2;
            robot4.GetComponent<Robot1Behavior>().beat = 2;
        }
        else if (Input.GetButton("Y_manette"))
        {
            activeRadio = (int)radio.Rock;
            textRadio.text = "radio : Rock";

            robot1.GetComponent<Robot1Behavior>().beat = 3;
            robot2.GetComponent<Robot1Behavior>().beat = 3;
            robot3.GetComponent<Robot1Behavior>().beat = 3;
            robot4.GetComponent<Robot1Behavior>().beat = 3;
        }
        #endregion
    }

	// Kills a caracter
	public void killCharacter(GameObject character)
	{
		lifes--;
		
		int i = 0;
		while (caracControl.characters[i].gameObject != character) {
			i++;
		}
		
		caracControl.characters [i].SetActive (false);

		if (lifes <= 0) {
			GameOver.SetActive(true);
			Time.timeScale = 0.0f;
		}
	}

	// Brings backa dead caracter
	public void addCharacter(Vector2 position)
	{
		if (lifes >= 4) {
			return;
		}

		int i = 0;
		for (i = 0; i < caracControl.characters.Length; i++) {
			if(caracControl.characters[i].activeInHierarchy == false) {
				caracControl.characters[i].transform.position = position;
				caracControl.characters[i].SetActive(true);
				
				lifes++;
				
				break;
			}
		}
	}
}
