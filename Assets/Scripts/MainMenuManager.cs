using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{
	public void StartButton()
	{
		SceneManager.LoadScene("MetroidvaniaLevel");
	}

	public void Quit()
	{
		Application.Quit();
	}
}
