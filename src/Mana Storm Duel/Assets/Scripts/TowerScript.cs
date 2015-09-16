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
        if(upgradeLevel == 0)
        {
            if (upgradeLevel + 1 < towersObjects.Length)
            {
                upgradeLevel++;
                towersObjects[upgradeLevel].SetActive(true);
                towersObjects[0].SetActive(false);
            }
        }
        RpcBuyTower();
    }

    [ClientRpc]
    public void RpcBuyTower()
    {
        if (1 < towersObjects.Length)
        {

            upgradeLevel = 1;

            towersObjects[upgradeLevel].SetActive(true);
            towersObjects[0].SetActive(false);

        }
    }
}
