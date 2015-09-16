using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.Networking;

public interface IFollowPathMessage : IEventSystemHandler
{
    void OnSpawn(PathScript path);
}

[RequireComponent(typeof(Unit))]
public class FollowPathBehaviour : NetworkBehaviour, IFollowPathMessage {

    [SerializeField]
    Unit unit;
    [SerializeField]
    PathScript path;
    Transform dest;
    [SyncVar]
    int waypointIndex = 0;
	
    void OnEnable()
    {
        waypointIndex = 0;
    }

	// Update is called once per frame
	void Update ()
    {
        if(isServer)
        {
            if (dest && !unit.IsDead)
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
