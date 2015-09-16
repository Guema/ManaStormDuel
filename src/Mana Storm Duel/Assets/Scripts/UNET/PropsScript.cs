using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System;

public abstract class PropsScript : NetworkBehaviour
{
    [Server]
    public abstract void InitPlayerProps(NetworkConnection conn, short playerControllerId);
}

