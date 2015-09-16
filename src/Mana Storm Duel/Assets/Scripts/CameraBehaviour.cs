using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class CameraBehaviour : NetworkBehaviour {

    [SerializeField]
    new GameObject camera;
    [SerializeField]
    float speed = 50.0f;
    [SerializeField]
    LimitZoneScript limit;
    //[SerializeField]
    //float screenBorderTolerance = 1f;

    [SyncVar]
    Vector3 directionJoystick;

    public LimitZoneScript Limit
    {
        get
        {
            return limit;
        }

        set
        {
            limit = value;
        }
    }

    void Start()
    {
        if (isLocalPlayer)
            camera.SetActive(true);
    }


	// Update is called once per frame
	void Update ()
    {
        if(isLocalPlayer)
        {
            if (Input.mousePosition.x <= 0)
                directionJoystick[0] = -1;
            else if (Input.mousePosition.x >= Screen.width-1)
                directionJoystick[0] = 1;
            else
                directionJoystick[0] = 0;

            if (Input.mousePosition.y <= 0)
                directionJoystick[2] = -1;
            else if (Input.mousePosition.y >= Screen.height-1)
                directionJoystick[2] = 1;
            else
                directionJoystick[2] = 0;

            directionJoystick.Normalize();

            if (Limit)
            {
                transform.position = new Vector3(
                    Mathf.Clamp(transform.position.x + directionJoystick.x * speed * Time.deltaTime, Limit.left, Limit.right),
                    transform.position.y,
                    Mathf.Clamp(transform.position.z + directionJoystick.z * speed * Time.deltaTime, Limit.top, Limit.bottom));
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
}
