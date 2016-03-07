using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {
	public PlayerStats playerStats;
	public GameObject enemy;
	public float spawnTime = 1f;
	public Transform[] spawnPoints;
	private int counter;
	// Use this for initialization
	void Start () {
		counter = 1;
		InvokeRepeating("Spawn", 1, 1);
	}
	
	// Update is called once per frame
	void Spawn () {

		int spawnPointIndex = Random.Range(0, spawnPoints.Length);
		Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
		if (counter-- == 0) 
			CancelInvoke("Spawn");
	}
}
