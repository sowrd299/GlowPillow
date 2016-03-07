using UnityEngine;
using System.Collections;

/// <summary>
/// Minion Stats
/// 
/// </summary>
public class MinionsStats : MonoBehaviour {
	
	public float maxHealth = 100;
	public float curHealth = 100;
	public float Speed = 7;
	public float DetectionRange = 4;
	public float TranslatingDistance;
	public ArrayList Abilities; // <-- for dodges or run over water etc
	private bool damaged = false;
	private bool isDead = false;
	PlayerStats playerstats;

	// Use this for initialization
	void Awake() {
		curHealth = maxHealth;
	}

	// Update is called once per frame
	void Update () {
		AdjustCurrentHealth(0);
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
		if (isDead)
			return;
		damaged = true;
		curHealth -= amount;
		Debug.Log("Enemy Takes Damage");
		Debug.Log(curHealth);
		if(curHealth <= 0)
		{
			Debug.Log("Enemy Destroyed!!!");
			Death();
		}

	}

	public void Death()
	{
		isDead = true;
		//playerstats.gainExperience(20);
		Destroy(this.gameObject, 1);
		//destroy game object
		//anim.SetTrigger("Die");
		//display death animation and stop all action (movement, ability)

	}

}
