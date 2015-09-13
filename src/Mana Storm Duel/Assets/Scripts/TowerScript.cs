using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.EventSystems;

public class TowerScript : NetworkBehaviour {

    [SerializeField]
    GameObject[] towersPrefabs;
    GameObject[] towers;
    [SyncVar]
    int UpgradeLevel = 0;


    //On game loading
	void Awake()
    {
        towers = new GameObject[towersPrefabs.Length];
        for(int i = 0; i < towersPrefabs.Length; i++)
        {
            if(towersPrefabs[i])
            {
                towers[i] = Instantiate(towersPrefabs[i]);
                towers[i].transform.parent = transform;
                towers[i].transform.localPosition = Vector3.zero;
                if (i != UpgradeLevel)
                    towers[i].SetActive(false);
            }
        }
    }

    public void BuyButtonPressed()
    {
        UpgradeLevel++;
        for (int i = 0; i < towers.Length; i++)
        {
            if (i == UpgradeLevel)
            {
                if(towers[i])
                    towers[i].SetActive(true);
            }
            else
            {
                if(towers[i])
                    towers[i].SetActive(false);
            }
        }
    }
}
