using UnityEngine;


[CreateAssetMenu(menuName = "StarChart/Asset Generators/Constellation Overlay")]
public class ConstellationOverlayPrefabGenerator : AssetGenerator
{

    public GameObject canvasPrefab;
    public GameObject overlayPrefab;


    public ConstellationDatabaseLoader cachedDatabaseLoader;

    protected override void GenerateAsset()
    {
        cachedDatabaseLoader = (ConstellationDatabaseLoader)ConstellationDatabaseLoader.Instance;
        var canvasInstance = GameObject.Instantiate(canvasPrefab);
#if UNITY_EDITOR
        cachedDatabaseLoader
        .constellations
            .ForEach(c => CreateTextOverlayInstance(c, canvasInstance.transform));
        AssetUtility.SavePrefabAsset(folderPath, canvasInstance);
#endif

    }

    GameObject CreateTextOverlayInstance(ConstellationData constellation, Transform parent)
    {
        var instance = GameObject.Instantiate(overlayPrefab);
        instance.transform.SetParent(parent, false);
        instance.GetComponent<ConstellationOverlayText>().SetConstellation(constellation);
        instance.name = constellation.name;
        return instance;
    }


}