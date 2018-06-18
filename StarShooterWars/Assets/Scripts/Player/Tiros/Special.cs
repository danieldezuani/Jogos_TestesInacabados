using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special : MonoBehaviour {
    public GameObject especial;
    public GameObject pontuacao;

    private float tempoDeAnimacaoEspecial = 0.0f;
	
	// Update is called once per frame
	void Update () {
        tempoDeAnimacaoEspecial += Time.deltaTime;
        if (tempoDeAnimacaoEspecial >= 0.45f)
        {
            especial.SetActive(false);
            tempoDeAnimacaoEspecial = 0.0f;
        }
    }

    void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.CompareTag("Enemy"))
        {
            pontuacao.GetComponent<GameManager>().SomaPontos();
        }
    }
}
