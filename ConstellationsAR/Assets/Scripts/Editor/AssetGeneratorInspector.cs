using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AssetGenerator), true)]
public class AssetGeneratorInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        AssetGenerator assetGenerator = (AssetGenerator) target;
        
        if (GUILayout.Button("Generate Mesh"))
            assetGenerator.Generate();
    }
}
