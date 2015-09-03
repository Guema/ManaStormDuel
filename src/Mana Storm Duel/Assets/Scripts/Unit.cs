using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.EventSystems;
using System;

public interface IUnitMessage : IEventSystemHandler
{
    Unit OnWeaponTarget(Weapon weapon);
    Unit OnWeaponUnTarget(Weapon weapon);
    void OnSufferEffect(Effect[] effect);
}

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
[DisallowMultipleComponent]
public class Unit : MonoBehaviour, IUnitMessage
{
    [SerializeField]
    new public Collider collider;
    [SerializeField]
    new public Rigidbody rigidbody;

    bool isDead = false;
    [SerializeField]
    int maxHealth = 100;
    [SerializeField]
    int _hp;
    [SerializeField]
    int maxSpeed = 100;
    [SerializeField]
    int _speed;
    

	// Use this for initialization
	void Start () {
        _hp = maxHealth;
        _speed = maxSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    
    void FixedUpdate ()
    {

    }

    public void TakeDamage(int damage)
    {
        _hp = _hp - damage;
        if (_hp <= 0)
        {
            _hp = 0;
            isDead = true;
        }
    }

    Unit IUnitMessage.OnWeaponTarget(Weapon weapon)
    {
        return this;
        //ExecuteEvents.Execute<IWeaponMessages>(weapon.gameObject, null, (x, y) => x.OnUnitEnter(this));
    }

    Unit IUnitMessage.OnWeaponUnTarget(Weapon weapon)
    {
        return this;
        //ExecuteEvents.Execute<IWeaponMessages>(weapon.gameObject, null, (x, y) => x.OnUnitExit(this));
    }

    void IUnitMessage.OnSufferEffect(Effect[] effect)
    {
        for(int i = 0; i < effect.Length; i++)
        {
            DamageEffect e;
            if (e = effect[i] as DamageEffect)
            {
                TakeDamage(e.Damage);
            }
        } 
    }
}
