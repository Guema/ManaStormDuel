using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Networking;

[Serializable]
public class TowersPropsScript : PropsScript
{
    [SerializeField]
    GameObject towerPrefab;
    [SerializeField]
    GameObject[] towerSpawnPoints;

    public override void InitPlayerProps(NetworkConnection conn, short playerControllerId)
    {
        for (int i = 0; i < towerSpawnPoints.Length; i++)
        {
            GameObject var = (GameObject)GameObject.Instantiate(
                towerPrefab,
                towerSpawnPoints[i].transform.position,
                Quaternion.identity);
            var.transform.parent = towerSpawnPoints[i].transform.parent;
            NetworkServer.Spawn(var);
            var.name = "Tower" + (i+1);
        }
    }
}
