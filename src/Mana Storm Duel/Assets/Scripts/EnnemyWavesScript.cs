using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Networking;

public class EnnemyWavesScript : NetworkBehaviour {

    public void StartWave()
    {
        for (int i = 0; i < SpawnerScript.spawners.Count; i++)
        {
            SpawnerScript.spawners[i].SpawnWave();
        }
    }
}
