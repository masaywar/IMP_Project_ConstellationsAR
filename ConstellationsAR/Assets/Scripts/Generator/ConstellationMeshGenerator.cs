using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "ConstellationsAR/AssetGenerator/ConstellationMesh")]
public class ConstellationMeshGenerator : AssetGenerator
{
    public ConstellationDatabaseLoader cachedConstllationDatabaseLoader;
    
    protected override void GenerateAsset()
    {
        cachedConstllationDatabaseLoader = ConstellationDatabaseLoader.Instance;

#if UNITY_EDITOR
        cachedConstllationDatabaseLoader.
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
