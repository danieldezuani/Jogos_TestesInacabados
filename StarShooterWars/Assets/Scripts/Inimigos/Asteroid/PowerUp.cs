using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {
    private GameObject powerUpSprite;
    private GameObject powerUpCollider;
    private bool pegouPowerUp;

	// Use this for initialization
	void Start () {
        powerUpSprite.GetComponent<SpriteRenderer>().enabled = true;
        powerUpCollider.GetComponent<CircleCollider2D>().enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (pegouPowerUp == true) {
            powerUpSprite.GetComponent<SpriteRenderer>().enabled = false;
            powerUpCollider.GetComponent<CircleCollider2D>().enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pegouPowerUp = true;
        }
    }
}
