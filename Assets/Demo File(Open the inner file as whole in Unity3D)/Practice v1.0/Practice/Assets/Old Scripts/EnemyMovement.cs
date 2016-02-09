using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	private Vector3 Player;
	private Vector2 Playerdirection;
	private float Xdif;
	private float Ydif;
	private float speed;
	private float detectRange;
	private int Wall;
	private int DPlayer;
	private float distance;
	private bool stun;
	private float stuntime; 


	//for Change Direction
	public float movementSpeed;
	private float tChange = 0;
	private float randomX;
	private float randomY;
	private Vector2 direction; 

    /// <summary>
    /// As of Now...Enemy has random Movement, will chase Player when spoted, will attempt to leave corner
    /// 
    /// It does not have fluent movement yet
    /// It does not have region patrol ability 
    /// It does do dmg to the player
    /// It does knock back the player
    /// 
    /// Still need adjustments.
    /// 
    /// </summary>

	void Start(){
		stuntime = 0;
		stun = false;
		Wall = 1 << 9;
		DPlayer = 1 << 10;
	}


	void Update(){

		GameObject enemy = GameObject.Find("Enemy");
		MinionsStats enemystat = enemy.GetComponent<MinionsStats>();
		speed = enemystat.Speed;
		detectRange = enemystat.DetectionRange; 

		//use change direction to randomize movement of AI
		RandomDirection();

		GetComponent<Rigidbody2D>().AddForce(direction.normalized * speed);
		//if something or at certain time ~ prevent stuck at one position or spot
		if (Physics2D.Raycast(transform.position, direction ,1.5f, Wall)){
			if (Time.time >= tChange){
				RandomDirection ();
				GetComponent<Rigidbody2D>().AddForce(direction.normalized * speed); 
				tChange = Time.time + Random.Range(0.5f, 1.5f);
			}
		}
	}


	void RandomDirection(){
		if (Time.time >= tChange){
			randomX = Random.Range (-1.5f, 1.5f);
			randomY = Random.Range (-1.5f, 1.5f);
			tChange = Time.time + Random.Range (0.5f, 1.5f);
			direction = new Vector2(randomX, randomY);
		}
	}


	// Update is called once per frame
	void FixedUpdate () {
		distance = Vector2.Distance (Player, transform.position);
		Player = GameObject.Find ("Player").transform.position;
		if (stuntime > 0){
			stuntime -= Time.deltaTime;
		}
		else{
			stun = false;
		}

		if (distance < detectRange && !stun){
			//calcualte the differences in distance (x,y) to player (x,y) --> move that distance if player spoted
			Xdif = Player.x - transform.position.x;
			Ydif = Player.y - transform.position.y;
	
			Playerdirection = new Vector2(Xdif, Ydif);

			if (Physics2D.Raycast(transform.position, Playerdirection, 2, Wall)){
				detectRange = 0;
				GetComponent<Rigidbody2D>().AddForce(Playerdirection.normalized * 0);
			}

			else if (Physics2D.Raycast(transform.position, Playerdirection, 3, DPlayer))
			{
				//get the rigidbody and add force directly to it
				GetComponent<Rigidbody2D>().AddForce(Playerdirection.normalized * speed);
			}
		}
	}

	void OnCollisionEnter2D (Collision2D Playerhit){
		if (Playerhit.gameObject.tag == "player"){
			stun = true;
			stuntime = 0.5f;
		}
	}
}
