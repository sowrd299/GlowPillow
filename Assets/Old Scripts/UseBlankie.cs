using UnityEngine;
using System.Collections;

public class UseBlankie : MonoBehaviour {
    Animator anim;
	// Use this for initialization
    public float useRate = 0.5f;
    private float nextUse;
	private bool on = false;
	private bool off = true;
    /// <summary>
    /// Activation timing could use some more adjustments 
    /// </summary>
	void Start () {
        anim = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	//old version
	/* 
	void Update () {
        if (Input.GetKey(KeyCode.F) && Time.time > nextUse) {
            anim.SetTrigger("Blankie"); //have to set as bool  activate and close depending on button pressed.
            nextUse = Time.time + useRate;
            Debug.Log("Used Blankie");
        }
	}
	*/
	//updated to active and deactivate depending on button
	void Update(){
			if(off){
				if (Input.GetKey(KeyCode.E) && nextUse < Time.time){
					
					Debug.Log ("Use Blankie");
					anim.SetBool("blankie_swing", true);
					nextUse = Time.time + useRate;
					off = false;
					on = true;
				}
			}
			else{
				if(on && nextUse < Time.time){
					if (Input.GetKey(KeyCode.E)){
						anim.SetBool ("blankie_swing", false);
						nextUse = Time.time + useRate;
						off = true;
						on = false;
						Debug.Log ("Blankie removed");
					}
				}
			}			
	}
}
	

