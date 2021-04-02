using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "ConstellationsAR/database/star database")]
public class StarDatabaseLoader : DatabaseLoader
{
    public string path;
    [HideInInspector]
    public StarData[] stars;

    public int leng;

    public override void OnDatabaseLoad()
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
