using UnityEngine;
using System.Collections;

public class Effect : ScriptableObject
{
    [SerializeField]
    public string _description = "Description";

    public string Descritpion
    {
        get { return _description; }
    }
}
