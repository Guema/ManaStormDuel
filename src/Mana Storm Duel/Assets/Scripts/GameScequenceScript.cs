using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;

public class GameScequenceScript : NetworkBehaviour {

    enum GameState
    {
        initializingPhase,
        pausePhase,
        combatPhase
    }

    [SerializeField]
    float pauseLength = 15f;

    [SerializeField]
    float waveLength = 30f;

    [SyncVar]
    [SerializeField]
    float timeRemaining = 0.0f;

    [SerializeField]
    EnnemyWavesScript ennemyWavesScript;

    [SyncVar]
    [SerializeField]
    GameState gamePhase = GameState.initializingPhase;

    // Use this for initialization
    void Start()
    {
        gamePhase = GameState.initializingPhase;
    }

    public delegate void ChronoCallback();

    public void OnLetsPlay()
    {
        gamePhase = GameState.pausePhase;
        StartCoroutine(Chronometer(10f, OnStartWave));
    }


    public void OnWaveCleaned()
    {
        gamePhase = GameState.pausePhase;
        StartCoroutine(Chronometer(pauseLength, OnStartWave));
    }

    public void OnStartWave()
    {
        gamePhase = GameState.combatPhase;
        ennemyWavesScript.StartWave();
        StartCoroutine(Chronometer(waveLength, OnWaveCleaned));
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
