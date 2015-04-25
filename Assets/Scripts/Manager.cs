using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    public int lifes;
    public int score;

    public enum radio
    {
        Electro,
        Rock,
        HipHop,
        NoRadio
    }
    public int activeRadio;
    private GameObject textRadio;

	void Awake () 
    {
        //radio de base : pas de radio
        activeRadio = (int)radio.NoRadio;
        textRadio = GameObject.Find("TextRadio");
        textRadio.GetComponent<Text>().text = "radio : No-Radio";
        
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
}
