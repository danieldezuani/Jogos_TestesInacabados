using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {


	private bool moveBullet;
	private Animator anim;
	private Vector2 cameraHeight;
	private AudioSource shootSound;

	void Start () 
	{
		moveBullet = false;
		anim = GetComponent<Animator> ();
		cameraHeight = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		shootSound = GetComponent<AudioSource> ();
	}
	

	void Update () 
	{
		if (moveBullet)
			transform.position = new Vector2 (transform.position.x, transform.position.y - 0.1f);

		if (transform.position.y < cameraHeight.y)
			ReporEnemyBullet ();
	}

	public void AcionaTiro()//evento ativado no final da primeira animação 
	{ 
		moveBullet = true;
		transform.position = new Vector2 (transform.position.x, transform.position.y - 0.1f);
		SoundShoot ();
	}

	void OnTriggerEnter2D(Collider2D player)
	{
		if (player.CompareTag ("Player")) 
		{
			anim.SetBool ("playerCol", true);
			moveBullet = false;
		}
        if (player.CompareTag("Especial"))
        {
            ReporEnemyBullet();
        }
    }

	//função também chamada no final da animação de explosao 
	public void ReporEnemyBullet()
	{
		this.gameObject.SetActive (false);
		Scr_Enemy.timeShoot = 0;
	}

	public void SoundShoot()//evento ativado no final da primeira animação 
	{
		shootSound.time = 0.8f;
		shootSound.Play();
	}
}
