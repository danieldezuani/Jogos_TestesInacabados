using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Enemy : MonoBehaviour 
{
	private Animator anim;
	private Collider2D naveCol;
    private float tempoDescida;
    private float tempoDeEspera;
    private AudioSource somExplosao;
	public GameObject enemyBullet;
	public static float timeShoot;

	void Start () 
	{
        somExplosao = GetComponent<AudioSource>();
        anim = GetComponent<Animator> ();
		naveCol = GetComponent<Collider2D> ();
		timeShoot = 0f;
        tempoDescida = 0f;
        tempoDeEspera = 0f;
	}
	

	void Update () 
	{
        tempoDeEspera += Time.deltaTime;
            if (tempoDeEspera >= 5f)
            { 
            //faz com que o inimigo desca para a tela
            tempoDescida += Time.deltaTime;
            if (tempoDescida < 3f)
                transform.position = new Vector2(transform.position.x, transform.position.y - 0.046f);
            else if (tempoDescida >= 3f)
            { 
                transform.position = new Vector2(transform.position.x, transform.position.y);
                tempoDeEspera = 0f;
            }
        }

        //tempo para a bala se mover, bala so pode ser criada se o tempo de respawn tiver acabado
        if (tempoDescida >= 3f)
        { 
            timeShoot += Time.deltaTime;
		    if (timeShoot > 3f && timeShoot < 4f) 
		    {
			    enemyBullet.transform.position = new Vector2 (transform.position.x-0.1f, transform.position.y-0.5f);
			    enemyBullet.gameObject.SetActive (true);
		    }
        }

    }

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Bullet")) 
		{
			anim.SetBool ("Explosao", true);
			naveCol.enabled = false;
            somExplosao.Play();
		}
        if (other.CompareTag("Especial"))
        {
            anim.SetBool("Explosao", true);
            naveCol.enabled = false;
            somExplosao.Play();
        }
        if (other.CompareTag("Bullet02"))
        {
            anim.SetBool("Explosao", true);
            naveCol.enabled = false;
            somExplosao.Play();
        }
    }

	public void DestroyEnemy()
	{
		if (WaveSpawn.restanteWave1 >0) {
			WaveSpawn.restanteWave1--;
			WaveSpawn.naves_T1_EmCena--;
		}
		if (WaveSpawn.restanteWave2 > 0) {
			WaveSpawn.restanteWave2--;
			WaveSpawn.naves_T2_EmCena--;
			print (WaveSpawn.restanteWave2);
		}
		gameObject.SetActive (false);

	}
}
