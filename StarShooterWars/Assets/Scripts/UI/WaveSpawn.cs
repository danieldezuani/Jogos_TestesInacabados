using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawn : MonoBehaviour {
	public GameObject[] wave1 = new GameObject[3];
	public GameObject[] wave2 = new GameObject[3];
	public GameObject boss;
    public GameObject asteroid;
	public Waves wavesScript;
	public static int restanteWave1;
	public static int restanteWave2;
	public static int naves_T1_EmCena;
	public static int naves_T2_EmCena;

	private float time;

	// Use this for initialization
	void Start () 
	{
        Waves.chamaBoss = false;
        Boss.venceu = false;
		time = 0f;

		// variaveis chamadas no Scr_Enemy - DestroyEnemy()
		restanteWave1 = 10;
		naves_T1_EmCena = 3;

		restanteWave2 = 0;
		naves_T2_EmCena = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		time += Time.deltaTime;
		CriaAsteroid();

		//wave1
		if (Waves.chamaWave1)//variavel do script waves que inicia wave1
			StartWave1();

		//repoe inimigos e faz a contagem para mudar de wave
		if (naves_T1_EmCena < 3 && restanteWave1 >= 3) 
		{
			for (int i = 0; i < 3; i++)
				if (wave1[i].gameObject.activeInHierarchy == false) 
				{
					float posX = Random.Range (GameManager.cameraMin.x +0.5f, GameManager.cameraMax.x-0.5f);
					float posY = Random.Range (GameManager.cameraMax.y + 5f, 12.8f);
					Vector3 spawPos = new Vector3 (posX, posY, transform.position.z);
					Instantiate (wave1 [i], spawPos, Quaternion.identity);
                    naves_T1_EmCena++;
					wave1 [i].gameObject.SetActive (true);
					i = 3;
				}
					
		}
		//###########------------fim wave1------------###########

		//wave2
		if (restanteWave1 == 0)//chama o texto wave 2 no script Waves
		{
			Waves.waveAtual = "Wave2";
			restanteWave2 = 10;
			naves_T2_EmCena = 3;
		}
		if (Waves.chamaWave2)//variavel do script waves que inicia a wave2 
			StartWave2();

		//repoe inimigos e faz a contagem para mudar de wave
		if (naves_T2_EmCena < 3 && restanteWave2 >= 3) 
		{
			if (wave2 [0].gameObject.activeInHierarchy == false) 
			{
				float posX = Random.Range (GameManager.cameraMin.x +0.5f, GameManager.cameraMax.x-0.5f);
				wave2[0].transform.position = new Vector2 (posX, 6f);
				wave2 [0].gameObject.SetActive (true);
				naves_T2_EmCena++;
			}
			for (int i = 1; i < 3; i++)
				if (wave2[i].gameObject.activeInHierarchy == false) 
				{
					float posX = Random.Range (GameManager.cameraMin.x +0.5f, GameManager.cameraMax.x-0.5f);
					float posY = Random.Range (GameManager.cameraMax.y + 5f, 12.8f);
					Vector3 spawPos = new Vector3 (posX, posY, transform.position.z);
					Instantiate (wave2 [i], spawPos, Quaternion.identity);
					naves_T2_EmCena++;
					wave2 [i].gameObject.SetActive (true);
					i = 3;
				}

		}

		//###########------------fim wave2------------###########

		if (restanteWave2 == 0 && restanteWave1 <= 0) {
			Waves.waveAtual = "Boss";
		}
		if (Waves.chamaBoss)
			boss.gameObject.SetActive (true);
			
	}

	public void StartWave1()
	{
		for(int i=0; i<3; i++)
		{
			float posX = Random.Range (GameManager.cameraMin.x+0.5f, GameManager.cameraMax.x-0.5f);
			float posY = Random.Range (GameManager.cameraMax.y + 5f, 12.8f);
			Vector3 spawPos = new Vector3 (posX, posY, transform.position.z);
			Instantiate (wave1 [i], spawPos, Quaternion.identity);

        }
		Waves.chamaWave1 = false;
		Waves.waveAtual = "pausa";
	}

	public void StartWave2()
	{
		
		for(int i=1; i<3; i++)
		{
			float posX = Random.Range (GameManager.cameraMin.x+0.5f, GameManager.cameraMax.x-0.5f);
			float posY = Random.Range (GameManager.cameraMax.y + 5f, 12.8f);
			Vector3 spawPos = new Vector3 (posX, posY, transform.position.z);
			Instantiate (wave2 [i], spawPos, transform.rotation);
		}
		Waves.chamaWave2 = false;
		Waves.waveAtual = "pausa";
		wave2 [0].gameObject.SetActive (true);
	}

    public void CriaAsteroid()
    {
		float random;
		if (time >= 10f && !asteroid.gameObject.activeInHierarchy)
		{
			
			random = Random.Range (0, 101);
			print (random);
			if (random > 50 || Input.GetKeyDown(KeyCode.M)) 
			{
				float posX = Random.Range (GameManager.cameraMin.x +0.5f, GameManager.cameraMax.x-0.5f);
				asteroid.transform.position = new Vector2 (posX, 6f);
				asteroid.gameObject.SetActive (true);
				time = 0;
			}
		}

    }
}
