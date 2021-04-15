using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamaManager : Singleton<GamaManager>
{
    [SerializeField]
    public ConstellationJsonDataArray.Data[] datas;
    public string AssetPath;

    public StarDatabaseLoader starDatabaseLoader;
    public ConstellationDatabaseLoader constellationDatabaseLoader;

    private void Awake()
    {
        AssetPath = Application.dataPath;
        ConstellationJsonDataArray c = new ConstellationJsonDataArray();
        datas = c.data;
    }
}
