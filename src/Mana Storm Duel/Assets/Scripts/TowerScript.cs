using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.EventSystems;

[DisallowMultipleComponent]
[SelectionBase]
public class TowerScript : NetworkBehaviour {

    [SyncVar]
    [SerializeField]
    string faction = "Enter faction name here";
    [SerializeField]
    GameObject[] towersObjects;
    [SerializeField]
    Weapon weapon;
    [SyncVar]
    [SerializeField]
    int upgradeLevel = 0;

    public int UpgradeLevel
    {
        get
        {
            return upgradeLevel;
        }
    }

    void OnEnable()
    {
        //CmdSetUpgradeLevel(UpgradeLevel);

    }

    [Command]
    public void CmdBuyTower(PlayerScript playerScript)
    {
        Debug.Log(playerScript);
        RpcBuyTower();
    }

    [ClientRpc]
    public void RpcBuyTower()
    {
        if (1 < towersObjects.Length)
        {
            upgradeLevel = 1;
            weapon.enabled = true;
            towersObjects[upgradeLevel].SetActive(true);
            towersObjects[0].SetActive(false);
        }
    }
}
