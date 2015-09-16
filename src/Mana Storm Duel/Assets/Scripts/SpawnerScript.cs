using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;

public class SpawnerScript : NetworkBehaviour
{
    [SerializeField]
    PathScript pathScript;
    [SerializeField]
    float interval = 1.0f;

    [System.Serializable]
    struct EnnemiesConfig
    {
        [SerializeField]
        public int number;
        [SerializeField]
        public GameObject prefab;
    }

    [SerializeField]
    EnnemiesConfig[] waveOfEnnemies;

    public PathScript PathScript
    {
        get
        {
            return pathScript;
        }

        set
        {
            pathScript = value;
        }
    }

    public static List<SpawnerScript> spawners = new List<SpawnerScript>(); 

    void OnEnable()
    {
        spawners.Add(this);
    }

    void OnDisable()
    {
        spawners.Remove(this);
    }

    [Server]
    public void SpawnWave()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        for(int i = 0; i < waveOfEnnemies.Length; i++)
        {
            for(int j = 0; j<waveOfEnnemies[i].number; j++)
            {
                var ennemy = (GameObject)Instantiate(waveOfEnnemies[i].prefab,
                    transform.position,
                    Quaternion.identity);
                ExecuteEvents.Execute<IFollowPathMessage>(
                    ennemy,
                    null,
                    (x, y) => x.OnSpawn(pathScript));
                NetworkServer.Spawn(ennemy);
                yield return new WaitForSeconds(interval);
            }
        }
    }
}
