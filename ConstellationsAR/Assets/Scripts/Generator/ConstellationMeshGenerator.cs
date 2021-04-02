using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEngine;
#endif
using System.Linq;

[CreateAssetMenu(menuName = "ConstellationsAR/AssetGenerator/ConstellationMesh")]
public class ConstellationMeshGenerator : AssetGenerator
{
    public ConstellationDatabaseLoader m_cachedConstellationDBLoader;
    
    protected override void GenerateAsset()
    {
#if UNITY_EDITOR
        m_cachedConstellationDBLoader.
             constellations.Select(c => CreateMesh(c.stars, c.name)).
             ForEach(m => AssetUtility.SaveMeshAsset(folderPath, m));
#endif
    }

    Mesh CreateMesh(StarData[] stars, string name)
    {
        var mesh = new Mesh();
        mesh.name = name;

        mesh.vertices = stars
            .Select(s => s.position).ToArray();

        int[] indicies = stars.
            Select((s, i) => i).ToArray();

        mesh.SetIndices(indicies, MeshTopology.Lines, 0);
        return mesh;
    }
}
