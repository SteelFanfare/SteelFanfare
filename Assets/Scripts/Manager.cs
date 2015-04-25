using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    public int lifes;
    public int score;
    public int PNJDead;

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

	void Awake () 
    {
        //radio de base : pas de radio
        activeRadio = (int)radio.NoRadio;
        textRadio = GameObject.Find("TextRadio").GetComponent<Text>();
        textRadio.text = "radio : No-Radio";
        slider = GameObject.Find("Slider").GetComponent<Slider>();
        scoreText = GameObject.Find("TextScore").GetComponent<Text>();
	}
	
	void Update ()
    {
        slider.value = PNJDead;
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
}
