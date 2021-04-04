using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ConstellationsAR/AssetGenerator/starPrefab")]
public class MeshPrefabGenerator : AssetGenerator
{
    public AssetGenerator meshGenerator;
    public string prefabName = "Mesh Prefab";
    public Material material;

    protected override void GenerateAsset()
    {
#if UNITY_EDITOR
        var parentPrefab = new GameObject(prefabName);
        AssetUtility.GetAssetAtPath<Mesh>(meshGenerator.folderPath).
            ForEach(m => CreateMeshGameObjet(m, parentPrefab));

        AssetUtility.SavePrefabAsset(folderPath, parentPrefab);
#endif
    }

    GameObject CreateMeshGameObjet(Mesh mesh, GameObject parent)
    {
        GameObject go = new GameObject(mesh.name);
        go.transform.parent = parent.transform;
        go.AddComponent<MeshFilter>().mesh = mesh;
        go.AddComponent<MeshRenderer>().material = material;

        return go;
    }
}
