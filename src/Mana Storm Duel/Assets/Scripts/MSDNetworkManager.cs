using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class MSDNetworkManager : NetworkManager {

    [SyncVar]
    int NumberOfPlayerJoined = 0;
    NetworkIdentity[] prePlacedPlayers;

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {

    }
}
