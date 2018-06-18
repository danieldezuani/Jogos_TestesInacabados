using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Gun : MonoBehaviour 
{
    
	//Arma1
	public GameObject[] bullets = new GameObject[10];
	public static bool[] balasDisponiveis = new bool[10];
	public static int total;
    private AudioSource tiro1;
    //Arma2
    public GameObject[] bullets2 = new GameObject[5];
    public static bool[] balasDisponiveis2 = new bool[5];
    public static int total2;
    private float tempoDeEspera = 0.0f;
    private bool primeiroTiro;
    private AudioSource tiro2;
    //Especial
    public GameObject especial;
    private float tempoDeEsperaEspecial = 0.0f;
    private AudioSource tiro3;

    //variavel para teste
    //private float teste = 0;

    public static int arma;
	private AudioSource[] audioGun;
    private AudioSource trocandoDeArmas;
	

	void Start () 
	{
		//Audio
		audioGun = GetComponents<AudioSource> ();
		tiro1 = audioGun [0];
        tiro2 = audioGun [1];
        tiro3 = audioGun [2];
        trocandoDeArmas = audioGun[3];

        //ARMA1
        total = 0;
		for (int i = 0; i < 10; i++) 
		{
			balasDisponiveis [i] = true;
			bullets [i].gameObject.SetActive (false);
		}
        //ARMA2
        primeiroTiro = false;
        total2 = 0;
        for (int i = 0; i < 5; i++)
        {
            balasDisponiveis2[i] = true;
            bullets2[i].gameObject.SetActive(false);
        }

        //ESPECIAL
        especial.SetActive(false);

        arma = 1;
	}
	

	void Update () 
	{
		if (GameManager.life > 0) {
			//Primeiro Tiro
			if (Input.GetButtonDown ("Fire1") && arma == 1) {
				DisparaArma1 ();
				tiro1.time = 0.40f; //Inicia o audio nesse tempo
				tiro1.Play ();
			}
			if (Input.GetButtonDown ("Fire1") && arma == 2 && primeiroTiro == false) { // só sera usado como primeiro tiro
				DisparaArma2 ();
				tiro2.Play ();
				primeiroTiro = true;
            
			}
			//------------------------
			//Segundo Tiro
			if (primeiroTiro == true)
				tempoDeEspera += Time.deltaTime; // comeca a contagem
			if (Input.GetButtonDown ("Fire1") && arma == 2 && primeiroTiro == true && tempoDeEspera >= 3.5f) { // um tiro a cada 3,5s
				DisparaArma2 ();
				tiro2.Play ();
				tempoDeEspera = 0.0f; // reseta o tempo para poder contar novamente
				tempoDeEspera += Time.deltaTime; // comeca a contagem dnv
			}
			//------------------------
			//Especial
			tempoDeEsperaEspecial += Time.deltaTime;
			//teste de tempo
			//print(teste += Time.deltaTime);
			if (Input.GetButtonDown ("Jump") && tempoDeEsperaEspecial >= 60.0f) { // Se apertar SPACE e o tempo for maior ou igual a 60s
				especial.SetActive (true); // ativa o special
				tiro3.Play (); // da play no som do especial
				tempoDeEsperaEspecial = 0.0f; // reseta a contagem do special
				//tempoDeAnimacaoEspecial += Time.deltaTime;
				//comecouEspecial = true;
			}
			if (Input.GetButtonDown ("Fire2")) {
				arma++;
                trocandoDeArmas.Play ();
				if (arma > 2)
					arma = 1;
			}
		}
	}

	public void DisparaArma1()
	{
        for (int i = 0; i < 10; i++)
			if (balasDisponiveis [i] == true) 
			{
				balasDisponiveis [i] = false;
				bullets [i].gameObject.transform.position = new Vector2 (transform.position.x, transform.position.y);
				bullets [i].gameObject.SetActive (true);
				i = 10;
				total++;
			}
	}

	public void DisparaArma2()
	{
        for (int i = 0; i < 5; i++)
        {
            if (balasDisponiveis2[i] == true)
            {
                balasDisponiveis2[i] = false;
                bullets2[i].gameObject.transform.position = new Vector2(transform.position.x, transform.position.y);
                bullets2[i].gameObject.SetActive(true);
                i = 5;
                total2++;
            }
        }
    }
}
