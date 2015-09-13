using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

    [SerializeField]
    new GameObject camera;
    [SerializeField]
    float speed = 50.0f;
    [SerializeField]
    LimitZoneScript limit;
    [SerializeField]
    int screenBorderTolerance = 0;

    Vector3 directionJoystick;

	// Update is called once per frame
	void Update ()
    {
        if(Input.mousePosition.x <= 0 + screenBorderTolerance)
            directionJoystick[0] = -1;
        else if (Input.mousePosition.x >= Screen.width - screenBorderTolerance)
            directionJoystick[0] = 1;
        else
            directionJoystick[0] = 0;

        if (Input.mousePosition.y <= 0 + screenBorderTolerance)
            directionJoystick[2] = -1;
        else if (Input.mousePosition.y >= Screen.height - screenBorderTolerance)
            directionJoystick[2] = 1;
        else
            directionJoystick[2] = 0;

        directionJoystick.Normalize();

        if (limit)
        {
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x + directionJoystick.x * speed * Time.deltaTime, limit.left, limit.right),
                transform.position.y,
                Mathf.Clamp(transform.position.z + directionJoystick.z * speed * Time.deltaTime, limit.top, limit.bottom));
        }
        else
        {
            
            transform.position = new Vector3(
                transform.position.x + directionJoystick.x * speed * Time.deltaTime,
                transform.position.y,
                transform.position.z + directionJoystick.z * speed * Time.deltaTime);
        }
	}
}
