using UnityEngine;
using System.Collections;
/// <summary>
/// This is checking is player collide with something
/// right now only collide with enemy
/// sensitivity needs adjustment still
/// 
/// </summary>
public class HitTime : MonoBehaviour {

	//Actual health is hidden from the players
	private float health; //value is use as reference to how fast the heart beats <-- referencing player stats
	private float Hittime; 
	private float dmg; //allow setting individual enemy dmg <-- referencing enemy stats



	// Use this for initialization
	void Start () //only execute once!!!
	{
		GameObject thePlayer = GameObject.Find("Player");
		GameObject theEnemy = GameObject.Find ("Enemy");
		MinionsStats enemystats = theEnemy.GetComponent<MinionsStats>();
		HeroStats herostats = thePlayer.GetComponent<HeroStats>();
		dmg = enemystats.Damage;
		health = herostats.Health;
		//this part can update GUI or Sounds of HeartBeat (if any) 
	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log (health);
		if (health <= 0)
		{
			Application.Quit ();
			Debug.Log ("Game Over!!");
		}
		if (health > 100)
		{
			health = 100;
		}

	}

	void HealthUpdate(){
		//this parts updates the heartbeat rhyme

	}

	void OnCollisionStay2D(Collision2D Enemyhit){
		//Hittime is to make sure the enemy on collision doesnt kill you by sticking and overlay
		//if the gameobject hit is a Enemy then take knockback and dmg
		if (Enemyhit.gameObject.tag == "Enemies"){
			//Deal dmg only per this amount of time (cool down)
			if (Hittime + .5f < Time.time)
			{
				Hittime = Time.time;
				//Takes hp out... something like that
				health -= dmg; //This is just for reference in this script 
				this.GetComponent<HeroStats>().Health = health ; //this is actually affecting the Health variable in HeroStat
				Debug.Log (health);
				//This part gets the amount of transform (position)
				float verticalpush = Enemyhit.gameObject.transform.position.y - transform.position.y;
				float horizontalpush = Enemyhit.gameObject.transform.position.x - transform.position.x;

				//Check the target rigidbody and knock it back
				GetComponent<Rigidbody2D>().AddForce(new Vector2(-horizontalpush * 1000, -verticalpush * 1000));
			}
		}
	}
}
