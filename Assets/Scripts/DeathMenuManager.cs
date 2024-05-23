using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeathMenuManager : MonoBehaviour
{
	public void Restart()
	{
		SceneManager.LoadScene("MetroidvaniaLevel");
	}

	public void Quit()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
