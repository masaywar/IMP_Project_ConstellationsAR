using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
