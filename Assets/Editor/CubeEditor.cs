using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(World))]
public class CubeEditor : Editor
{
    World world;

    public override void OnInspectorGUI()
    {
        using (var check = new EditorGUI.ChangeCheckScope())
        {
            base.OnInspectorGUI();
            if (check.changed)
                world.Populate();
        }

        if (GUILayout.Button("Populate"))
        {
            world.Populate();
        }
    }

    private void OnEnable()
    {
        world = (World)target;
    }
}
