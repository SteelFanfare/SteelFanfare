using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {

    public int lifes;
    private enum radio
    {
        Electro,
        Rock,
        HipHop,
        NoRadio
    }
    public int activeRadio;

	void Awake () 
    {
        //radio de base : pas de radio
        activeRadio = (int)radio.NoRadio;
	}
	
	void Update ()
    {







        #region Input Radios
        if (Input.GetButton("A_manette"))
        {
            activeRadio = (int)radio.NoRadio;
        }
        else if (Input.GetButton("B_manette"))
        {
            activeRadio = (int)radio.HipHop;
        }
        else if (Input.GetButton("X_manette"))
        {
            activeRadio = (int)radio.Electro;
        }
        else if (Input.GetButton("Y_manette"))
        {
            activeRadio = (int)radio.Rock;
        }
        #endregion
    }
}
