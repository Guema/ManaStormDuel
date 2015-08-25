using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Weapon : NetworkBehaviour {

    [SerializeField]
    int Range = 10;
    [SerializeField]
    int MaxDamage = 100;
    [SerializeField]
    int Damage = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
