using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {
	public float maxHealth = 100;
	public float curHealth = 100;
	public float Speed = 2;
	public float Level;
	public float dmg = 5;
	public float range = 0.5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		AddjustCurrentHealth(0);
	}


	public void AddjustCurrentHealth(int adj)
	{
		curHealth += adj;
		if (curHealth < 0)
			curHealth = 0;
		if(curHealth > maxHealth)
			curHealth = maxHealth;
		if(maxHealth < 1)
			maxHealth = 1;
	}
}
