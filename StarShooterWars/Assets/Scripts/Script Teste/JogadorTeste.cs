using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorTeste : MonoBehaviour 
{

	private Rigidbody2D rb;
	private float h;
	private float v;
	public float velocity;

	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();	
	}
	

	void Update () 
	{
		h = Input.GetAxis ("Horizontal");
		v = Input.GetAxis ("Vertical");
		rb.velocity = new Vector2 (h, v).normalized * velocity * Time.deltaTime;
	}
}
