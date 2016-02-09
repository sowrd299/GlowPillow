using UnityEngine;
using System.Collections;

//*******************      unlock the code by removing the //     currently inactive
/// <summary>
/// As of now player control uses Raycast to check if Enemy is in the range of the facing direction
/// The angle and number of Raycaste need to be modified so it checks in circular motion by degrees: slerp 
/// 
/// Currently the implementation is really bad at detecting objects
/// Most of the time its hit and miss
/// 
/// When avaliable Implementing SphereCast instead of Raycast for directional sphere scan
/// 
/// Direction is fully functional 
/// 
/// </summary>
public class PlayerAttack : MonoBehaviour {
    //What happens in this script is when....the player press attack, the animation is played displaying the weapon/item in action
    //while in that action, the hitbox is gonna reappear with the ANIMATION, and thus triggers if enemy enters in that range.
    private float Xdirection;
    private float Ydirection;
    private Vector2 player_position;
    private Vector2 enemy_position;
    //private Vector2 face_direction;
    //private Vector2 face_direction1;
    //private Vector2 face_direction2;

    private int Enemies;
    private float enemy_health;
    private float hero_dmg;
    private float Hittime;
    //private Vector2 radius;
    //private float sweepSpeed = 3.0f;
    private float targetDistance = 0.5f;
    private GameObject lastHit;
    private LineRenderer lineRender;
    private bool takedmg = false;
	// Use this for initialization
	Animator anim;

	void Start (){
        //Animator = GetComponent<Animator>();
        Enemies = 1 << 11;
        
    }


    void Update() {
        //radius = new Vector2(Mathf.Cos(sweepSpeed * Time.time), Mathf.Sin(sweepSpeed * Time.time)) * targetDistance;
        
       if (Input.GetKey(KeyCode.A)){
            //face_direction = new Vector2(-1, 0);
            //face_direction1 = new Vector2(face_direction.x, face_direction.y + 0.5f);
            //face_direction2 = new Vector2(face_direction.x, face_direction.y - 0.5f);
        }
       if (Input.GetKey(KeyCode.W)){
            //face_direction = new Vector2(0, 1);
            //face_direction1 = new Vector2(face_direction.x + 0.5f, face_direction.y);
            //face_direction2 = new Vector2(face_direction.x - 0.5f, face_direction.y);
        }
        if (Input.GetKey(KeyCode.D)) {
            //face_direction = new Vector2(1, 0);
            //face_direction1 = new Vector2(face_direction.x, face_direction.y + 0.5f);
            //face_direction2 = new Vector2(face_direction.x, face_direction.y - 0.5f);
        }
        if (Input.GetKey(KeyCode.S)) {
            //face_direction = new Vector2(0, -1);
            //face_direction1 = new Vector2(face_direction.x + 0.5f, face_direction.y);
            //face_direction2 = new Vector2(face_direction.x - 0.5f, face_direction.y);
        }

        

        GameObject thePlayer = GameObject.Find("Player"); //get player object (use its stats)
        player_position = GameObject.Find("Player").transform.position; //determine player location (x,y)
        //enemy_position = GameObject.Find("Player").transform.position; //not sure if needed
        GameObject theEnemy = GameObject.Find("Enemy");
        MinionsStats enemystats = theEnemy.GetComponent<MinionsStats>();
        HeroStats herostats = thePlayer.GetComponent<HeroStats>();
        enemy_health = enemystats.Health;
        hero_dmg = herostats.dmg;

        //the center 
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, face_direction, targetDistance, Enemies);
        //the tiled down/right
        //RaycastHit2D hit1 = Physics2D.Raycast(transform.position, face_direction1, targetDistance, Enemies);
        //the tiled up/left
        //RaycastHit2D hit2 = Physics2D.Raycast(transform.position, face_direction2, targetDistance, Enemies);
        
	
	// Update is called once per frame
        //constantly get the updated location (x,y)
        //Xdirection = player_position.x;
        //Ydirection = player_position.y;
        //face_direction = new Vector2(Xdirection, Ydirection); //which ever direction player is going or moving

		/*
        if (Input.GetKey(KeyCode.F) && Hittime + 0.5f < Time.time)
        {
            //Debug.DrawRay(transform.position, face_direction, Color.yellow, 6.0f);
            //Debug.DrawRay(transform.position, face_direction1, Color.yellow, 6.0f);
            //Debug.DrawRay(transform.position, face_direction2, Color.yellow, 6.0f);
            if (hit || hit1 || hit2)//(Physics2D.Raycast(transform.position, face_direction.normalized, 2, Enemies))
            {
                //can access stats directly 
                lastHit = hit.collider.gameObject;
                //Debug.Log(lastHit);
                Debug.Log("deal dmg to enemy");
                // Debug.Log(Time.time);
                if (Hittime + .5f < Time.time)
                {
                    Hittime = Time.time;
                    enemy_health -= hero_dmg;
                    Debug.Log("Enemy health" + enemy_health);
                    theEnemy.GetComponent<MinionsStats>().Health = enemy_health;
                    float verticalpush = lastHit.gameObject.transform.position.y - transform.position.y;
                    float horizontalpush = lastHit.gameObject.transform.position.x - transform.position.x;

                    //Check the target rigidbody and knock it back
                    theEnemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(horizontalpush * 1000, verticalpush * 1000));
                }

            }
            else
            {
                Debug.Log("slicing air");
            }
        }
        */
        //anim.SetTrigger("Attack");
        //get target hp and deal dmg to it

    }

	//this should be in the specific weapon 
	void OntriggerEnter2D(Collider2D other){
		//....deal dmg to what ever is in this box range
		
	}

}

