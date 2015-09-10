using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public interface IFollowPathMessage : IEventSystemHandler
{
    void OnSpawn(PathScript path);
}

[RequireComponent(typeof(Unit))]
public class FollowPathBehaviour : MonoBehaviour, IFollowPathMessage {

    [SerializeField]
    Unit unit;
    [SerializeField]
    PathScript path;
    Transform dest;
    int waypointIndex = 0;


	// Use this for initialization
	void Start ()
    {
        
	}
	
    void OnEnable()
    {
        waypointIndex = 0;
    }

	// Update is called once per frame
	void Update ()
    {
        if(!unit.IsDead)
        {
            if (transform.position == dest.position)
            {
                if (waypointIndex < path.WayPoints.Length - 1)
                {
                    waypointIndex++;
                    dest = path.WayPoints[waypointIndex];
                }
            }
            transform.position = Vector3.MoveTowards(transform.position,
                dest.position,
                Time.deltaTime * 10.0f * unit.Speed / 100);
        }
    }

    void IFollowPathMessage.OnSpawn(PathScript path)
    {
        this.path = path;
        if(this.path)
        {
            waypointIndex = 0;
            dest = path.WayPoints[0];
        }
    }
}
