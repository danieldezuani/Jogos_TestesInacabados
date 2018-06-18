using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Bullet2 : MonoBehaviour {
    public GameObject objectGun2;
    public GameObject pontuacao;
    private Vector2 positionBullet2;
    private float speedBullet2;
    private Vector2 cameraHeight;
    public GameObject raioDeExplosao;
    private float tempoDeEspera = 0.0f;
    private bool hitouInimigo;
    public GameObject spriteBullet;
    private AudioSource somExplosao;

    // Use this for initialization
    void Start () {
        somExplosao = GetComponent<AudioSource>();
        speedBullet2 = 3f;
        cameraHeight = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        raioDeExplosao.SetActive(false);
        hitouInimigo = false;
        spriteBullet.GetComponent<SpriteRenderer>().enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        positionBullet2 = new Vector2(transform.position.x, transform.position.y + speedBullet2 * Time.deltaTime);
        transform.position = positionBullet2;
        if (transform.position.y > cameraHeight.y)
            ReposicionaBala();
        HitouInimigo();
    }

    void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.CompareTag("Enemy") || enemy.CompareTag("Boss") || enemy.CompareTag("TiroBoss02") || enemy.CompareTag("Asteroid"))
        {
            somExplosao.Play();
            speedBullet2 = 0f;
            hitouInimigo = true;
            HitouInimigo();
        }
    }

    public void HitouInimigo()
    {
        if (hitouInimigo == true) //Verifica se a bala acertou o inimigo
        {
            raioDeExplosao.SetActive(true); // se acertou ativa o raio de explosao
            spriteBullet.GetComponent<SpriteRenderer>().enabled = false; // desativa o sprite do missle
            tempoDeEspera += Time.deltaTime; // comeca a contagem até terminar a animacao da explosao
            
            if (tempoDeEspera >= 0.5f) // se a contagem (tempo da animacao) acabar
            {
                spriteBullet.GetComponent<SpriteRenderer>().enabled = true; // o sprite do missle pode voltar
                speedBullet2 = 3f; // velocidade do missle tb volta
                raioDeExplosao.SetActive(false); // raio de explosao é desativado
                hitouInimigo = false; // a bala nao hitou o inimigo pois ela vai voltar pra pool
                ReposicionaBala(); // reposiciona a bala na pool
                tempoDeEspera = 0.0f; // reseta a contagem
            }
        }
    }

    public void ReposicionaBala()
    {
        if (Scr_Gun.total2 == 5)
        {
            for (int i = 0; i < 5; i++)
                Scr_Gun.balasDisponiveis2[i] = true;

            Scr_Gun.total2 = 0;
        }
        this.gameObject.SetActive(false);
    }
}
