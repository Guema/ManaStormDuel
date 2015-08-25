using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Unit : NetworkBehaviour {

    [SerializeField]
    int MaxHealth = 100;
    [SerializeField]
    int Hp = 100;

    [SerializeField]
    int MaxSpeed = 100;
    [SerializeField]
    int Speed = 100;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
