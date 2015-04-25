﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    public int lifes;
    public int score;
    public int PNJDead;

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
        }
        else if (Input.GetButton("B_manette"))
        {
            activeRadio = (int)radio.HipHop;
            textRadio.text = "radio : HipHop";
        }
        else if (Input.GetButton("X_manette"))
        {
            activeRadio = (int)radio.Electro;
            textRadio.text = "radio : Electro";
        }
        else if (Input.GetButton("Y_manette"))
        {
            activeRadio = (int)radio.Rock;
            textRadio.text = "radio : Rock";
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
