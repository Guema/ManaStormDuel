using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public interface IUnitMessage : IEventSystemHandler
{
    Unit OnTarget();
    Unit OnUnTarget();
    void OnSufferEffect(Effect[] effect, Vector3 vec);
}

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
[DisallowMultipleComponent]
[SelectionBase]
public class Unit : NetworkBehaviour, IUnitMessage
{
    [SerializeField]
    new public Collider collider;
    [SerializeField]
    new public Rigidbody rigidbody;

    [SyncVar]
    bool isDead = false;
    [SerializeField]
    int maxHealth = 100;
    [SerializeField]
    [SyncVar]
    int _hp;
    [SerializeField]
    int maxSpeed = 100;
    int _speed;

    public int Speed
    {
        get
        {
            return _speed;
        }

        set
        {
            _speed = value;
        }
    }

    public bool IsDead
    {
        get
        {
            return isDead;
        }

        set
        {
            isDead = value;
        }
    }


    // Use this for initialization
    void Start () {
        _hp = maxHealth;
        Speed = maxSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    [ClientRpc]
    public void RpcTakeDamage(int damage, Vector3 vec)
    {
        _hp = _hp - damage;
        if (_hp <= 0)
        {
            _hp = 0;
            if(!isDead)
            {
                StartCoroutine(OnDeath());
            }
            rigidbody.AddForce(vec * 2000f);
        }
    }

    IEnumerator OnDeath()
    {
        isDead = true;
        rigidbody.isKinematic = false;
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    Unit IUnitMessage.OnTarget()
    {
        return this;
    }

    Unit IUnitMessage.OnUnTarget()
    {
        return this;
    }

    [ServerCallback]
    void IUnitMessage.OnSufferEffect(Effect[] effect, Vector3 vec)
    {
        for(int i = 0; i < effect.Length; i++)
        {
            DamageEffect e;
            if (e = effect[i] as DamageEffect)
            {
                RpcTakeDamage(e.Damage, vec);
            }
        }
    }
}
