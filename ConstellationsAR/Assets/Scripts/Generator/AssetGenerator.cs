using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEngine;
#endif

public abstract class AssetGenerator:ScriptableObject
{
    public string folderPath;
    protected abstract void GenerateAsset();

    public void Generate()
    {
#if UNITY_EDITOR
        AssetUtility.ClearAssetFolder(folderPath);
#endif
        GenerateAsset();
    }
}
