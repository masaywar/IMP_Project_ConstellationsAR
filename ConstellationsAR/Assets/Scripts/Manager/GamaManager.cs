using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamaManager : Singleton<GamaManager>
{
    [SerializeField]
    public ConstellationJsonDataArray.Data[] datas;
    public string AssetPath = Application.dataPath;

    private void Awake()
    {
        ConstellationJsonDataArray c = new ConstellationJsonDataArray();
        datas = c.data;
    }
}
