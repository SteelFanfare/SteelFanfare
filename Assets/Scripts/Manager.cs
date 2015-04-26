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

	public Texture2D RockImg;
	public Texture2D ElectroImg;
	public Texture2D HipHopImg;
	public Texture2D NoRadioImg;

    public enum radio
    {
        Electro,
        Rock,
        HipHop,
        NoRadio
    }
    public int activeRadio;
    private Slider slider;
    private Text scoreText;

	private GameObject textPNJLife;

	void Awake () 
    {
        //radio de base : pas de radio
        activeRadio = (int)radio.NoRadio;
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

        scoreText.text = "x " + score;

        #region Input Radios
        if (Input.GetButton("A_manette"))
        {
			activeRadio = (int)radio.NoRadio;
			changeRadio(NoRadioImg);
			setRobotBehavior(0);
            
        }
        else if (Input.GetButton("B_manette"))
        {
			activeRadio = (int)radio.HipHop;
			changeRadio(HipHopImg);
			setRobotBehavior(1);
        }
        else if (Input.GetButton("X_manette"))
        {
			activeRadio = (int)radio.Electro;
			changeRadio(ElectroImg);
			setRobotBehavior(2);
        }
        else if (Input.GetButton("Y_manette"))
        {
            activeRadio = (int)radio.Rock;
			changeRadio(RockImg);
			setRobotBehavior(3);
        }
        #endregion
    }

	void changeRadio(Texture2D tex)
	{
		RawImage imageRadio = GameObject.Find ("CurrentRadio").GetComponent<RawImage> ();
		imageRadio.texture = tex;
	}

	public void setRobotBehavior(int beatNumber) {
		robot1.GetComponent<Robot1Behavior>().beat = beatNumber;
		robot2.GetComponent<Robot1Behavior>().beat = beatNumber;
		robot3.GetComponent<Robot1Behavior>().beat = beatNumber;
		robot4.GetComponent<Robot1Behavior>().beat = beatNumber;
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

	// Brings back a dead caracter
	public void addCharacter()
	{
		if (lifes >= 4) {
			return;
		}

		// Getting the leading robot to figure its positions
		CharacControl controller = GameObject.Find("GroupeJoueur").GetComponent<CharacControl>();
		int leaderKey = controller.GetLeaderKey ();
		Vector2 position = caracControl.characters [leaderKey].transform.position;

		// Searching for a dead robot
		int i = 0;
		for (i = 0; i < caracControl.characters.Length; i++) {
			if(caracControl.characters[i].activeInHierarchy == false) {
				caracControl.characters[i].transform.position = position;
				caracControl.characters[i].SetActive(true);
				
				lifes++;
				Debug.Log (activeRadio);

				switch(activeRadio) {
					case (int)radio.NoRadio :
						setRobotBehavior(0);
						break;

					case (int)radio.Electro :
						setRobotBehavior(2);
						break;

					case (int)radio.Rock :
						setRobotBehavior(3);
						break;

					case (int)radio.HipHop :
						setRobotBehavior(1);
						break;
				}

				break;
			}
		}
	}
}

