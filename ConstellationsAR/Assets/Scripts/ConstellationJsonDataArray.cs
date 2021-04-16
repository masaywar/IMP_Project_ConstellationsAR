using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ConstellationJsonDataArray
{
    public Data[] data;

    public ConstellationJsonDataArray()
    {
        LoadConstellationData2Json();
    }

    public void LoadConstellationData2Json()
    {
        string fileName = "Constellations.json";

        string json = ExtensionMethod.LoadJson(GamaManager.Instance.AssetPath, fileName);
        data = ExtensionMethod.FromJson<Data>(json);
    }

    [System.Serializable]
    public class Data
    {
        public string image;
        public string name;
        public string story;
        public string facts;
        public string period;
    }
}




