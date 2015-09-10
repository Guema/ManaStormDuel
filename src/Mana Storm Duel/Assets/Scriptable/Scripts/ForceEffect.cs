using UnityEngine;
using System.Collections;

public class ForceEffect : Effect {

    [SerializeField]
    public float _force = 0f;

    public float Force
    {
        get
        {
            return _force;
        }
    }
}
