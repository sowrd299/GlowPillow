﻿using UnityEngine;
using System.Collections;

public class star_script : MonoBehaviour {
    public float damage = 5f; //public for unity
    public float speed = 2.0f; //public for unity
    private Vector3 Player;
    private Vector2 PlayerDirection;
    private Vector2 PlayerPosition;
    private Vector2 direct;
    private float distance;
   
	//public PlayerAbility _playerability;

    /// <summary>
    /// As of now...This boomerang will ALWAYS return to the player. Regardless any pathing problems that may occur
    /// Collision is still a problem to solve. 
    /// Does not do any knock back or Dmg to the Enemy
    /// 
    /// 
    /// For true boomerang effect: set a starting point and end point 
    /// Have boomerang start at starting pt from the instantiating position, then have it translate to the target position
    /// once it reaches the target position or totaldistance to reach == 0, set returning speed (-speed) toward the position of the player
    /// destroy the object once it gets back to player. 
    /// </summary>
    void Start() {
        GameObject thePlayer = GameObject.Find("Player");
        //PlayerRangedAttack playerRange = thePlayer.GetComponent<PlayerRangedAttack>();
		PlayerAbility ability = thePlayer.GetComponent<PlayerAbility>();
		direct = ability.direction;
		GetComponent<Rigidbody2D>().velocity = direct.normalized * 4.0f;
		Debug.Log (direct);
    }


    // Update is called once per frame
        void Update()
    {
        Player = GameObject.Find("Player").transform.position;
        GetComponent<Rigidbody2D>().AddForce(direct.normalized * speed);
        PlayerDirection = new Vector2(Player.x - transform.position.x, Player.y - transform.position.y);
        PlayerPosition = new Vector2(Player.x, Player.y);
        distance = Vector2.Distance(PlayerPosition, transform.position);
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Hit by Star");

        if (other.transform.tag == "Wall") {
            Debug.Log("hit the wall");
           
            direct = PlayerDirection;
            //GetComponent<Rigidbody2D>().AddForce(PlayerDirection.normalized * Time.deltaTime);
            Debug.Log("Returning");
            //instead of Destroy sent the boomer back to player
            //set it to translate toward player
        }

        if (other.transform.tag == "Enemy") {
            Debug.Log("hit the Enemy");
            //deal dmg
            other.gameObject.GetComponent<MinionsStats>().TakeDamage(damage);
            direct = PlayerDirection;
            //GetComponent<Rigidbody2D>().AddForce(PlayerDirection.normalized * Time.deltaTime);
        }

        if (distance > 2)
        {
            direct = PlayerDirection;
            //GetComponent<Rigidbody2D>().AddForce(PlayerDirection.normalized * Time.deltaTime);
        }

		if (other.transform.tag == "Player") {
			Transform lght = GetComponentInChildren<FogLight> ().transform;
			GameObject plyr = GameObject.Find ("Player");
			lght.parent = plyr.transform; //give the light back to the plyer;
			lght.localPosition = new Vector2(0,0);
			plyr.GetComponent<PlayerAbility>().toggleBasicLight();
            Destroy(this.gameObject);
        }
    }
}
