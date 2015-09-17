using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

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
    EnnemiesConfig[] ennemiesConfig;

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
        RefreshDisplays();
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
        for(int i = 0; i < ennemiesConfig.Length; i++)
        {
            for(int j = 0; j<ennemiesConfig[i].number; j++)
            {
                var ennemy = (GameObject)Instantiate(ennemiesConfig[i].prefab,
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


    #region UI

    [SerializeField]
    Text[] NbOfEnnemiesText;
    [SerializeField]
    Canvas AttackerUI;

    [Command]
    public void CmdIncrementNb()
    {
        for (int i = 0; i < ennemiesConfig.Length; i++)
        {
            ennemiesConfig[i].number++;
        }
        RefreshDisplays();
    }

    [Command]
    public void CmdDecrementNb()
    {
        for (int i = 0; i < ennemiesConfig.Length; i++)
        {
            ennemiesConfig[i].number--;
        }
        RefreshDisplays();
    }

    void RefreshDisplays()
    {
        for(int i = 0; i < ennemiesConfig.Length; i++)
        {
            if(NbOfEnnemiesText[i])
            {
                NbOfEnnemiesText[i].text = ennemiesConfig[i].number.ToString();
            }
        }
    }

    public void EnableUi(PlayerScript playerscript)
    {
        
        if (isClient)
        {
            AttackerUI.gameObject.SetActive(true);
            AttackerUI.worldCamera = playerscript.Camera;
        }
    }

    public void DiableUi()
    {
        AttackerUI.gameObject.SetActive(false);
    }

    #endregion
}
