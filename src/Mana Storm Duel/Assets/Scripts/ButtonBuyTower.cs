using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.Networking;

public interface IGameUIMessage : IEventSystemHandler
{
    void OnPlayerClick(PlayerScript playerScript);
}

public abstract class Floating3DTigger : MonoBehaviour, IGameUIMessage
{
    [SerializeField]
    protected new Collider collider;

    public abstract void OnPlayerClick(PlayerScript playerScript);
}


public class ButtonBuyTower : Floating3DTigger
{
    [SerializeField]
    protected TowerScript towerScript;

    public override void OnPlayerClick(PlayerScript playerScript)
    {
        towerScript.CmdBuyTower(playerScript);
    }
}
