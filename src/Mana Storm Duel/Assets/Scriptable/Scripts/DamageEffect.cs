using UnityEngine;
using System.Collections;
using System;


public class DamageEffect : Effect
{
    [SerializeField]
    public int _damage;

    public int Damage
    {
        get { return _damage; }
    }
}
