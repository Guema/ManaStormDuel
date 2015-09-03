using UnityEngine;
using System.Collections;

public class ControllerBehaviour : MonoBehaviour {
    [SerializeField]
    float speed = 30.0f;
    [SerializeField]
    int Tolerance = 0;

    int Xaxis;
    int Yaxis;
    Vector3 direction = new Vector3();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.mousePosition.x <= 0 + Tolerance)
            Xaxis = -1;
        else if (Input.mousePosition.x >= Screen.width - Tolerance)
            Xaxis = 1;
        else
            Xaxis = 0;

        if (Input.mousePosition.y <= 0 + Tolerance)
            Yaxis = -1;
        else if (Input.mousePosition.y >= Screen.height - Tolerance)
            Yaxis = 1;
        else
            Yaxis = 0;

        direction = (Vector3.right * Xaxis + Vector3.forward * Yaxis).normalized;
        transform.position += direction * speed * Time.deltaTime;
	}
}
