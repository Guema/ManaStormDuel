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
public class ProjectileBehaviour : MonoBehaviour, IProjectileMessage
{
    [SerializeField]
    new public Collider collider;
    [SerializeField]
    new public Rigidbody rigidbody; 
    [SerializeField]
    bool isBeeingUsed = false;
    [SerializeField]
    List<Effect> effects = new List<Effect>();
    Unit target;
    float speed = 25.0f;


	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        if(target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if(target && target.collider)
        {
            if (col == target.collider)
            {
                ExecuteEvents.Execute<IUnitMessage>(target.gameObject, null, (x, y) => x.OnSufferEffect(effects.ToArray()));
                effects.Clear();
                Destroy(this.gameObject);
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
