using UnityEngine;
using System.Collections;

public class SafeLight : MonoBehaviour {

    public PlayerStats _playerStats;
    public PlayerAbility _playerability;
    public PlayerManager _playermanager;
    bool on;
    bool off;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    //check if player object is within the boundary
       //bool on = _playermanager.on;
       //bool off = _playermanager.off; 
	}


    void OnTriggerEnter2D(Collider2D Entering)
    {
        if (Entering.transform.tag == "SafeZone") //turning the player invincibility on
        {
            Debug.Log("entering light");

            _playerStats.invincible = true;
            _playerStats.invisible = true;
            
            //make player invisible to enemy
            //enemy can not enter the light 
        }
    }

    void OnTriggerExit2D(Collider2D Existing)
    {
        if(Existing.transform.tag == "SafeZone") //making sure player invincible and invisible are off
        {
            Debug.Log("exist light");
            _playerStats.invincible = false;
            _playerStats.invisible = false;
            
        }
    }


    void OnTriggerStay2D(Collider2D Stay)
    {
        Debug.Log("Inside Light");
        _playerStats.invincible = true;
        _playerStats.invisible = true;
        if (_playerStats.curHealth < _playerStats.maxHealth)
        {
            _playerStats.curHealth += 5f;
            if (_playerStats.curHealth >= _playerStats.maxHealth)
            {
                _playerStats.curHealth = _playerStats.maxHealth;
            }    
        }

    }

    


}
