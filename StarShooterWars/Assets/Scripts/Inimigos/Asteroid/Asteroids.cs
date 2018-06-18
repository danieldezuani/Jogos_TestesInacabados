using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour {
    public GameObject powerUp;
    public GameObject spritePowerUp;
    public GameObject colliderPowerUp;
    public GameObject spriteAsteroid;
    public GameObject colliderAsteroid;
    private string estado;

	private Animator animator;


	void Start () 
	{
        estado = "asteroid";
        powerUp.SetActive(false);
        spriteAsteroid.GetComponent<SpriteRenderer>().enabled = true;
        colliderAsteroid.GetComponent<PolygonCollider2D>().enabled = true;
		animator = GetComponent<Animator> ();

    }
	

	void Update () 
	{
        transform.position = new Vector2(transform.position.x, transform.position.y - 0.01f);

		//verifica se saiu da camera para poder ser instanciada novamente
		if (transform.position.y < GameManager.cameraMin.y -2f) 
		{
			if (estado == "powerUp") 
			{
				spriteAsteroid.GetComponent<SpriteRenderer> ().enabled = true;
				colliderAsteroid.GetComponent<PolygonCollider2D> ().enabled = true;
				powerUp.SetActive (false);
				estado = "asteroid";
			}
			this.gameObject.SetActive (false);
		}
    }

    public void AsteroidDestruido()//chamado no final da animação do asteroid explodindo
	{
		if (estado == "asteroid")// se o player colidir
			gameObject.SetActive (false);
		else //se a bala colidir
		{
			spriteAsteroid.GetComponent<SpriteRenderer> ().enabled = false;
			colliderAsteroid.GetComponent<PolygonCollider2D> ().enabled = false;
			powerUp.SetActive (true);
		}
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
		if ((other.CompareTag("Bullet") || other.CompareTag("Bullet02")) && estado == "asteroid")
        {
			animator.SetBool ("AsteroidDeath", true);
			estado = "powerUp";
        }
        if (other.CompareTag("Player") && estado == "powerUp")
        {
			estado ="asteroid";
			spriteAsteroid.GetComponent<SpriteRenderer> ().enabled = true;
			colliderAsteroid.GetComponent<PolygonCollider2D> ().enabled = true;
			powerUp.SetActive (false);
			gameObject.SetActive (false);
        }
        if (other.CompareTag("Player") && estado == "asteroid")
        {
			animator.SetBool ("AsteroidDeath", true);
        }
    }
}
