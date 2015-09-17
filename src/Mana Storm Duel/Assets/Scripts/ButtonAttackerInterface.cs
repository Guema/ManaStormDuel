using UnityEngine;
using System.Collections;
using System;

public class ButtonAttackerInterface : Floating3DTigger {

    [SerializeField]
    SpawnerScript spawner;

    public override void OnPlayerClick(PlayerScript playerScript)
    {
        spawner.EnableUi(playerScript);
    }
}
