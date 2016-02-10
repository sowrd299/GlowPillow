using UnityEngine;
using System.Collections;


//Player movement now contains basic attack ()

public class PlayerManager : MonoBehaviour {

	public string facedirection;
	private Vector2 player_position;
	//Rigidbody2D rbody;
	public Animator anim;
	private Vector2 face_direction;
	private float speed;
	public PlayerAbility _playerability;
	public PlayerStats _playerstats;
	private float attackTimer;
	private float coolDown;
	public float sprint;
	private bool on = false;
	private bool off = true;
	public float useRate = 0.5f;
	private float nextUse;


	void start(){
		//setting player object by finding the player
		//rbody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		facedirection = "down";
		attackTimer = 0;
		coolDown = 2.0f;
	}

	void Update(){
		
		if (attackTimer > 0)
			attackTimer -= Time.deltaTime;
		if (attackTimer < 0)
			attackTimer = 0;
		
		if(Input.GetKeyDown(KeyCode.E))
		{
			if (attackTimer == 0){
				_playerability.PlayerAttack();
				attackTimer = coolDown;
			}
		}


		if(Input.GetKeyDown(KeyCode.R))
		{
			if (attackTimer == 0){
				_playerability.PlayerRangeAttack();
				attackTimer = coolDown;
			}
		}


		if(off){
			if(Input.GetKeyDown(KeyCode.Q))
			{
				Debug.Log("Use Blankie");
				anim.SetBool("blankie_swing", true);
				nextUse = Time.time + useRate;
				off = false;
				on = true;
			}
		}
		else
		{if(on && nextUse < Time.time){
				if(Input.GetKeyDown(KeyCode.Q)){
					anim.SetBool("blankie_swing", false);
					nextUse = Time.time + useRate;
					off = true;
					on = false;
					Debug.Log("Blankie Removed");
				}

			}

		}

	}
	// Update is called once per frame
	void Sprint(){
		if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))){
			speed = _playerstats.Speed * sprint;
		}
	}


	void FixedUpdate()
	{
		speed = _playerstats.Speed;
		Sprint();

		if (Input.GetKey(KeyCode.RightArrow)){
			//facedirection = "right";
			anim.SetBool("right", true);
			anim.SetBool("left", false);
			anim.SetBool("up", false);
			anim.SetBool("down", false);
			//anim.SetBool("WalkRight", true);
			transform.Translate(Vector2.right * speed);
			//face_direction = new Vector2(1,0);
			facedirection = "right";
			anim.SetBool("WalkRight", true);
		}
		else
		{	
			anim.SetBool("WalkRight", false);
		}	

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			//facedirection = "left";
			anim.SetBool("left", true);
			anim.SetBool("right", false);
			anim.SetBool("up", false);
			anim.SetBool("down", false);
			//anim.SetBool("WalkLeft", true);
			transform.Translate(-Vector2.right * speed);
			//face_direction = new Vector2(-1,0);
			facedirection = "left";
			anim.SetBool("WalkLeft", true);
		}
		else
		{
			anim.SetBool("WalkLeft", false);
		}


		if (Input.GetKey(KeyCode.UpArrow))
		{
			//facedirection = "up";
			anim.SetBool("up", true);
			anim.SetBool("right", false);
			anim.SetBool("left", false);
			anim.SetBool("down", false);
			// anim.SetBool("WalkUp", true);
			transform.Translate(Vector2.up * speed);
			//face_direction = new Vector2(0,1);
			facedirection = "up";
			anim.SetBool("WalkUp", true);
		}
		else
		{
				anim.SetBool("WalkUp", false);
		}


		if (Input.GetKey(KeyCode.DownArrow)){
			//facedirection = "down";
			anim.SetBool("down", true);
			anim.SetBool("right", false);
			anim.SetBool("left", false);
			anim.SetBool("up", false);
			//anim.SetBool("WalkDown", true);
			transform.Translate(-Vector2.up * speed);
			//face_direction = new Vector2(0,-1);
			facedirection = "down";
			anim.SetBool("WalkDown", true);
			}
		else
		{
			anim.SetBool("WalkDown", false);
		}
	}
}