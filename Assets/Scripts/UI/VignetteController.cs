using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VignetteController : MonoBehaviour {

	public Image image;
	public PlayerStats pStats;
	public PlayerManager pm;
	
	// Update is called once per frame
	void Update () {
		//Debug.Log("Setting vingette to: "+getHealth().ToString()+"; Health is: "+pStats.curHealth.ToString());
		image.color = new Color (image.color.r, image.color.g, image.color.b,
			getVal () - 0.25f * getVal() * Mathf.Abs(Mathf.Sin((4.0f + 4.0f*getVal()) * Time.fixedTime/Mathf.PI)));
		//throbs at a rate of 120-240 bmp, based on health
	}

	private float getVal(){
		float val = getHealth () + 0.1f * getSprinting ();
		return (val < 1.0f? val : 1.0f);
	}

	private float getHealth(){
		//returns the % health as a float from 0.0f to 1.0f
		return ((float)pStats.getMaxHealth() - (float)pStats.getCurHealth()) / ( (float)pStats.getMaxHealth());
	}

	private float getSprinting(){
		return (pm.getSprintState() == PlayerManager.SprintStates.DFLT? 0.0f : 1.0f);
	}
}
