using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.EventSystems;

public class PlayerScript : NetworkBehaviour
{
    [SyncVar]
    [SerializeField]
    string faction = "Enter faction name here";
    [SerializeField]
    new Camera camera;
    [SerializeField]
    LayerMask UILayerMask;
    [SerializeField]
    LayerMask UnitsLayerMask;

    public string Faction
    {
        get
        {
            return faction;
        }

        set
        {
            faction = value;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            CallUIMessage();
        }
    }

    void CallUIMessage()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f, UILayerMask))
        {
            Debug.Log(hit.collider);
            ExecuteEvents.Execute<IGameUIMessage>(
                hit.collider.gameObject,
                null,
                (x, y) => x.OnPlayerClick(this));
        }
    }
}
