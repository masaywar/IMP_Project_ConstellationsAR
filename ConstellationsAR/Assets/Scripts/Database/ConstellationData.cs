using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text.RegularExpressions;

[System.Serializable]
public class ConstellationData
{
    public string id;
    public string name;
    public StarData[] stars;
    public Vector3 position;

    public ConstellationData(string whiteSpaceText, StarDatabaseLoader starDatabaseLoader)
    {
        var lines = Regex.Split(whiteSpaceText.Trim(), @"\s+").ToArray();

        id = lines[0];

        stars = lines.
            Skip(2)
            .Select(idstr => int.Parse(idstr))
            .Select(idInt => starDatabaseLoader.GetStarByHipId(idInt))
            .ToArray();

        position = stars
            .Select(s => s.position)
            .Aggregate((p, total) => total + p)
            / stars.Length;
    }

    public override string ToString()
    {
        return string.Format("id: {0}\tname: {1}\tnumber of lines:{2}", id, name, stars.Length);
    }
}
