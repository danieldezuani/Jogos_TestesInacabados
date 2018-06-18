using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr_LifeBar : MonoBehaviour 
{
	public Sprite[] spriteLife;
	public Image lifeBar;

	void Start () 
	{
		
	}
	public void RefreshLife(int playerHealth)
	{
		lifeBar.sprite = spriteLife [playerHealth];
	}
}
