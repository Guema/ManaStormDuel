using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EnnemyWavesScript : MonoBehaviour {
    
    [System.Serializable]
    struct EnnemiesConfig
    {
        [SerializeField]
        public GameObject prefab;
        [SerializeField]
        public int number;
        [SerializeField]
        public Text textnumber;
    }

    [System.Serializable]
    struct Spawn
    {
        [SerializeField]
        public PathScript pathScript;
        [SerializeField]
        public EnnemiesConfig[] ennemiesConfig;
    }

    [SerializeField]
    float spawnFrequency = 1f;
    float lastTime = 0f;

    [SerializeField]
    Spawn[] spawnPoints;

    void Start()
    {
        if (true) //condition
        {
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                StartCoroutine(SpawnEnnemies(spawnPoints[i], spawnPoints[i].ennemiesConfig));
            }

        }
    }

    void Update()
    {
        
    }

    IEnumerator SpawnEnnemies(Spawn spawn, EnnemiesConfig[] cf)
    {
        for (int i = 0; i < cf.Length; i++)
        {
            for(int j = 0; j < cf[i].number; j++)
            {
                var temp = Instantiate(cf[i].prefab);
                temp.transform.position = spawn.pathScript.WayPoints[0].position;
                ExecuteEvents.Execute<IFollowPathMessage>(
                    temp,
                    null,
                    (x, y) => x.OnSpawn(spawn.pathScript));
                yield return new WaitForSeconds(spawnFrequency);
            }
        }
        yield break;
    }
}
