using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

[RequireComponent(typeof(SphereCollider))]
public class Weapon : MonoBehaviour {

    [SerializeField]
    SphereCollider sphere;

    [SerializeField]
    GameObject projectile;
    [SerializeField]
    int range = 10;

    [SerializeField]
    int maxDamage = 100;
    int damage;

    [SerializeField]
    float maxAttackPerSecond = 1.0f;
    float attackPerSecond;
    float last_attack = 0.0f;

    List<Collider> listcoll = new List<Collider>();

	// Use this for initialization
	void Start () {
        damage = maxDamage;
        attackPerSecond = maxAttackPerSecond;
        sphere.radius = range;
        sphere.isTrigger = true;

	}
	
	// Update is called once per frame
	void Update ()
    {
        sphere.radius = range;
        attackPerSecond = maxAttackPerSecond;
        if (listcoll.Count > 0)
        {
            if (Time.time - last_attack >= attackPerSecond)
            {
                last_attack = Time.time;

                var temp = GameObject.Instantiate<GameObject>(projectile);
                temp.transform.position = this.transform.position;
                temp.GetComponent<Goto>().dest = listcoll[0].transform;
            }
            
        }
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Ennemi repéré !");
        listcoll.Add(col);
    }
    
    void OnTriggerStay(Collider col)
    {

    }

    void OnTriggerExit(Collider col)
    {
        listcoll.Remove(col);
    }
}
