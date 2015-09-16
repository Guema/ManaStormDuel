using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Networking;
using UnityEngine.EventSystems;

public class SpawnpointsPropsScript : PropsScript
{
    [SerializeField]
    GameObject spawnPrefab;
    [SerializeField]
    PathScript[] path;

    [Server]
    public override void InitPlayerProps(NetworkConnection conn, short playerControllerId)
    {
        for (int i = 0; i < path.Length; i++)
        {
            GameObject spawn = (GameObject)Instantiate(
                spawnPrefab,
                path[i].WayPoints[0].position,
                Quaternion.identity);
            NetworkServer.Spawn(spawn);
            spawn.GetComponent<SpawnerScript>().PathScript = path[i];
        }
    }
}
