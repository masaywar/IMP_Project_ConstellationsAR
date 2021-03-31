using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "ConstellationsAR/AssetGenerator/StarMesh")]
public class StarMeshGenerator : AssetGenerator
{
    public StarDatabaseLoader m_cachedStarDBLoader;

    protected override void GenerateAsset()
    {
        var mesh = CreateMesh(m_cachedStarDBLoader.stars, "stars");
        AssetUtility.SaveMeshAsset(folderPath, mesh);
    }

    Mesh CreateMesh(StarData[] stars, string name) 
    {
        var mesh = new Mesh();
        mesh.name = name;

        mesh.vertices = stars
            .Select(s => s.position).ToArray();

        int[] indicies = stars.
            Select((s, i) => i).ToArray();

        mesh.SetIndices(indicies, MeshTopology.Points, 0);
        return mesh;
    }
}
