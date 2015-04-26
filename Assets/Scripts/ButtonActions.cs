using UnityEngine;
using System.Collections;

public class ButtonActions : MonoBehaviour {

	public void goTutorial()
	{
		Application.LoadLevel ("tutorial");
	}

	public void goCredits()
	{
		Application.LoadLevel ("credits");
	}

	public void goTitle()
	{
		Time.timeScale = 1.0f;
		Application.LoadLevel ("titre");
	}

	public void startGame()
	{
		GameObject.Find ("ButtonStart").SetActive (false);

		GameObject TextLoading = GameObject.Find ("LoadingText");
		GameObject LoadingPosition = GameObject.Find ("LoadingPosition");

		TextLoading.transform.position = LoadingPosition.transform.position;

		Application.LoadLevel ("testScene");
	}

	public void quitGame()
	{
		Application.Quit ();
	}
}
