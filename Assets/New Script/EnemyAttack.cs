using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {
	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 10;

	//Animator anim;
	GameObject player;
	PlayerStats playerStats;
	MinionsStats enemyStats;
	bool playerInRange;
	float timer;

	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag("Player");
		playerStats = player.GetComponent<PlayerStats>();
		enemyStats = GetComponent<MinionsStats>();
		//anim = GetComponent<Animator>();

	}


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player)
		{
			playerInRange = true;
		}
	}
	void OnTriggerExit(Collider other)
	{

		if(other.gameObject == player)
		{
			playerInRange = false;
		}
	}

	void Update () {
		timer += Time.deltaTime;
		if(timer >= timeBetweenAttacks && playerInRange && enemyStats.curHealth > 0)
		{
			Attack();
		}

	}

	void Attack()
	{
		timer = 0f; 


		if(playerStats.getCurHealth() > 0)
		{
			playerStats.TakeDamage(attackDamage);
		}

	}
}
