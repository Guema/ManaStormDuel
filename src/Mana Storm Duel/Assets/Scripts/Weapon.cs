using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using System;

public interface IWeaponMessages : IEventSystemHandler
{

}

[RequireComponent(typeof(SphereCollider))]
[ExecuteInEditMode]
public class Weapon : NetworkBehaviour, IWeaponMessages {

    [SerializeField]
    SphereCollider triggerCollider;

    [SerializeField]
    Vector3 cannon = new Vector3(0.0f, 0.0f, 0.0f);

    [SerializeField]
    GameObject projectile;

    [SerializeField]
    List<Effect> effects = new List<Effect>();

    [SerializeField]
    int range = 10;

    [SerializeField]
    int maxDamage = 100;
    int damage;

    [SerializeField]
    float maxAttackPerSecond = 1.0f;
    float attackPerSecond;
    float last_attack = 0.0f;

    [SerializeField]
    List<Unit> listTargets = new List<Unit>();

    public int Damage
    {
        get
        {
            return damage;
        }

        set
        {
            damage = value;
        }
    }

    // Use this for initialization
    void Start ()
    {
        Damage = maxDamage;
        attackPerSecond = maxAttackPerSecond;
        triggerCollider.radius = range;
        triggerCollider.isTrigger = true;

	}
	
	// Update is called once per frame
	void Update ()
    {
        triggerCollider.radius = range;
        attackPerSecond = maxAttackPerSecond;
        Unit target;
        if ((target = Target()) && CanAttack())
        {
            Attack(target);
        }
    }

    void Attack(Unit Target)
    {
        last_attack = Time.time;
        if(isServer)
        {
            var temp = Instantiate(projectile);
            temp.transform.position = transform.position + cannon;
            NetworkServer.Spawn(temp);
            ExecuteEvents.Execute<IProjectileMessage>(temp, null, (x, y) => x.SetTarget(Target, effects.ToArray()));
        }
    }

    public Unit Target()
    {
        if (listTargets.Count > 0)
        {
            for(int i = 0; i<listTargets.Count; i++)
            {
                if (listTargets[i])
                {
                    if (!listTargets[i].IsDead)
                        return listTargets[i];
                }
                else
                    listTargets.RemoveAt(i);
            }
        }
        return null;
    }

    public bool CanAttack()
    {
        if(Time.time - last_attack >= attackPerSecond)
            return true;
        else
            return false;
    }

    void OnTriggerEnter(Collider col)
    {
        Unit target = null;
        ExecuteEvents.Execute<IUnitMessage>(col.gameObject, null, (x, y) => target = x.OnTarget());
        if (target)
            listTargets.Add(target);
    }

    void OnTriggerExit(Collider col)
    {
        Unit target = null;
        ExecuteEvents.Execute<IUnitMessage>(col.gameObject, null, (x, y) => target = x.OnUnTarget());
        if (target)
            listTargets.Remove(target);
    }
}
