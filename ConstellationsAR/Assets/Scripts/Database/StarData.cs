using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class StarData
{
    public int hygId;
    public int hipId;
    public string properName;

    public float apparentMagnitude;
    public float absoluteMagnitude;

    public float colorIndex;
    public Color color;

    public Vector3 position;
    public Vector3 velocity;

    public StarData(string line)
    {
        string[] lines = line.Split(',');

        hygId = ParseUtiltiy.SafeIntParse(lines[0]);
        hipId = ParseUtiltiy.SafeIntParse(lines[1]);

        apparentMagnitude = ParseUtiltiy.SafeFloatParse(lines[13]);
        absoluteMagnitude = ParseUtiltiy.SafeFloatParse(lines[14]);

        colorIndex = ParseUtiltiy.SafeFloatParse(lines[16]);
        color = ColorUtility.ColorIndexToRGB(colorIndex);

        properName = lines[6];
        position = new Vector3(
            ParseUtiltiy.SafeFloatParse(lines[17]),
            ParseUtiltiy.SafeFloatParse(lines[18]),
            ParseUtiltiy.SafeFloatParse(lines[19])
        );

        velocity = new Vector3(
            ParseUtiltiy.SafeFloatParse(lines[20]),
            ParseUtiltiy.SafeFloatParse(lines[21]),
            ParseUtiltiy.SafeFloatParse(lines[22])
        );

        position =  Vector3.ClampMagnitude(position, 1000);
    }
}
