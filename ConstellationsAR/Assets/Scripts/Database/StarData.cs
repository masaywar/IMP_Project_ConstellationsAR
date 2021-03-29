using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class StarData
{
    public int hygId;
    public string properName;
    public Vector3 position;

    public StarData(string line)
    {
        string[] lines = line.Split(',');

        hygId = ParseUtiltiy.SafeIntParse(lines[0]);
        properName = lines[6];
        position = new Vector3(
            ParseUtiltiy.SafeFloatParse(lines[17]),
            ParseUtiltiy.SafeFloatParse(lines[18]),
            ParseUtiltiy.SafeFloatParse(lines[19])
        );
    }
}
