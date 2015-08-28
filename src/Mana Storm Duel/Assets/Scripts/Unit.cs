using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Unit : MonoBehaviour {

    bool isDead = false;
    [SerializeField]
    int maxHealth = 100;
    int hp;
    [SerializeField]
    int maxSpeed = 100;
    int speed;

	// Use this for initialization
	void Start () {
        hp = maxHealth;
        speed = maxSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    
    void FixedUpdate ()
    {
        if (hp <= 0)
        {
            isDead = true;
        }
    }
}
