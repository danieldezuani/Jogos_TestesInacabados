using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_Player : MonoBehaviour
{
    public Transform gunPosition;
    public static float playerPositionX;
    public static float playerPositionY;
    public GameObject prefabBullet;
    public Scr_LifeBar ObjLife;

    private bool Button_W;
    private bool Button_S;
    private bool Button_A;
    private bool Button_D;
    public static bool ivuneravel;
    private bool pegouPowerUp;
    private float velocity;
    private float randomPowerUp;

    private Animator anim;
	private Collider2D colisor;
    private SpriteRenderer spriteRe;
    private AudioSource[] audiosPlayer;
    private AudioSource audioShooting;
    private AudioSource explosionPlayer;
    private AudioSource startSound;
    private bool gameOver;
    private float temp;

    void Awake()
    {
        velocity = 5f;
        anim = GetComponent<Animator>();
        audiosPlayer = GetComponents<AudioSource>();
        startSound = audiosPlayer[1];
        pegouPowerUp = false;
		colisor = GetComponent<Collider2D> ();
    }

    void Start()
    {
        ivuneravel = false;
        spriteRe = GetComponent<SpriteRenderer>();
        gunPosition = GameObject.Find("GunPosition").GetComponent<Transform>();
        gameOver = false;
        temp = 0;//tempo pra animar a morte do jogador quando gameOver == true;

        //Audios
        startSound.Play();//audio da nave chegando
        explosionPlayer = audiosPlayer[0];//audio da morte

        //vida e Score
        GameManager.life = 3;
        PlayerPrefs.SetInt("score", 0);//Inicia score sempre zero


    }

    void Update()
    {
        if (startSound.isPlaying)
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.05f + Time.deltaTime);

        playerPositionX = transform.position.x;
        playerPositionY = transform.position.y;

        Button_W = Input.GetKey(KeyCode.W);
        Button_S = Input.GetKey(KeyCode.S);
        Button_A = Input.GetKey(KeyCode.A);
        Button_D = Input.GetKey(KeyCode.D);

        if (gameOver)
            temp += Time.deltaTime;

        if (temp > 1)
            anim.SetBool("Death", true);

        //SorteiaPowerUps();
    }

    void FixedUpdate()
    {
        if (!gameOver && !startSound.isPlaying)
            Move();
    }

    public void Move()
    {
		//limitação de camera
        if (playerPositionY < GameManager.cameraMax.y - 0.7f)
            if (Button_W)
                transform.position = new Vector2(transform.position.x, transform.position.y + velocity * Time.deltaTime);

        if (playerPositionY > GameManager.cameraMin.y + 0.5f)
            if (Button_S)
                transform.position = new Vector2(transform.position.x, transform.position.y - (velocity - 2) * Time.deltaTime);

        if (playerPositionX > GameManager.cameraMin.x + 0.5)
            if (Button_A)
                transform.position = new Vector2(transform.position.x - velocity * Time.deltaTime, transform.position.y);
        if (playerPositionX < GameManager.cameraMax.x - 0.5f)
            if (Button_D)
                transform.position = new Vector2(transform.position.x + velocity * Time.deltaTime, transform.position.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.CompareTag("Enemy") || other.CompareTag("bulletEnemy") || other.CompareTag("Asteroid")
            || other.CompareTag("TiroBoss") || other.CompareTag("TiroBoss02")) && !ivuneravel) 
		{
			ObjLife = GameObject.Find ("LifeBar").GetComponent<Scr_LifeBar> ();

			if (GameManager.life > 0) 
			{
				ObjLife.RefreshLife (--GameManager.life);
				if(GameManager.life > 0)
				{
					ivuneravel = true;
					StartCoroutine (EfeitoDano ());//necessario usar StartCoroutine para usar um metodo de tipoe IEnumerator
				}
			}
			if(GameManager.life <= 0)
				PlayerDeath ();
		}
        if (other.CompareTag("PowerUp") && pegouPowerUp == false)
        {
            randomPowerUp = Random.Range(0, 101);
            if (randomPowerUp < 40f)
            {
                pegouPowerUp = true;
                velocity += 0.5f;
            }
            else if (randomPowerUp > 41f && randomPowerUp < 61f)
            {
                pegouPowerUp = true;
                velocity += 0.7f;
            }
            else if (randomPowerUp > 61f && randomPowerUp < 81f)
            {
                pegouPowerUp = true;
                velocity += 0.8f;
            }
            else if (randomPowerUp > 81f && randomPowerUp <= 101f)
            {
                pegouPowerUp = true;
                velocity += 1f;
            }
        }
	}

	IEnumerator EfeitoDano()//efeito para fazer o player piscar
	{
		for (float i = 0; i < 1f; i += 0.1f) 
		{
			spriteRe.enabled = false;
			yield return new WaitForSeconds (0.1f);
			spriteRe.enabled = true;
			yield return new WaitForSeconds (0.1f);
		}
		ivuneravel = false;
	}

	public void PlayerDeath()
	{
		gameOver = true;
		colisor.enabled = false;
		explosionPlayer.Play ();
	}

    //-------Sorteio dos PowerUps----------------//

    //public void SorteiaPowerUps()
    //{
      //  if (pegouPowerUp == true)
        //    velocity += 1f;
    //}
}
