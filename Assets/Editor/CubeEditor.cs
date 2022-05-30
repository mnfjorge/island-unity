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
                world.GenerateCube();
        }

        if (GUILayout.Button("Generate"))
        {
            world.GenerateCube();
        }
    }

    private void OnEnable()
    {
        world = (World)target;
    }
}
