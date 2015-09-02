using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class DirectDamageDialog : EditorWindow
{
    string effectName = "Enter Name Here";
    string description = "Description here";
    int damage = 10;

    [MenuItem("Tools/Effects/Create Direct Damage Effect")]
    static void Init()
    {
        DirectDamageDialog window = (DirectDamageDialog)EditorWindow.GetWindow(typeof(DirectDamageDialog));
        // Creation of Spell manager database.
        window.Show();
    }

    void OnGUI()
    {
        effectName = EditorGUILayout.TextField("Name :", effectName);
        description = EditorGUILayout.TextField("Description :", description);
        damage = EditorGUILayout.IntField("Damage :", damage);

        if (GUILayout.Button("Create Effect"))
        {
            DamageEffect newDamageEffect = CreateInstance<DamageEffect>() as DamageEffect;
            newDamageEffect.name = effectName;
            newDamageEffect._description = description;
            newDamageEffect._damage = damage;
            AssetDatabase.CreateAsset(newDamageEffect, "Assets/Scriptable/" + newDamageEffect.name + ".asset");
            AssetDatabase.SaveAssets();
        }
    }
}

