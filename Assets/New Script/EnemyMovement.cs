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
		MinionsStats enemystats;
		public GameObject enemy;
		/// <summary>
		/// As of Now...Enemy has random Movement, will chase Player when spoted, will attempt to leave corner
		/// 
		/// Might not be running from walls.
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
			enemystats = enemy.GetComponent<MinionsStats>();
			speed = enemystats.Speed;
			detectRange = enemystats.DetectionRange; 

		}

		// Update is called once per frame
		private void FixedUpdate () {

			RandomDirection();

			avoid_wall();

			// David: Not sure what this code does, but it belongs in it's own function.
			distance = Vector2.Distance (Player, transform.position);
			Player = GameObject.Find ("Player").transform.position;
			if (stuntime > 0){
				stuntime -= Time.deltaTime;
			}
			else{
				stun = false;
			}
			// David: Code I don't know ^^^^

			walk_to_player();

			GetComponent<Rigidbody2D>().AddForce(direction.normalized * speed);

		}
			
		 private void RandomDirection(){
			if (Time.time >= tChange){
				tChange = Time.time + Random.Range (1.0f, 2.5f);
				direction = new Vector2(Random.Range (-1.5f, 1.5f), Random.Range (-1.5f, 1.5f));
			}
		}

		private void avoid_wall(){
		//if something or at certain time ~ prevent stuck at one position or spot
			if (Physics2D.Raycast(transform.position, direction ,.4f, Wall)){
			// this should take wall coordinates and move in oppossite direction
			direction = new Vector2(-direction.x, -direction.y);
			}
		}

		private void walk_to_player(){
			if (distance < detectRange && !stun){
				// direction points to player if within detectRange
				Xdif = Player.x - transform.position.x;
				Ydif = Player.y - transform.position.y;
				direction = new Vector2(Xdif, Ydif);
			}

			if (distance < .8 && !stun){
				// Keep a small distance between player.
				direction = new Vector2(0, 0);
			}
		}

		void OnCollisionEnter2D (Collision2D Playerhit){
			if (Playerhit.gameObject.tag == "player"){
				stun = true;
				stuntime = 0.5f;
			}
		}
	}
