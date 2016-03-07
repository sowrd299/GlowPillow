using UnityEngine;
using System.Collections;

public class Blankie : MonoBehaviour {
	private float Hittime;
	private Vector2 facedirection;
	//private float dmg;
	//private float health;
	public GameObject enemy;
	public EnemyAttack enemyAttack;
	private float damage;
	//PlayerStats playerStats;
	/// <summary>
	/// Blankie has a missing art issue. The collider should be the same size as the player object at all time
	/// </summary>



	void Update()
	{


	}

    //knock enemy back
	void OnTriggerEnter2D(Collider2D Enemyhit){
		Debug.Log("Knock the enemy back");
		//GameObject thePlayer = GameObject.Find("Player");
		enemyAttack = enemy.GetComponent<EnemyAttack>();
		//playerStats = thePlayer.GetComponent<PlayerStats>();
		//Hittime is to make sure the enemy on collision doesnt kill you by sticking and overlay
		//if the gameobject hit is a Enemy then take knockback and dmg
		if (Enemyhit.gameObject.tag == "Enemies")
		{

			//Deal dmg only per this amount of time (cool down)
			if (Hittime + 0.25f < Time.time)
			{
				Debug.Log("enemy knock back");
				Hittime = Time.time;
				float verticalpush = Enemyhit.gameObject.transform.position.y - transform.position.y;
				float horizontalpush = Enemyhit.gameObject.transform.position.x - transform.position.x;
				//Check the target rigidbody and knock it back
				Debug.Log(enemy);
				enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(horizontalpush * 1500, verticalpush * 1500));
				// this value has to change to base on character level
				//this is actually affecting the Health variable in HeroStat
				//Debug.Log (playerStats.curHealth);
			}
		}
	}
}
