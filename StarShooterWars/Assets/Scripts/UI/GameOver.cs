using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour 
{

	public Text best;
	public Text score;

	void Start () 
	{
		//Player prefs setadas no gameManager
		best.text = PlayerPrefs.GetInt ("bestScore").ToString ();
		score.text = PlayerPrefs.GetInt ("score").ToString ();
	}
	
	public void Menu()
	{
		SceneManager.LoadScene ("Menu");
	}

	public void ReturnGame()
	{
		SceneManager.LoadScene ("Stage01");
	}
}
