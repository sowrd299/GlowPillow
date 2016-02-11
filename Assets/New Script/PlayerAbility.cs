using UnityEngine;
using System.Collections;

public class PlayerAbility : MonoBehaviour {
	public GameObject target;
	public GameObject star;
	private int Enemies;
	private float enemy_health;
	//float range = 1.8f;
	//float meleeDamage = 10.0f;
	//private float elapse = 0;
	private Vector2 player_position;
	private int radius = 3;
	private float distance;
	public PlayerStats _playerstats;
	public Vector2 direction;
	public PlayerManager _playermanager;
	public GameObject weaponLight;
	public GameObject basicLight;
	private Vector2 SpawnPos;
	public float speed;
	public float starThreshold = 0.5f;
	private int i;
	private float x;
	private float y;

	// Use this for initialization
	void Start () {
		Enemies = 1 << 11;
	}
	
	// Update is called once per frame
	void Update () {
		x = GetComponent<Transform>().position.x;
		y = GetComponent<Transform>().position.y;

		if (_playermanager.facedirection == "right")
		{
			direction = Vector2.right;
			SpawnPos = new Vector2(x + .65f, y);
		}
		if (_playermanager.facedirection == "left")
		{
			direction = -Vector2.right;
			SpawnPos = new Vector2(x - .65f, y);
		}
		if (_playermanager.facedirection == "up")
		{
			direction = Vector2.up;
			SpawnPos = new Vector2(x , y + .65f);
		}
		if (_playermanager.facedirection == "down")
		{
			direction = -Vector2.up;
			SpawnPos = new Vector2(x, y - .65f);
		}
	}




	public void PlayerAttack(){
	if(GameObject.FindGameObjectWithTag("Star") == null){
			//makes it so can swing mace while star is out
			player_position = GameObject.Find("Player").transform.position; 


			Collider2D[] hitColliders = Physics2D.OverlapCircleAll(player_position, radius, Enemies);
			int i = 0;
			for(i = 0; i < hitColliders.Length; i++){
				distance = Vector2.Distance(hitColliders[i].transform.position, transform.position);
				if (distance <= _playerstats.range){
				{	
					
					hitColliders[i].SendMessage("Enemy Hit", _playerstats.dmg, SendMessageOptions.DontRequireReceiver); 
					Debug.Log("Damage Sent");
			

						float verticalpush = hitColliders[i].gameObject.transform.position.y - transform.position.y;
						float horizontalpush = hitColliders[i].gameObject.transform.position.x - transform.position.x;

					//Check the target rigidbody and knock it back
						hitColliders[i].GetComponent<Rigidbody2D>().AddForce(new Vector2(horizontalpush * 1000, verticalpush * 1000));
					}
				}
			}
		}
	}


	public void PlayerRangeAttack(){
		//assumes only throwing one star
		if(!getProjectileThrown()){
			Instantiate (star, SpawnPos, Quaternion.identity);
			weaponLight.transform.parent = GameObject.FindGameObjectWithTag("Star").transform; //give the light to the star
			toggleBasicLight();
			weaponLight.transform.localPosition = new Vector2(0,0);
		}
	}

	public bool getProjectileThrown(){
		//returns true if the star has already been thrown (and has not been picked up)
		return GameObject.FindGameObjectWithTag ("Star") != null;
	}

	public void toggleBasicLight(){
		//assumes begins false
		Debug.Log("Toggling");
		basicLight.SetActive (!basicLight.activeInHierarchy);
	}

}
