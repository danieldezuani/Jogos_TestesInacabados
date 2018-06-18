using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour {
    
	//animação
	public GameObject wave01_Text;
    public GameObject wave02_Text;
    public GameObject wave03_Text;
	public static string waveAtual;


	public static bool chamaWave1 = false;//starta a função de criar as primeiras naves
	public static bool chamaWave2 = false;
	public static bool chamaBoss = false;
	private float tempoDeAnimWave;


    // Use this for initialization
    void Start () 
	{
        wave01_Text.SetActive(false);
        wave02_Text.SetActive(false);
        wave03_Text.SetActive(false);

        tempoDeAnimWave = 0f;
		waveAtual = "Wave1";
    }
	

	void Update ()
	{
		tempoDeAnimWave += Time.deltaTime;

		if (Input.GetKeyDown (KeyCode.I)) 
		{
			waveAtual = "Wave1";
		}
		if (Input.GetKeyDown (KeyCode.O)) 
		{
			waveAtual = "Wave2";
		}
		if (Input.GetKeyDown (KeyCode.P)) 
		{
			waveAtual = "Boss";
		}

		//wave 1
		if (tempoDeAnimWave >= 3f && waveAtual == "Wave1")
			CallWave1 ();
			
		//wave 2
		if (waveAtual == "Wave2") 
		{
			if (WaveSpawn.restanteWave1 == 0) 
			{
				tempoDeAnimWave = 0;
				WaveSpawn.restanteWave1 = -1;//Tem que por -1 pq essa var que chama a proxima wave
			}
			CallWave2 ();
		}

		//Boss
		if (waveAtual == "Boss") 
		{
			if(WaveSpawn.restanteWave2 == 0)
			{
				tempoDeAnimWave = 0;
				WaveSpawn.restanteWave2 = -1;//Tem que por -1 pq essa var que chama a proxima wave
			}
			CallBoss ();
		}
			
	}

	void CallWave1()
	{
			wave01_Text.SetActive (true);
			if (tempoDeAnimWave >= 7f) 
			{
				wave01_Text.SetActive (false);
				chamaWave1 = true;
			} 
	}
	
	void CallWave2()
	{
		if (tempoDeAnimWave >= 3f && tempoDeAnimWave < 7f)
			wave02_Text.SetActive (true);
		else if (tempoDeAnimWave >= 7f) {
			wave02_Text.SetActive (false);
			chamaWave2 = true;
		}
			
	}

	void CallBoss()
	{
		if (tempoDeAnimWave >= 3f && tempoDeAnimWave < 7f)
			wave03_Text.SetActive (true);
		else if (tempoDeAnimWave >= 7f) {
			wave03_Text.SetActive (false);
			chamaBoss = true;
			waveAtual = "pause";
		}
	}
}
