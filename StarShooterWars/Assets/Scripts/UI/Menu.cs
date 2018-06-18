using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public GameObject telaDeInstrucoes;
    public GameObject integrantes;
    public GameObject boss;

    public void Start()
    {
        boss.SetActive(false);
        telaDeInstrucoes.SetActive(false);
        integrantes.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        integrantes.SetActive(true);
    }

    public void OptionsMenu()
    {
        telaDeInstrucoes.SetActive(true);
    }

    public void BackOptionsMenu()
    {
        telaDeInstrucoes.SetActive(false);
    }

	public void BackToMenu()
	{
        boss.SetActive(false);
        SceneManager.LoadScene("Menu");
	}

    public void Play()
    {
        boss.SetActive(false);
        SceneManager.LoadScene("Stage01");
    }
}
