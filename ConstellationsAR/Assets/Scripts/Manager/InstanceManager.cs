using UnityEngine;

public class InstanceManager : MonoBehaviour
{

    [HideInInspector]
    [SerializeField]
    GameObject starsInstance;
    //[HideInInspector]
    //[SerializeField]
    //GameObject constellationsInstance;
    //[HideInInspector]
    //[SerializeField]
    //GameObject constellationOverlayInstance;


    public StarDatabaseLoader starDatabaseLoader;
    //public ConstellationDatabaseLoader constellationDatabaseLoader;


    public StarMeshGenerator starMeshGenerator;
    //public ConstellationMeshGenerator constellationMeshGenerator;

    public MeshPrefabGenerator starPrefabGenerator;
    //public MeshPrefabGenerator constellationPrefabGenerator;
    //public ConstellationOverlayPrefabGenerator constellationOverlayPrefabGenerator;


    public void GenerateAndInstantiatePrefab()
    {
        starDatabaseLoader.OnDatabaseLoad();
        //constellation database must load after star database
        //constellationDatabaseLoader.LoadDatabase();

        starMeshGenerator.Generate();
        //constellationMeshGenerator.Generate();

        starPrefabGenerator.Generate();
        //constellationPrefabGenerator.Generate();

        //constellationOverlayPrefabGenerator.Generate();

        InstantiatePrefab();
    }


    public void InstantiatePrefab()
    {
        if (starsInstance != null)
            GameObject.DestroyImmediate(starsInstance);
        //if (constellationsInstance != null)
        //    GameObject.DestroyImmediate(constellationsInstance);
        //if (constellationOverlayInstance != null)
        //    GameObject.DestroyImmediate(constellationOverlayInstance);

        var starPrefab = AssetUtility.GetAssetAtPath<GameObject>(starPrefabGenerator.folderPath)[0];
        starsInstance = GameObject.Instantiate(starPrefab, Vector3.zero, Quaternion.identity, transform);

        //var constellationPrefab = AssetUtility.GetAssetAtPath<GameObject>(constellationPrefabGenerator.folderPath)[0];
        //constellationsInstance = GameObject.Instantiate(constellationPrefab, Vector3.zero, Quaternion.identity, transform);

        //var constellationOverlayPrefab = AssetUtility.GetAssetAtPath<GameObject>(constellationOverlayPrefabGenerator.folderPath)[0];
        //constellationOverlayInstance = GameObject.Instantiate(constellationOverlayPrefab, Vector3.zero, Quaternion.identity, transform);
    }


}