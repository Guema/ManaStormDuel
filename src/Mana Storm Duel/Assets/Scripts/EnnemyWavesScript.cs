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
        public int number;
        public int count;
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

    [SerializeField]
    Spawn[] spawnPoints;

    void Start()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            for (int j = 0; j < spawnPoints[i].ennemiesConfig.Length; j++)
            {
                var temp = Instantiate(spawnPoints[i].ennemiesConfig[j].prefab);
                temp.transform.position = spawnPoints[i].pathScript.WayPoints[0].position;
                ExecuteEvents.Execute<IFollowPathMessage>(
                    temp,
                    null,
                    (x, y) => x.OnSpawn(spawnPoints[i].pathScript));
            }
        }
    }

    void Update()
    {
        
    }


}
