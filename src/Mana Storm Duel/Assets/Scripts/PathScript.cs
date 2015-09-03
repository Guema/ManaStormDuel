using UnityEngine;
using System.Collections;

public class PathScript : MonoBehaviour {

    [SerializeField]
    Transform[] wayPoints;
    [SerializeField]
    bool drawPaths;
    [SerializeField]
    Color pathColor = Color.white;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDrawGizmos()
    {
        if(drawPaths)
        {
            Gizmos.color = pathColor;
            for (int i = 0; i < wayPoints.Length; i++)
            {
                if (wayPoints[i])
                {
                    Gizmos.DrawSphere(wayPoints[i].position, 0.5f);
                    if (i + 1 < wayPoints.Length && wayPoints[i + 1])
                        Gizmos.DrawLine(wayPoints[i].position, wayPoints[i + 1].position);
                }
            }
        }
    }
}
