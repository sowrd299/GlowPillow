using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private float speed;

	void start(){
		//setting player object by finding the player

	}

	void Update(){ 
		GameObject thePlayer = GameObject.Find("Player");
		HeroStats herostats = thePlayer.GetComponent<HeroStats>();
		speed = herostats.Speed;

	}

	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKey (KeyCode.D)){
			transform.Translate(Vector2.right * speed);

		}
		if(Input.GetKey (KeyCode.A)){
			transform.Translate(-Vector2.right * speed);
				
		}
		if(Input.GetKey (KeyCode.W)){
			transform.Translate(Vector2.up * speed);
				
		}
		if(Input.GetKey (KeyCode.S)){
			transform.Translate(-Vector2.up * speed);
				
		}
	
	}
}
