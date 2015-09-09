using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStatsScript : MonoBehaviour {

    [SerializeField]
    int mana = 200;
    [SerializeField]
    Text manaText;
    [SerializeField]
    int anima = 0;
    [SerializeField]
    Text animaText;
    [SerializeField]
    TowerBaseScript[] towerBases;
    [SerializeField]
    public Camera mainCamera;

    public int Mana
    {
        get
        {
            return mana;
        }

        set
        {
            mana = value;
            if(manaText)
                manaText.text = mana.ToString();
        }
    }

    public int Anima
    {
        get
        {
            return anima;
        }

        set
        {
            anima = value;
            if(animaText)
                animaText.text = anima.ToString();
        }
    }

    // Use this for initialization
    void Start () {
        if(manaText)
            manaText.text = mana.ToString();
        if(animaText)
            animaText.text = anima.ToString();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
