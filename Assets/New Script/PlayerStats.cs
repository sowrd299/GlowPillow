using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {
	public float maxHealth = 50f;
	public float curHealth;
	public float Speed = 3f;
	public float Level = 0f;
	public float dmg = 10f;
	public float range = 1f;
	//private bool damaged = false;
	private bool isDead = false;
	private float nextLevelUp = 20;
	private float currentXP = 0;
	PlayerManager playermanager;
	private bool blankie_on = false;
	// Use this for initialization
	void Awake()
	{

		playermanager = GetComponent<PlayerManager>();
		curHealth = maxHealth;

	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(playermanager.on == true)
		{
			blankie_on = true;
		}
		else
		{
			blankie_on = false;
		}

		AdjustCurrentHealth(0);
	}

	public void gainExperience(int amount)
	{
		currentXP += amount;
		if (currentXP >= nextLevelUp)
		{
			currentXP = 0;
			Debug.Log("Gain level");
			levelUp();
		}

	}

	void levelUp()
	{
		nextLevelUp += 20;
		maxHealth += 50;
		Level += 1;

	}
	public void AdjustCurrentHealth(int adj)
	{
		curHealth += adj;
		if (curHealth < 0)
			curHealth = 0;
		if(curHealth > maxHealth)
			curHealth = maxHealth;
		if(maxHealth < 1)
			maxHealth = 1;
	}

	public void TakeDamage(float amount)
	{

		if (blankie_on == true)
		{
			//damaged = true;
			curHealth -= (amount * .40f);
			Debug.Log(curHealth);
		}

		else
		{
			//damaged = true;
			curHealth -= amount;
			Debug.Log(curHealth);
		}

		if(curHealth <= 0 && !isDead)
		{
			Debug.Log("You are dead!!!");
			Death();
		}
	}



	public void Death()
	{
		isDead = true;
		//anim.SetTrigger("Die");
		//display death animation and stop all action (movement, ability)

	}


	public float getCurHealth(){
		//Debug.Log("Returning "+curHealth.ToString());
		return curHealth;
	}

	public float getMaxHealth(){
		return maxHealth;
	}
}
