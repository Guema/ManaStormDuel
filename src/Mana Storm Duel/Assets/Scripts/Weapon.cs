using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using System;

public interface IWeaponMessages : IEventSystemHandler
{

}

[RequireComponent(typeof(Collider))]
public class Weapon : MonoBehaviour, IWeaponMessages {

    [SerializeField]
    SphereCollider sphere;

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
        sphere.radius = range;
        sphere.isTrigger = true;

	}
	
	// Update is called once per frame
	void Update ()
    {
        sphere.radius = range;
        attackPerSecond = maxAttackPerSecond;
        if (HasTarget() && CanAttack())
        {
            Attack(); 
        }
    }

    void Attack()
    {
        last_attack = Time.time;
        var temp = Instantiate(projectile);
        temp.transform.position = transform.position + cannon;
        ExecuteEvents.Execute<IProjectileMessage>(temp, null, (x, y) => x.SetTarget(listTargets[0], effects.ToArray()));
    }

    public bool HasTarget()
    {
        if (listTargets.Count > 0)
            return true;
        else
            return false;
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
        ExecuteEvents.Execute<IUnitMessage>(col.gameObject, null, (x, y) => target = x.OnWeaponTarget(this));
        if (target)
            listTargets.Add(target);
    }

    void OnTriggerExit(Collider col)
    {
        Unit target = null;
        ExecuteEvents.Execute<IUnitMessage>(col.gameObject, null, (x, y) => target = x.OnWeaponUnTarget(this));
        if (target)
            listTargets.Remove(target);
    }
}
