using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ArmaAtual : MonoBehaviour {
    public GameObject spriteArma01;
    public GameObject spriteArma02;


    // Use this for initialization
    void Start () {
        spriteArma01.SetActive(true);
        spriteArma02.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	    if(Scr_Gun.arma == 1) { 
            spriteArma01.SetActive(true);
            spriteArma02.SetActive(false);
        }
        else if (Scr_Gun.arma == 2)
        {
            spriteArma02.SetActive(true);
            spriteArma01.SetActive(false);
        }
    }
}
