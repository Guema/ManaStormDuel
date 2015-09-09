using UnityEngine;
using System.Collections;

public class ButtonPanelScript : MonoBehaviour {

    [SerializeField]
    GameObject panel;
    [SerializeField]
    ControllerBehaviour controller;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Toggle()
    {
        panel.SetActive(!panel.activeSelf);
        controller.enabled = !panel.activeSelf;
    }
}
