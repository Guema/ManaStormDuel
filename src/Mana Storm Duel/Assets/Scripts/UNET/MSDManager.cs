using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class MSDManager : NetworkManager
{
    [SerializeField]
    PropsScript[] script;

    [SerializeField]
    LimitZoneScript limit;

    [SerializeField]
    GameScequenceScript gameSequences;

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        if(numPlayers < script.Length)
        {
            script[numPlayers].InitPlayerProps(conn, playerControllerId);
        }
        GameObject player = (GameObject)Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        if(numPlayers == 2)
        {
            gameSequences.OnLetsPlay();
        }
    }
}
