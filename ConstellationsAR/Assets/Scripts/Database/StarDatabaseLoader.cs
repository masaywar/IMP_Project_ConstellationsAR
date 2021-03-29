using UnityEngine;
using System.Linq;

public class StarDatabaseLoader : DatabaseLoader
{
    public string path;
    [HideInInspector]
    public StarData[] stars;

    public int leng;

    private void Awake()
    {
        OnDatabaseLoad();
    }

    public override void OnDatabaseLoad()
    {
        string[] lines = IOUtility.OpenLines(path);
        stars = lines.
            Skip(1).
            Select(l => new StarData(l)).ToArray();

        leng = stars.Length;
    }
}
