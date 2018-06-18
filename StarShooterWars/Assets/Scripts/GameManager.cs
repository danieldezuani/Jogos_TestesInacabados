using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static Vector2 cameraMin;
	public static Vector2 cameraMax;
	//pontuação
	public Text scoreHUD;
	private int score;
	public static int life;


	void Start () 
	{
		score = 0;
		cameraMin = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		cameraMax= Camera.main.ViewportToWorldPoint(new Vector2 (1,1));
	}
	

	void Update () 
	{
		if (life == 0)
			Invoke ("GameOver", 4f);

		//atalhos para waves;


			
	}

	public void SomaPontos()
	{
		score += 20;
		scoreHUD.text = score.ToString ();//faz a conversão de para string
	}

	public void GameOver()
	{
		if (PlayerPrefs.GetInt ("bestScore") < score)
			PlayerPrefs.SetInt ("bestScore", score);

		PlayerPrefs.SetInt ("score", score);

		SceneManager.LoadScene ("GameOver");
	}
}
