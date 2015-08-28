﻿using UnityEngine;
using System.Collections;

public class Goto : MonoBehaviour {

    [SerializeField]
    public Transform dest;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        if(dest)
        {
            transform.position = Vector3.MoveTowards(transform.position, dest.position, Time.deltaTime * 15.0f);
        }        
	}
}
