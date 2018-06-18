using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Loop : MonoBehaviour {

    float backgroundVel = 3f; // Se alterar vai influenciar na velocidade que o background desce
    Vector2 comecoPos; // Como só vamos mecher em um eixo(No caso Y), usamos o Vector2

	// Use this for initialization
	void Start () {
        comecoPos = transform.position; //Pega a posicao inicial do background
	}
	
	// Update is called once per frame
	void Update () {
        float novaPos = Mathf.Repeat(Time.time * backgroundVel, 10f); //Aqui criamos um novo float que armazena as novas posicoes do background, o Mathf.Repeat(FPS, velocidade que setamos, até que posicao ele vai antes de repetir o loop)
        transform.position = comecoPos + Vector2.down * novaPos; //Aqui só colocamos que a posicao do background é a posicao do comeco mais a nova posicao do background que vai descer até a nova posicao
	}
}
