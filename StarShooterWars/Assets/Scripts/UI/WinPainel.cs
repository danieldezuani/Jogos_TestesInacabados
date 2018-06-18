using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPainel : MonoBehaviour {
	public GameObject boss;
    private AudioSource somWin;
	// Use this for initialization
	void Start () {
        somWin = GetComponent<AudioSource>();
        somWin.Play();
    }
	
	// Update is called once per frame
	void Update () {
            
	}

	public void BackToMenu()
	{
		SceneManager.LoadScene("Menu");
		boss.SetActive (false);
	}

	public void Play()
	{
		SceneManager.LoadScene("Stage01");
		boss.SetActive (false);
	}
}
