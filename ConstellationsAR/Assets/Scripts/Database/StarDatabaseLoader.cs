using UnityEngine;
using System.Linq;

public class StarDatabaseLoader : Singleton<StarDatabaseLoader>
{
    public string path;
    [HideInInspector]
    public StarData[] stars;

    public int leng;

    public void OnDatabaseLoad()
    {
        string[] lines = IOUtility.OpenLines(path);
        stars = lines.
            Skip(1).
            Select(l => new StarData(l)).ToArray();

        leng = stars.Length;
    }

    public StarData GetStarByHipId(int hipId) 
    {
        var starData = stars.FirstOrDefault(s => s.hipId == hipId);
        if (starData == null)
            Debug.LogWarning("No hip id" + hipId);

        return starData;
    }
}
