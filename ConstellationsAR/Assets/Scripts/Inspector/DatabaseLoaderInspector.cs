using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DatabaseLoader), true)]
public class DatabaseLoaderInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        DatabaseLoader dbLoader = (DatabaseLoader)target;
        if (GUILayout.Button("Load Database"))
            dbLoader.OnDatabaseLoad();
    }
}
