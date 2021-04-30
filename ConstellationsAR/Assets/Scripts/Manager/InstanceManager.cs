
using UnityEngine;

public class InstanceManager : Singleton<InstanceManager>
{

    [HideInInspector]
    [SerializeField]
    GameObject starsInstance;
    [HideInInspector]
    [SerializeField]
    GameObject constellationsInstance;
    [HideInInspector]
    [SerializeField]
    GameObject constellationOverlayInstance;

    public StarMeshGenerator starMeshGenerator;
    public ConstellationMeshGenerator constellationMeshGenerator;

    public MeshPrefabGenerator starPrefabGenerator;
    public MeshPrefabGenerator constellationPrefabGenerator;
    public ConstellationOverlayPrefabGenerator constellationOverlayPrefabGenerator;

    public void GenerateAndInstantiatePrefab()
    {
#if UNITY_EDITOR
        //StarDatabaseLoader.Instance.OnDatabaseLoad();
        //ConstellationDatabaseLoader.Instance.OnDatabaseLoad();

        //starMeshGenerator.Generate();
        //constellationMeshGenerator.Generate();

        //starPrefabGenerator.Generate();
        //constellationPrefabGenerator.Generate();

        //constellationOverlayPrefabGenerator.Generate();
#endif
        InstantiatePrefab();
    }


    public void InstantiatePrefab()
    {
        if (starsInstance != null)
            GameObject.DestroyImmediate(starsInstance);
        if (constellationsInstance != null)
            GameObject.DestroyImmediate(constellationsInstance);
        if (constellationOverlayInstance != null)
            GameObject.DestroyImmediate(constellationOverlayInstance);

        var starPrefab = Resources.LoadAll<GameObject>("Prefabs/Stars")[0];
        starsInstance = Instantiate(starPrefab, Vector3.zero, Quaternion.identity);

        var constellationPrefab = Resources.LoadAll<GameObject>("Prefabs/Constellations")[0];
        constellationsInstance = GameObject.Instantiate(constellationPrefab, Vector3.zero, Quaternion.identity);

       
        var constellationOverlayPrefab = Resources.Load<GameObject>("Prefabs/UIPrefab");
        Instantiate(constellationOverlayPrefab, Vector3.zero, Quaternion.identity);

    }


}