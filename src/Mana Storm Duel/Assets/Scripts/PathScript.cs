using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public interface IPathScriptMessage : IEventSystemHandler
{
    PathScript GetPathScript();
}

[DisallowMultipleComponent]
public class PathScript : MonoBehaviour, IPathScriptMessage {

    [SerializeField]
    Transform[] wayPoints;
    [SerializeField]
    Color pathColor = Color.white;

    public Transform[] WayPoints
    {
        get
        {
            return wayPoints;
        }

        set
        {
            wayPoints = value;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDrawGizmos()
    {
        Gizmos.color = pathColor;
        for (int i = 0; i < WayPoints.Length; i++)
        {
            if (WayPoints[i])
            {
                Gizmos.DrawSphere(WayPoints[i].position, 0.5f);
                if (i + 1 < WayPoints.Length && WayPoints[i + 1])
                    Gizmos.DrawLine(WayPoints[i].position, WayPoints[i + 1].position);
            }
        }
    }

    PathScript IPathScriptMessage.GetPathScript()
    {
        return this;
    }
}
