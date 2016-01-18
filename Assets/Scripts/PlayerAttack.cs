using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	//What happens in this script is when....the player press attack, the animation is played displaying the weapon/item in action
	//while in that action, the hitbox is gonna reappear with the ANIMATION, and thus triggers if enemy enters in that range.

	// Use this for initialization
	Animator anim;

	void Start () {
		//Animator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		//if(Input.GetMouseButtonDown(0)){
		//anim.SetTrigger("Attack");
		//get target hp and deal dmg to it

		}

	//this should be in the specific weapon 
	void OntriggerEnter2D(Collider2D other){
		//....deal dmg to what ever is in this box range
		
	}

}

