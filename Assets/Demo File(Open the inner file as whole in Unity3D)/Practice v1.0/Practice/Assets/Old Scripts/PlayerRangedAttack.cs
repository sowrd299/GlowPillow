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
	//public GameObject prefab;
	private bool projectileShot;
    //public GameObject projectile;
    private Rigidbody2D clone;
	//private Vector2 direction;
	private Vector2 playerPosition;
	private Vector2 SpawnPos;
    public float speed;
    public GameObject star;
    public float starThreshold = 0.5f;
    private float elapsetime = 0;
	private float x;
	private float y;
    private bool star_fired = false;
    private bool right = false;
    private bool left = false;
    private bool up = false;
    private bool down = false;
    public Vector2 direction;
    private bool star_condition;

    
    void Start ()
	{
		//Animator = GetComponent<Animator>();
		//prefab = Resources.Load("projectile") as GameObject;
	}
	
	// Update is called once per frame
	void Update ()
	{

        elapsetime += Time.deltaTime;
		x = GetComponent<Transform>().position.x;
		y = GetComponent<Transform>().position.y;

		if(Input.GetKey (KeyCode.D)){
			direction = Vector2.right;
            SpawnPos = new Vector2 (x + .65f, y);
         
		
		}
		if(Input.GetKey (KeyCode.A)){
			direction = -Vector2.right;
            SpawnPos = new Vector2 (x - .65f, y);
          
			
		}
		if(Input.GetKey (KeyCode.W)){
			direction = Vector2.up;
            SpawnPos = new Vector2 (x, y + .65f);
          
			
		}
		if(Input.GetKey (KeyCode.S)){
			direction = -Vector2.up;
            SpawnPos = new Vector2 (x, y - .65f);
           
			
		}

		//anim.SetTrigger("Attack");
		//get target hp and deal dmg to it
		
		if (Input.GetKey(KeyCode.G)) {
            if (elapsetime > starThreshold)
            {

                    Instantiate(star, SpawnPos, Quaternion.identity);
                    elapsetime = 0f;

            }
		}
	}
}

