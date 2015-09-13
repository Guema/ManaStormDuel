using UnityEngine;
using System.Collections;

public class ButtonBuyTower : MonoBehaviour {

    [SerializeField]
    TowerScript towerBaseScript;
    [SerializeField]
    new Collider collider;
    [SerializeField]
    PlayerScript playerScript;
    
	// Use this for initialization

    void OnMouseUp()
    {  
        RaycastHit hit;
        var ray = playerScript.mainCamera.ScreenPointToRay(Input.mousePosition);
        bool result;
        if (result = Physics.Raycast(ray, out hit, 1000f))
        {
            
            if (hit.collider == collider)
            {
                if(playerScript.Mana >= 60)
                {
                    playerScript.Mana -= 60;
                    towerBaseScript.BuyButtonPressed();
                    gameObject.SetActive(false);
                }
            }
        }
        Debug.Log(result);
    }
}
