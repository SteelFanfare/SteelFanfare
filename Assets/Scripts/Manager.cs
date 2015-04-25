using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    public int lifes;
    public int score;
	public int pnjLife = 5;

	private int pnjLifeCurrent;
	private CharacControl caracControl;

    public enum radio
    {
        Electro,
        Rock,
        HipHop,
        NoRadio
    }
    public int activeRadio;
    private GameObject textRadio;

	private GameObject textPNJLife;

	void Awake () 
    {
        //radio de base : pas de radio
        activeRadio = (int)radio.NoRadio;
        textRadio = GameObject.Find("TextRadio");
        textRadio.GetComponent<Text>().text = "radio : No-Radio";

		caracControl = GameObject.Find("GroupeJoueur").GetComponent<CharacControl>();

		pnjLifeCurrent = pnjLife;
		textPNJLife = GameObject.Find("TextPNJLife");
		textPNJLife.GetComponent<Text> ().text = "Asimov : " + pnjLifeCurrent.ToString ();
        
	}
	
	void Update ()
    {
        
        #region Input Radios
        if (Input.GetButton("A_manette"))
        {
            activeRadio = (int)radio.NoRadio;
            textRadio.GetComponent<Text>().text = "radio : No-Radio";
        }
        else if (Input.GetButton("B_manette"))
        {
            activeRadio = (int)radio.HipHop;
            textRadio.GetComponent<Text>().text = "radio : HipHop";
        }
        else if (Input.GetButton("X_manette"))
        {
            activeRadio = (int)radio.Electro;
            textRadio.GetComponent<Text>().text = "radio : Electro";
        }
        else if (Input.GetButton("Y_manette"))
        {
            activeRadio = (int)radio.Rock;
            textRadio.GetComponent<Text>().text = "radio : Rock";
        }
        #endregion
    }

	void lostPnj()
	{
		pnjLifeCurrent--;

		if (pnjLifeCurrent <= 0) {

			GameObject lastCharacter = null;
			foreach(GameObject character in caracControl.characters) {
				if(character.activeInHierarchy) {
					lastCharacter = character;
				}
			}

			killCharacter(lastCharacter);

			if(lifes > 0) {
				pnjLifeCurrent = pnjLife;
			}
		}
		
		textPNJLife.GetComponent<Text> ().text = "Asimov : " + pnjLifeCurrent.ToString ();
	}

	public void killCharacter(GameObject character)
	{
		lifes--;
		
		int i = 0;
		while (caracControl.characters[i].gameObject != character) {
			i++;
		}
		
		caracControl.characters [i].SetActive (false);
	}
}
