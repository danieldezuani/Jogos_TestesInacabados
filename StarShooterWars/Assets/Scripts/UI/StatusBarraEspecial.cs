﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBarraEspecial : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public float TamanhoBarra(float valorMin, float valorMax) //qual o valor minimo e maximo da barra
    {
        return valorMin / valorMax; // retorna os valores
    }

    public int PorcentagemBarra(float valorMin, float valorMax, int fator) // qual o valor minimo, maximo e ate onde a porcentagem vai
    {
        return Mathf.RoundToInt(TamanhoBarra(valorMin, valorMax) * fator); // retorna a porcentagem em INT
    }
}