using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_EnemyT2 : MonoBehaviour {

	public static Vector3 playerTarget;
	private float b_Velocity;
	public static bool colidiu;
	private Animator anim;

	void Start () 
	{
		b_Velocity = 2f;
		anim = GetComponent<Animator> ();
		colidiu = false;
	}

	void Update () 
	{
		//olhar para o jogador
		Vector3 look = new Vector3 (playerTarget.x, playerTarget.y, transform.position.z);
		float rotacaoZ = Mathf.Atan2 (look.y, look.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler (0f, 0f, rotacaoZ + 90f);

		//dispara na direção do jogador
		if(!colidiu)
			transform.position += playerTarget *  b_Velocity * Time.deltaTime;


		if (transform.position.y < GameManager.cameraMin.y || transform.position.y > GameManager.cameraMax.y)			
			ReporBala ();
		if(transform.position.x < GameManager.cameraMin.x || transform.position.x > GameManager.cameraMax.x)
				ReporBala ();

	}

	void ReporBala()
	{
		this.gameObject.SetActive (false);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			anim.SetBool ("colisaoPlayer", true);
			colidiu = true;
		}
	}
}
