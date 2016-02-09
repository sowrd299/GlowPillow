using UnityEngine;
using System.Collections;

public class Blankie : MonoBehaviour {
    private float Hittime;
	private Vector2 facedirection;
	private float dmg;
	private float health;

    /// <summary>
    /// Blankie has a missing art issue. The collider should be the same size as the player object at all time
    /// </summary>
    void Start(){
		GameObject thePlayer = GameObject.Find("Player");
		GameObject theEnemy = GameObject.Find ("Enemy");
		MinionsStats enemystats = theEnemy.GetComponent<MinionsStats>();
		PlayerStats herostats = thePlayer.GetComponent<PlayerStats>();
		dmg = enemystats.Damage;
		health = herostats.curHealth;
    }

    void Update()
    {
		Debug.Log (health);
		if (health <= 0f)
		{
			Application.Quit ();
			Debug.Log ("Game Over!!");
		}
		if (health > 100f)
		{
			health = 100f;
		}

		//gonna use this direction to work with a hitbox. Have to get ride of seperate object animation
		//get atk to work only directional -> allow dmg only at a direction. 
        if (Input.GetKey(KeyCode.A)){
			facedirection = new Vector2(-1, 0);
		}

        if (Input.GetKey(KeyCode.D)){
			facedirection = new Vector2(1, 0);
        }

		if (Input.GetKey (KeyCode.W)){
			facedirection = new Vector2(0, -1);
		}
		if(Input.GetKey (KeyCode.S)){
			facedirection = new Vector2(0, 1);
		}
	}

	//not working
    void RotateRight() {
        Quaternion theRotation = transform.localRotation;
        theRotation.z *= 90;
        transform.localRotation = theRotation;
        //transform.Rotate(Vector3.forward * 90);
    }

	//not working
    void RotateLeft() {
        Quaternion theRotation = transform.localRotation;
        theRotation.z *= -90;
        transform.localRotation = theRotation;
        //transform.Rotate(Vector3.forward * -90);
    }

    //knock enemy back
    void OnTriggerEnter2D(Collider2D Enemyhit){
        Debug.Log("Knock the enemy back");
  
        //Hittime is to make sure the enemy on collision doesnt kill you by sticking and overlay
        //if the gameobject hit is a Enemy then take knockback and dmg
        if (Enemyhit.gameObject.tag == "Enemies")
        {
            Debug.Log("enemy knock back");
            //Deal dmg only per this amount of time (cool down)
            if (Hittime + 0.25f < Time.time)
            {
                GameObject theEnemy = GameObject.Find("Enemy");

                Hittime = Time.time;
                float verticalpush = Enemyhit.gameObject.transform.position.y - transform.position.y;
                float horizontalpush = Enemyhit.gameObject.transform.position.x - transform.position.x;

                //Check the target rigidbody and knock it back
                theEnemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(horizontalpush * 1000, verticalpush * 1000));
				health -= dmg * 0.40f; // this value has to change to base on character level
				GameObject.Find("Player").GetComponent<PlayerStats>().curHealth = health ; //this is actually affecting the Health variable in HeroStat
				Debug.Log (health);
			}
        }
    }
 }
