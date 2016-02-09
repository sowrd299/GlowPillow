using UnityEngine;
using System.Collections;


//Player movement now contains basic attack ()

public class PlayerMovement : MonoBehaviour {

	private float speed;
    private string facedirection;
	private Vector2 player_position;
    //Rigidbody2D rbody;
    public Animator anim;
	public float sprint;
	private Vector2 face_direction;
	private GameObject lastHit;
	private int Enemies;
	private float Hittime;
	private RaycastHit2D hit;
	private float minPlayerDetectDistance;
	private float fieldOfViewDegrees;
	private float visibilityDistance;



	void start(){
        //setting player object by finding the player
        //rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        facedirection = "down";
		Enemies = 1 << 11;
	}

	void Update(){ 
		GameObject thePlayer = GameObject.Find("Player");
		HeroStats herostats = thePlayer.GetComponent<HeroStats>();
		speed = herostats.Speed;
		Sprint();
		attack();
        

    }
    // Update is called once per frame
	void Sprint(){
		if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))){
			speed = speed * sprint;
		}
	}
	
	
	void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D)){
            facedirection = "right";
            anim.SetBool("right", true);
            anim.SetBool("left", false);
            anim.SetBool("up", false);
            anim.SetBool("down", false);
            //anim.SetBool("WalkRight", true);
            transform.Translate(Vector2.right * speed);
			face_direction = new Vector2(1,0);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            facedirection = "left";
            anim.SetBool("left", true);
            anim.SetBool("right", false);
            anim.SetBool("up", false);
            anim.SetBool("down", false);
            //anim.SetBool("WalkLeft", true);
            transform.Translate(-Vector2.right * speed);
			face_direction = new Vector2(-1,0);
        }

        if (Input.GetKey(KeyCode.W)){
            facedirection = "up";
            anim.SetBool("up", true);
            anim.SetBool("right", false);
            anim.SetBool("left", false);
            anim.SetBool("down", false);
            // anim.SetBool("WalkUp", true);
            transform.Translate(Vector2.up * speed);
			face_direction = new Vector2(0,1);
        }

        if (Input.GetKey(KeyCode.S)){
            facedirection = "down";
            anim.SetBool("down", true);
            anim.SetBool("right", false);
            anim.SetBool("left", false);
            anim.SetBool("up", false);
            //anim.SetBool("WalkDown", true);
            transform.Translate(-Vector2.up * speed);
			face_direction = new Vector2(0,-1);
        }

		//clean up later
        if (Input.GetKey(KeyCode.D)){
            anim.SetBool("WalkRight", true);
        }
        else{
            anim.SetBool("WalkRight", false);
        }
        if (Input.GetKey(KeyCode.A)){
            anim.SetBool("WalkLeft", true);
        }
        else{
            anim.SetBool("WalkLeft", false);
        }
        if (Input.GetKey(KeyCode.W)){
            anim.SetBool("WalkUp", true);
        }
        else{
            anim.SetBool("WalkUp", false);
        }
        if (Input.GetKey(KeyCode.S)){
            anim.SetBool("WalkDown", true);
        }
        else{
            anim.SetBool("WalkDown", false);
        }

    }


	void attack(){
		if (Input.GetKey(KeyCode.F) && Hittime + 0.5f < Time.time)
		{
			GameObject thePlayer = GameObject.Find("Player");
			Debug.DrawRay(thePlayer.transform.position, face_direction, Color.green, 3.0f);
			Debug.Log("Attacking");


			//Plan --> in angle the problem is that it's not working. :P
			if((Vector3.Angle(thePlayer.transform.position - transform.position, transform.forward) <= (fieldOfViewDegrees * 0.5f)))
			{
				RaycastHit2D hit = (Physics2D.Raycast(transform.position, Vector2.zero, visibilityDistance));
			
				if(hit.transform.tag == "Enemy")
				{
					Debug.Log(hit);
				}		
			}  
		}
	}
}