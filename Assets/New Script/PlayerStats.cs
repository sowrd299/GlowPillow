using UnityEngine;
using System.Collections.Generic;
using System;

public class PlayerStats : MonoBehaviour {

    //public for unity
    public Exp exp;
    public string statUrl = "Assets/SoftCode/PlayerStats.csv";

    private Dictionary<string, float[]> statTable;

    public float maxHealth {//= 50f;
        get { return statTable["maxHealth"][Level]; }
    }
	private float curHealth;
    public float blankyResist {
        get { return statTable["blankyResist"][Level];  }
    }
	public float Speed = 3f;
    public int Level {//=0;
        get { return exp.Level; }
    }
	public float dmg { //=10f;
        get { return statTable["damage"][Level]; }
    }
	public float range { //= 1f;
        get { return statTable["range"][Level]; }
    }
    public float arc {
        get { return statTable["arc"][Level]; }
    }
    public bool invincible = false;
    public bool invisible = false; 
    //private bool damaged = false;
	private bool isDead = false;
	//private float nextLevelUp = 20;
	//private float currentXP = 0;
	PlayerManager playermanager;
	private bool blankie_on = false;

    // Use this for initialization
    void Awake() {
        statTable = StatsReader.ReadStats(statUrl);
        playermanager = GetComponent<PlayerManager>();
        exp.ExpPerLevel = Array.ConvertAll(statTable["exp"],new Converter<float,int>( x => (int)x ));
        Debug.Log(maxHealth);
        Debug.Log(dmg);
        Debug.Log(range);
        Debug.Log(blankyResist);
        curHealth = maxHealth;
	}

	void Update () {
        //manage the blanky
        blankie_on = playermanager.on;

		AdjustCurrentHealth(0);
	}

	public void gainExperience(int amount)
	{
        exp += amount;
    }

	public void AdjustCurrentHealth(float adj)
	{
		curHealth += adj;
		if (curHealth < 0)
			curHealth = 0;
		if(curHealth > maxHealth)
			curHealth = maxHealth;
	}

	public void TakeDamage(float amount)
	{

        if (blankie_on)
        {
            //damaged = true;
            curHealth -= (amount * blankyResist);
            Debug.Log(curHealth);
        }
        //in light zone
        else if (invincible)
        {
            //simply does not affect any of the health status
            curHealth -= 0; //probably not needed
            Debug.Log(curHealth);
        }

        else
        {
            if (!invincible) { 
                //damaged = true;
                curHealth -= amount;
                Debug.Log(curHealth);
            }
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
