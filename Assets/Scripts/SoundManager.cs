using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    public AudioClip HipHop_D;
    public AudioClip HipHop_B;
    public AudioClip HipHop_L;
    public AudioClip HipHop_P;

    public AudioClip Electro_D;
    public AudioClip Electro_B;
    public AudioClip Electro_L;
    public AudioClip Electro_P;

    public AudioClip Rock_D;
    public AudioClip Rock_B;
    public AudioClip Rock_L;
    public AudioClip Rock_P;

    private Manager manager;
    private int radioManager;
    private CharacControl CharacterControl;

    private AudioSource Drum;
    private AudioSource Bass;
    private AudioSource Lead;
    private AudioSource Pad;

    void Awake()
    {
        manager = GameObject.Find("_manager").GetComponent<Manager>();
        CharacterControl = GameObject.Find("GroupeJoueur").GetComponent<CharacControl>();

        Drum = GameObject.Find("SoundRobot_1").GetComponent<AudioSource>();
        Bass = GameObject.Find("SoundRobot_2").GetComponent<AudioSource>();
        Lead = GameObject.Find("SoundRobot_3").GetComponent<AudioSource>();
        Pad = GameObject.Find("SoundRobot_4").GetComponent<AudioSource>();
    }

	// Update is called once per frame
	void Update () 
    {

            if (radioManager != manager.activeRadio)
            {
                radioManager = manager.activeRadio;

                if (manager.activeRadio == 0)
                {
                    Drum.volume = 1.0f;
                    Bass.volume = 1.0f;
                    Lead.volume = 1.0f;
                    Pad.volume = 1.0f;

                    Drum.clip = Electro_D;
                    Drum.Play();

                    Bass.clip = Electro_B;
                    Bass.Play();

                    Lead.clip = Electro_L;
                    Lead.Play();

                    Pad.clip = Electro_P;
                    Pad.Play();
                }
                else if (manager.activeRadio == 1)
                {
                    Drum.volume = 1.0f;
                    Bass.volume = 1.0f;
                    Lead.volume = 1.0f;
                    Pad.volume = 1.0f;

                    Drum.clip = Rock_D;
                    Drum.Play();

                    Bass.clip = Rock_B;
                    Bass.Play();

                    Lead.clip = Rock_L;
                    Lead.Play();

                    Pad.clip = Rock_P;
                    Pad.Play();
                }
                else if (manager.activeRadio == 2)
                {
                    Drum.volume = 1.0f;
                    Bass.volume = 1.0f;
                    Lead.volume = 1.0f;
                    Pad.volume = 1.0f;

                    Drum.clip = HipHop_D;
                    Drum.Play();

                    Bass.clip = HipHop_B;
                    Bass.Play();

                    Lead.clip = HipHop_L;
                    Lead.Play();

                    Pad.clip = HipHop_P;
                    Pad.Play();
                }
                else if (manager.activeRadio == 3)
                {
                    Drum.volume = 0.0f;

                    Bass.volume = 0.0f;

                    Lead.volume = 0.0f;

                    Pad.volume = 0.0f;
                }
            }

            if (CharacterControl.characters[0].active == false)
            {
                Drum.volume = 0;
            }

            if (CharacterControl.characters[1].active == false)
            {
                Bass.volume = 0;
            }
            if (CharacterControl.characters[2].active == false)
            {
                Lead.volume = 0;
            }
            if (CharacterControl.characters[3].active == false)
            {
                Pad.volume = 0;
            }





	}
}
