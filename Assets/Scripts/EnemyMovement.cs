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
				GetComponent<Rigidbody2D>().AddForce (Playerdirection.normalized * 0);
			}

			else if (Physics2D.Raycast(transform.position, Playerdirection, 2, DPlayer))
			{
				//get the rigidbody and add force directly to it
				GetComponent<Rigidbody2D>().AddForce(Playerdirection.normalized * speed);
			}
		}
	}

	void OnCollisionEnter2D (Collision2D Playerhit){
		if (Playerhit.gameObject.tag == "Player"){
			stun = true;
			stuntime = 0.5f;
		}
	}
}
