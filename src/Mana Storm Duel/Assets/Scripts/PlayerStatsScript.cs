using UnityEngine;
using System.Collections;

public class PlayerStatsScript : MonoBehaviour {

    [SerializeField]
    int Mana = 200;
    [SerializeField]
    int Anima = 0;

    [SerializeField]
    TowerBaseScript[] towerBases;
    [SerializeField]
    public Camera mainCamera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
