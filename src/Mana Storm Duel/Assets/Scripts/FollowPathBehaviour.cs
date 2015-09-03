using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Unit))]
public class FollowPathBehaviour : MonoBehaviour {

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
        if(path.WayPoints[0])
            dest = path.WayPoints[0];
    }

	// Update is called once per frame
	void Update ()
    {
        if(transform.position == dest.position)
        {
            if(waypointIndex < path.WayPoints.Length-1)
            {
                waypointIndex++;
                dest = path.WayPoints[waypointIndex];
            }
        }
        transform.position = Vector3.MoveTowards(transform.position,
            dest.position,
            Time.deltaTime * 15.0f * unit.Speed/100);
    }

    void OnTriggerEnter(Collider collider)
    {

    }
}
