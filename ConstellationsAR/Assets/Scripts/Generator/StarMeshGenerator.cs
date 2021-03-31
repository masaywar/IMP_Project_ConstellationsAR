using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "ConstellationsAR/AssetGenerator/StarMesh")]
public class StarMeshGenerator : AssetGenerator
{
    public StarDatabaseLoader m_cachedStarDBLoader;
    [Range(2000, 30000)]
    public int starsPerMesh = 10000;
    protected override void GenerateAsset()
    {
        for (int i = 0; i < m_cachedStarDBLoader.stars.Length; i += starsPerMesh)
        {
            string name = "stars " + (i / starsPerMesh);
            StarData[] subStars = m_cachedStarDBLoader.stars.SubArray(i, starsPerMesh).ToArray();
            var mesh = CreateMesh(subStars, name);
            AssetUtility.SaveMeshAsset(folderPath, mesh);
        }
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
