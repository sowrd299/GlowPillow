using UnityEngine;
using System.Collections;

public class FogLight : MonoBehaviour {

	//NOTE: ADD TO OBJECTS THAT BEHAVE AS LIGHTS (THE FOG-OF-WAR ALIVIATING KIND)
	//THOSE OBJECTS MUST HAVE THE "FogLight" TAG

	public float radius;
	public GameObject sprite; //the child object with its sprite

	void Start(){
		setRadius (radius);
	}

	public float getRadius(){
		return radius;
	}

	public void setRadius(float radius){
		this.radius = radius;
		//assumes scale of all parent objects 1. Should make it so it doesn't if have time.
		sprite.transform.localScale = new Vector3 (radius * 2, radius * 2, radius * 2);
	}

}
