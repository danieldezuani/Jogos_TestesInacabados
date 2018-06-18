using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Bullet : MonoBehaviour 
{
    //ARMA1
	public GameObject objectGun;
	public GameObject pontuacao;
	private Vector2 positionBullet;
    private float speedBullet;

    private Vector2 cameraHeight;
	

	void Start () 
	{
		speedBullet = 5f;
		cameraHeight = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
	}
		
	void Update () 
	{
		//adiciona velocidade ao bala
		positionBullet = new Vector2 (transform.position.x, transform.position.y + speedBullet * Time.deltaTime);
        

        //atualiza posicao da bala
        transform.position = positionBullet;
        

			//destroi a bala se ela passar do limite da tela
		if (transform.position.y > cameraHeight.y) 
			ReposicionaBala ();
	}

	void OnTriggerEnter2D(Collider2D enemy)
	{
		if (enemy.CompareTag ("Enemy")) 
		{
			ReposicionaBala ();
			pontuacao.GetComponent<GameManager> ().SomaPontos ();
		}
		if (enemy.CompareTag("Boss") || enemy.CompareTag("TiroBoss02") || enemy.CompareTag("Asteroid"))
        {
            ReposicionaBala();
        }
    }

	public void ReposicionaBala()
	{
		if (Scr_Gun.total == 10) 
		{
			for (int i =0; i <10; i++)
				Scr_Gun.balasDisponiveis [i] = true;

			Scr_Gun.total = 0;
		}
        this.gameObject.SetActive(false);
	}
}
