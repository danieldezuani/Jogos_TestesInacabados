using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Enemy_Type2 : MonoBehaviour {

	public Transform playerPos;
	public GameObject [] bulletPrefab = new GameObject[3];
	public float enemyVelocity;

	private Animator anim;
    private AudioSource[] sons;
	private AudioSource shootSound;
    private AudioSource somExplosao;
    private Collider2D colisor;
	private float distancia;
	private float tempoAtual;
	private float posBulletX;
	private float posBulletY;
	private Vector2 posSpawnBullet;
	private Vector3 look;
	private float rotacaoZ;
	private bool recebeuDano;

	void Start () 
	{
        sons = GetComponents<AudioSource>();
        shootSound = sons[0];
        somExplosao = sons[1];
		recebeuDano = false;
		anim = GetComponent<Animator> ();
		colisor = GetComponent<Collider2D> ();
		colisor.enabled = true;

		for (int i = 0; i < 5; i++)
			bulletPrefab [i].gameObject.SetActive (false);
	}

	void Update () 
	{
		if (!recebeuDano) 
		{
			//nave olhar para o jogador
			look = new Vector3 (playerPos.position.x, playerPos.position.y, transform.position.z);
			rotacaoZ = Mathf.Atan2 (look.y, look.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler (0f, 0f, rotacaoZ - 90f);
		

			//calcula distancia do inimigo e do player
			distancia = Vector2.Distance (transform.position, playerPos.position);

			tempoAtual += Time.deltaTime;

			if (distancia > 1f)
				transform.position = Vector2.MoveTowards (transform.position, 
					playerPos.position, enemyVelocity * Time.deltaTime);

			if (tempoAtual > 3f)
				Atirar ();
		}
	}

	void Atirar()
	{
		shootSound.time = 0.8f;
		shootSound.Play();
		print ("Atirou");
		posBulletX = transform.position.x;
		posBulletY = transform.position.y;
		posSpawnBullet = new Vector2 (posBulletX, posBulletY);
		for (int i = 0; i < 5; i++)
			if (bulletPrefab [i].gameObject.activeInHierarchy == false) 
			{
				bulletPrefab [i].transform.position = posSpawnBullet;
				bulletPrefab [i].gameObject.SetActive (true);
				Bullet_EnemyT2.playerTarget = new Vector3 (playerPos.position.x, playerPos.position.y, transform.position.z);
				Bullet_EnemyT2.colidiu = false;
				i = 5;
			}
		tempoAtual = 0;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Bullet") || other.CompareTag ("Bullet02")  || other.CompareTag ("Especial")) 
		{
			recebeuDano = true;
			anim.SetBool ("Enemy2_Death", true);
            colisor.enabled = false;
            somExplosao.Play();
		}
	}

	public void DestroyEnemy()
	{
        anim.SetBool("Enemy2_Death", false);
        anim.Play("Enemy2_Idle");
        print("Funcionou");
        colisor.enabled = true;
        recebeuDano = false;
        WaveSpawn.restanteWave2--;
		WaveSpawn.naves_T2_EmCena--;
		gameObject.SetActive (false);
	}
}
