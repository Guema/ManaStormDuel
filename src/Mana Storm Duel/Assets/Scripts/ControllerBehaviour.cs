using UnityEngine;
using System.Collections;

public class ControllerBehaviour : MonoBehaviour {
    [SerializeField]
    float speed = 50.0f;
    [SerializeField]
    LimitZoneScript limit;
    [SerializeField]
    int screenBorderTolerance = 0;

    int Xaxis;
    int Yaxis;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.mousePosition.x <= 0 + screenBorderTolerance)
            Xaxis = -1;
        else if (Input.mousePosition.x >= Screen.width - screenBorderTolerance)
            Xaxis = 1;
        else
            Xaxis = 0;

        if (Input.mousePosition.y <= 0 + screenBorderTolerance)
            Yaxis = -1;
        else if (Input.mousePosition.y >= Screen.height - screenBorderTolerance)
            Yaxis = 1;
        else
            Yaxis = 0;
        
        if (limit)
        {
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x + Xaxis * speed * Time.deltaTime, limit.left, limit.right),
                transform.position.y,
                Mathf.Clamp(transform.position.z + Yaxis * speed * Time.deltaTime, limit.top, limit.bottom)); 
        }
        else
        {
            transform.position = new Vector3(
                transform.position.x + Xaxis * speed * Time.deltaTime,
                transform.position.y,
                transform.position.z + Yaxis * speed * Time.deltaTime);
        }
	}
}
