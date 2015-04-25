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

    private AudioSource Drum;
    private AudioSource Bass;
    private AudioSource Lead;
    private AudioSource Pad;

    void Awake()
    {
        manager = GameObject.Find("_manager").GetComponent<Manager>();

        Drum = GameObject.Find("Personnage 0").GetComponent<AudioSource>();
        Bass = GameObject.Find("Personnage 1").GetComponent<AudioSource>();
        Lead = GameObject.Find("Personnage 2").GetComponent<AudioSource>();
        Pad = GameObject.Find("Personnage 3").GetComponent<AudioSource>();
    }

	// Update is called once per frame
	void Update () {

        if (radioManager != manager.activeRadio)
        {
            radioManager = manager.activeRadio;

            if (manager.activeRadio == 0)
            {
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
                Drum.Stop();

                Bass.Stop();

                Lead.Stop();

                Pad.Stop();
            } 
        }

	}
}
