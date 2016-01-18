// CREATE SPAWNPOINT OBJECT AND ATTACH IT TO PLAYER
// ATTACH THIS SCRIPT TO SPAWNPOINT
// DOWNLOAD projectile.png FROM THE ART FOLDER ON GOOGLE DRIVE AND UPLOAD IT TO RESOURCES FOLDER TO GET PREFAB

using UnityEngine;
using System.Collections;

public class PlayerRangedAttack : MonoBehaviour {
	// Throw the weapon as a projectile attack. Damaging units on its direct coarse.
	// It will come back on its own, and if the player moves toward it, it will return to turn faster.
	// In the duration it is being a projective our character does not have the weapon, and can not use it.
	// The glow moves with it, meaning it can be used to look ahead.
	// Range, return speed and damage scale with level. Doing this drains charge notably.
	// It always flies forward, and if the girls moves while it is our, comes back to her new position.
	
	// Use this for initialization
	//Animator anim;
	public GameObject prefab;
	private bool projectileShot;
	public Rigidbody2D rb2;
	public GameObject projectile;
	private Vector2 direction;
	private Vector2 playerPosition;
	private Vector2 SpawnPos;
	private float x;
	private float y;
	
	
	void Start ()
	{
		//Animator = GetComponent<Animator>();
		prefab = Resources.Load("projectile") as GameObject;
	}
	
	// Update is called once per frame
	void Update ()
	{
		x = GetComponent<Transform>().position.x;
		y = GetComponent<Transform>().position.y;

		if(Input.GetKey (KeyCode.D)){
			direction = Vector2.right;
			x = 0.2f;
			y = 0.0f;
			transform.position = new Vector2 (x, y);
			
		}
		if(Input.GetKey (KeyCode.A)){
			direction = -Vector2.right;
			x = -0.2f;
			y = 0.0f;
			transform.position = new Vector2 (x, y);
			
		}
		if(Input.GetKey (KeyCode.W)){
			direction = Vector2.up;
			x = 0.0f;
			y = 0.2f;
			transform.position = new Vector2 (x, y);
			
		}
		if(Input.GetKey (KeyCode.S)){
			direction = -Vector2.up;
			x = 0.0f;
			y = -0.2f;
			transform.position = new Vector2 (x, y);
			
		}

		//anim.SetTrigger("Attack");
		//get target hp and deal dmg to it
		
		if (Input.GetMouseButtonDown (0)) {
			playerPosition = new Vector2 (transform.position.x, transform.position.y);
			projectile = Instantiate (prefab) as GameObject;
			Rigidbody2D rb = projectile.AddComponent<Rigidbody2D> ();
			rb2 = Instantiate (rb, transform.position, transform.rotation) as Rigidbody2D;
			//rb2 = (Rigidbody) Instantiate (rb, transform.position, transform.rotation);
			rb2.AddForce (direction * 200);
		}
	}


}

