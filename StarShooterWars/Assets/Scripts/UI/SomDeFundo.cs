using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomDeFundo : MonoBehaviour {
    private AudioSource background;
    private AudioSource youWin;
    private AudioSource youLose;

    // Use this for initialization
    void Start () {
        background = GetComponent<AudioSource>();
        background.Play();
    }
	
	// Update is called once per frame
	void Update () {
        if (Boss.venceu == true) {
            background.Stop();
        }

    }
}
