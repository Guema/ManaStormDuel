using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.EventSystems;
using System;

public interface IProjectileMessage : IEventSystemHandler
{
    /// <summary>
    /// Targets a GameObject with a Unit component on
    /// </summary>
    /// <param name="unit">Unit component of the GameObject</param>
    void SetTarget(Unit unit, Effect[] effect);
    void SetSpeed(int speed);
}

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class ProjectileBehaviour : NetworkBehaviour, IProjectileMessage
{

    [SerializeField]
    new public Collider collider;
    [SerializeField]
    new public Rigidbody rigidbody; 
    //[SerializeField]
    //bool isBeeingUsed = false;
    [SerializeField]
    List<Effect> effects = new List<Effect>();
    Unit target;
    [SerializeField]
    float speed = 50.0f;

    [SyncVar]
    Vector3 destination;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        if(isServer)
        {
            if (target)
            {
                destination = target.transform.position;
                transform.position = Vector3.MoveTowards(transform.position,
                    target.transform.position,
                    Time.deltaTime * speed);
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position,
                    destination,
                    Time.deltaTime * speed);
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if(target && target.collider)
        {
            if (col == target.collider)
            {
                Vector3 vec = (col.transform.position - transform.position).normalized;
                ExecuteEvents.Execute<IUnitMessage>(target.gameObject,
                    null,
                    (x, y) => x.OnSufferEffect(effects.ToArray(), vec));
                effects.Clear();
                Destroy(gameObject);
            }
        }
    }

    void IProjectileMessage.SetTarget(Unit unit, Effect[] effects)
    {
        target = unit;
        for(int i = 0; i < effects.Length; i++)
        {
            this.effects.Add(effects[i]);
        }
    }

    void IProjectileMessage.SetSpeed(int speed)
    {
        this.speed = speed;
    }
}
