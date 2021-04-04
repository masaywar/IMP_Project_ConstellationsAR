
#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public static class AssetUtility
{
    public static void ClearAssetFolder(string folderPath)
    {
        GetAssetPaths(folderPath).
            ForEach(path=>AssetDatabase.DeleteAsset(path));
        //for each path, delete asset.
    }

    public static string[] GetAssetPaths(string folderPath)
    {
        return AssetDatabase.FindAssets("", new[] { folderPath }).
            Select(guid => AssetDatabase.GUIDToAssetPath(guid)).ToArray();
    }

    public static void SaveMeshAsset(string folderPath, Mesh mesh)
    {
        string assetPath = folderPath + "/" + mesh.name + ".mesh";
        AssetDatabase.CreateAsset(mesh, assetPath);
    }

    public static T[] GetAssetAtPath<T>(string folderPath) where T : UnityEngine.Object
    {
        return GetAssetPaths(folderPath).
            Select(p => AssetDatabase.LoadAssetAtPath<T>(p)).ToArray();
    }

    public static void SavePrefabAsset(string folderPath, GameObject go) 
    {
        string assetPath = folderPath + "/" + go.name + ".prefab";
        PrefabUtility.SaveAsPrefabAsset(go, assetPath);
        GameObject.DestroyImmediate(go);
    }
}

#endif