using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour {

	public void exit()
	{
		Application.Quit(); 
	}

	public void play(int loadLevel)
	{
		Application.LoadLevel(loadLevel);
	}

	public void controlButton(int loadLevel)
	{
		Application.LoadLevel(loadLevel);
	}
}
