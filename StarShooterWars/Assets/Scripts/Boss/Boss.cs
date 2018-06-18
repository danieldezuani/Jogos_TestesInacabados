using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {
    Animator animator;
    private float random;
    private bool soltarAnim;
    private int life;
    private bool acertouBoss;

	public GameObject telaDeWin;
    public static bool venceu;
	// Use this for initialization
	void Awake()
	{
		this.gameObject.SetActive (false);
        venceu = false;
    }

	void Start () 
	{
        
		telaDeWin.SetActive (false);
        life = 1500;
        animator = GetComponent<Animator>();
        animator.Play("BossIdle");
        soltarAnim = true;
    }
	
	// Update is called once per frame
	void Update () 
	{
        AtaquesBoss();

		if (life <= 0) 
		{
			animator.Play("BossIdle");
            this.gameObject.SetActive(false);
			telaDeWin.SetActive (true);
            venceu = true;
		}
	}

    public void AtaquesBoss()
    {
        random = Random.Range(0f, 41f);
        //Tiro01 LASERZAO
        if (random < 41f && soltarAnim == true)
        {
            soltarAnim = false;
            animator.SetBool("Idle", false);
            animator.SetBool("Ataque02", false);
            print("ATAQUE 01");
            animator.Play("BossAtk");
            StartCoroutine(TempoAtk01());
        }
        //IDLE
        else if (random >41f && random <61f && soltarAnim == true)
        {
            soltarAnim = false;
            animator.SetBool("Ataque01", false);
            animator.SetBool("Ataque02", false);
            print("IDLE");
            animator.Play("BossIdle");
            StartCoroutine(TempoAtk01());
        }
        //TIRO 02 BOLINHAS
        else if (random > 61f && random < 101f && soltarAnim == true)
        {
            soltarAnim = false;
            animator.Play("BossAtk02");
            print("ATAQUE02");
            animator.SetBool("Ataque01", false);
            animator.SetBool("Idle", false);
            StartCoroutine(TempoAtk02());
        }
    }

    IEnumerator TempoAtk02()
    {
        yield return new WaitForSeconds(20);
        soltarAnim = true;
    }
    IEnumerator TempoAtk01()
    {
        yield return new WaitForSeconds(5);
        soltarAnim = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            life -= 2;
            print(life);
        }
        if (other.CompareTag("Bullet02"))
        {
            life -= 10;
            print(life);
        }
        if (other.CompareTag("Especial"))
        {
            life -= 50;
            print(life);
        }
    }
}
