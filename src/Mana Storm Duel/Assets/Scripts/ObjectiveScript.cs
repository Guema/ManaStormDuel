using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider))]
public class ObjectiveScript : NetworkBehaviour {

    [SyncVar]
    [SerializeField]
    PlayerScript playerScript;

    [SyncVar]
    [SerializeField]
    new Collider collider;

	// Use this for initialization
	void Start ()
    {
	
	}

    // Update is called once per frame
    void Update()
    {

    }
    
    void OnTriggerEnter(Collider col)
    {
        Unit target = null;
        ExecuteEvents.Execute<IUnitMessage>(col.gameObject,
            null,
            (x, y) => target = x.OnTarget());
        if(target)
        {
            if(!target.IsDead)
            {
                Destroy(target.gameObject);
            }
        }
    }
}
