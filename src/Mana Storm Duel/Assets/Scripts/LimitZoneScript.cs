using UnityEngine;
using System.Collections;

public class LimitZoneScript : MonoBehaviour {

    [SerializeField]
    Rect rect;

    [SerializeField]
    public float top { get { return rect.yMin + transform.position.z; } }
    [SerializeField]
    public float bottom { get { return rect.yMax + transform.position.z; } }
    [SerializeField]
    public float left { get { return rect.xMin + transform.position.x; } }
    [SerializeField]
    public float right { get { return rect.xMax + transform.position.x; } }

    

    void OnDrawGizmos()
    {
        Vector3 topleft, topright, botleft, botright;
        topleft = new Vector3(left, transform.position.y, top);
        topright = new Vector3(right, transform.position.y, top);
        botleft = new Vector3(left, transform.position.y, bottom);
        botright = new Vector3(right, transform.position.y, bottom);
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(topleft, 1f);
        Gizmos.DrawSphere(topright, 1f);
        Gizmos.DrawSphere(botleft, 1f);
        Gizmos.DrawSphere(botright, 1f);
        Gizmos.DrawLine(topleft, topright);
        Gizmos.DrawLine(botleft, botright);
        Gizmos.DrawLine(topleft, botleft);
        Gizmos.DrawLine(topright, botright);
    }

}
