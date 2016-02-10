using UnityEngine;
using System.Collections;

public class FogHider : MonoBehaviour {

	//NOTE: ADD TO OBJECTS THAT HIDE IN THE FOG OF WAR
	//THEY MUST HAVE THEIR SPRITE ON A CHILD OBJECT

	public GameObject disp; //THE CHILD OBJECT WITH THE SPRITE
	public string lightTag = "FogLight";

	/*
	void Start(){
		disp = GetComponentInChildren<SpriteRenderer> ().gameObject;
	}
	*/

	void Update(){
		bool b = false;
		foreach (GameObject o in GameObject.FindGameObjectsWithTag(lightTag)) {
			//Debug.Log(Vector2.Distance (transform.position, o.transform.position));
			if (Vector2.Distance (transform.position, o.transform.position) <= o.GetComponent<FogLight>().getRadius()) {
				b = true;
				break;
			}
		}
		disp.SetActive (b);
	}

}
