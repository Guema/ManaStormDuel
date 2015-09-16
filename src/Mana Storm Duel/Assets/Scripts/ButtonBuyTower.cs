using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.Networking;

public interface IGameUIMessage : IEventSystemHandler
{
    void OnPlayerClick(PlayerScript playerScript);
}

public abstract class TowerButton : MonoBehaviour, IGameUIMessage
{

    [SerializeField]
    protected TowerScript towerScript;
    [SerializeField]
    protected new Collider collider;

    public abstract void OnPlayerClick(PlayerScript playerScript);
}


public class ButtonBuyTower : TowerButton
{
    public override void OnPlayerClick(PlayerScript playerScript)
    {
        //towerScript.CmdSetUpgradeLevel(towerScript.UpgradeLevel + 1);
        towerScript.CmdBuyTower(playerScript);
    }
}
