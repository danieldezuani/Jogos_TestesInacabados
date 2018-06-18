using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour {
    public GameObject TiroBoss;
    public GameObject pontuacao;

    private Vector2 cameraMin;
    private int life;
    // Use this for initialization
    void Start () {
        life = 3;
        cameraMin = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < cameraMin.y)
         ReposicionaBala();
        if (life <= 0)
        {
            TiroBoss.GetComponent<SpriteRenderer>().enabled = false;
            TiroBoss.GetComponent<CircleCollider2D>().enabled = false;
        }
    }
    public void ReposicionaBala()
    {
        life = 3;
        TiroBoss.GetComponent<SpriteRenderer>().enabled = true;
        TiroBoss.GetComponent<CircleCollider2D>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
            life -= 1;
        if (other.CompareTag("Bullet02") || other.CompareTag("Especial"))
        { 
            life -= 3;
            pontuacao.GetComponent<GameManager>().SomaPontos();
        }
        if (other.CompareTag("Bullet") && life <= 1)
        {
            pontuacao.GetComponent<GameManager>().SomaPontos();
        }
        if (other.CompareTag("Player")&& !Scr_Player.ivuneravel)
        {
            TiroBoss.GetComponent<SpriteRenderer>().enabled = false;
            TiroBoss.GetComponent<CircleCollider2D>().enabled = false;
        }

    }
}
