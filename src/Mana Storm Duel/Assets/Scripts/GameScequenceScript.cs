using UnityEngine;
using System;
using System.Collections;

public class GameScequenceScript : MonoBehaviour {

    enum GameState
    {
        pausePhase,
        combatPhase
    }

    [SerializeField]
    float timeRemaining = 0.0f;

    [SerializeField]
    EnnemyWavesScript ennemyWavesScript;

    [SerializeField]
    GameState gamePhase = GameState.pausePhase;

	// Use this for initialization
	void Start () {
        OnWaveCleaned();
	}
	
	// Update is called once per frame
	void Update () {

	}


    public delegate void ChronoCallback();
    public void OnWaveCleaned()
    {
        gamePhase = GameState.pausePhase;
        StartCoroutine(Chronometer(5f, OnStartWave));
    }

    public void OnStartWave()
    {
        gamePhase = GameState.combatPhase;
        ennemyWavesScript.StartWave();
        StartCoroutine(Chronometer(20f, OnWaveCleaned));
    }


    IEnumerator Chronometer(float timer, ChronoCallback EndFunction)
    {
        float start = Time.time;
        Debug.Log("Chrono démarré");
        while (Time.time - start < timer)
        {
            timeRemaining = timer - (Time.time - start);
            yield return new WaitForSeconds(0.1f);
        }
        timeRemaining = 0f;
        EndFunction();
        Debug.Log("Stop");
        yield break;
    }
}
