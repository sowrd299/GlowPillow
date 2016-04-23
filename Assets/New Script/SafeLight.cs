using UnityEngine;
using System.Collections;

public class SafeLight : MonoBehaviour {

    //this belongs on the player, if anyone was confused

    public PlayerStats _playerStats;
    public PlayerAbility _playerability;
    public PlayerManager _playermanager;
    public float recovery = 0.125f;
    //bool on;
    //bool off;

    public float inTime = -1f; //the amount of time the player has been in the zone for
    //stores -N player is not in the area
	
	void Update () {
        if (inTime >= 0) {
            inTime += Time.deltaTime;
            if (inTime >= 2.5) {
                Debug.Log("The player is recovering!");
                _playerStats.AdjustCurrentHealth(recovery);
            }
        }
	}


    void OnTriggerEnter2D(Collider2D Entering)
    {
        if (Entering.transform.tag == "SafeZone") //turning the player invincibility on
        {
            Debug.Log("entering light");
          
            _playerStats.invincible = true;
            _playerStats.invisible = true;

            inTime = 0f;

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

            inTime = -1f;
        }
    }

    /*
    void OnTriggerStay2D(Collider2D Stay)
    {
        Debug.Log("Inside Light");
        _playerStats.invincible = true;
        _playerStats.invisible = true;
        if (_playerStats.curHealth < _playerStats.maxHealth)
        {
            Debug.Log(_playerStats.curHealth);

            _playerStats.curHealth += recovery;

            if (_playerStats.curHealth >= _playerStats.maxHealth)
            {
                _playerStats.curHealth = _playerStats.maxHealth;
            }    
        }
    }
    */

}
