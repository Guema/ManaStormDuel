using UnityEngine;
using System.Collections;

public class ButtonBuyTower : MonoBehaviour {

    [SerializeField]
    TowerBaseScript towerBaseScript;
    [SerializeField]
    new Collider collider;
    [SerializeField]
    PlayerStatsScript playerStatsScript;
    
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update ()
    {
        if(Camera.current)
        {
            transform.LookAt(Camera.current.transform.position);
        }
	}

    void OnMouseDown()
    {
        if(playerStatsScript.mainCamera)
        {      
            RaycastHit hit;
            var ray = playerStatsScript.mainCamera.ScreenPointToRay(Input.mousePosition);
            if (collider.Raycast(ray, out hit, 100f))
            {
                if (hit.collider == collider)
                {
                    if(playerStatsScript.Mana >= 60)
                    {
                        playerStatsScript.Mana -= 60;
                        towerBaseScript.BuyButtonPressed();
                        gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}
