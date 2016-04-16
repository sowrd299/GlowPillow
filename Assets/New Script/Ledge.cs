using UnityEngine;
using System.Collections;

public abstract class Ledge : MonoBehaviour {

    public int direction; //should be +-1
    protected float outVal; //out val

	void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Colliding with the Thing!");
        if (other.gameObject.tag == "Player") {
            other.transform.position = jump(other.transform.position);
        }
        GetComponent<AudioSource>().Play();
    }

    protected abstract Vector2 jump(Vector2 from);

}
