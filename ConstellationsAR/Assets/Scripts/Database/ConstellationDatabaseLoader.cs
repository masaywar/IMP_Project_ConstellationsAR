using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using UnityEngine;

public class ConstellationDatabaseLoader : Singleton<ConstellationDatabaseLoader>
{
    public string folderPath;
    public ConstellationData[] constellations;
    public StarDatabaseLoader starDatabaseLoader;

    public void OnDatabaseLoad() {
        var names = GetNames();

        var constellationsPath = folderPath + "/constellationship.fab";

        constellations = IOUtility.OpenLines(constellationsPath).
            Select(l=> new ConstellationData(l, starDatabaseLoader))
            .ToArray();
         
        AssignConstellationNames(names);
    }

    Dictionary<string, string> GetNames()
    { 
        string namesPath = folderPath + "/Constellation_names.eng.fab";
        return IOUtility.
            OpenLines(namesPath)
            .Select(l =>
            {
                string key = Regex.Match(l, @"\w+").ToString();
                string valueDirty = Regex.Match(l, "_[(]\".*?\"[)]").ToString();
                string value = Regex.Replace(valueDirty, "[_\"()]", string.Empty);
                return new KeyValuePair<string, string>(key, value);
            })
            .ToDictionary(kvp=>kvp.Key, kvp => kvp.Value);
        
    }

    void AssignConstellationNames(Dictionary<string, string> names)
    {
        constellations.ForEach(c =>
        {
            string name;
            names.TryGetValue(c.id, out name);
            c.name = name == null ? "unknown" : name;
        });
    }
}
