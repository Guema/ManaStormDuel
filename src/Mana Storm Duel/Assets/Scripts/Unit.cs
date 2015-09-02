using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.EventSystems;
using System;

public interface IUnitMessage : IEventSystemHandler
{
    void OnWeaponTarget(Weapon weapon);
    void OnWeaponUnTarget(Weapon weapon);
    void OnSufferEffect(Effect[] effect);
}

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
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
        if (_hp <= 0)
        {
            isDead = true;
        }
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

    void IUnitMessage.OnWeaponTarget(Weapon weapon)
    {
        ExecuteEvents.Execute<IWeaponMessages>(weapon.gameObject, null, (x, y) => x.OnUnitEnter(this));
    }

    void IUnitMessage.OnWeaponUnTarget(Weapon weapon)
    {
        ExecuteEvents.Execute<IWeaponMessages>(weapon.gameObject, null, (x, y) => x.OnUnitExit(this));
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
