using UnityEngine;
using System.Collections;

[SelectionBase]
public class MarkerScript : MonoBehaviour {
    [SerializeField]
    Mesh mesh;
    [SerializeField]
    Color color = Color.white;
    [SerializeField]
    Vector3 position;
    [SerializeField]
    Vector3 rotation;
    [SerializeField]
    Vector3 scale;

    void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawWireMesh(mesh, transform.position + position, Quaternion.Euler(rotation), scale);
    }
}
