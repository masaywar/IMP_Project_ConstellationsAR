using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : Object
{
    public int hygId;
    public string properName;
    public Vector3 position;
    public Star(int hygId, string properName, Vector3 position) 
    {
        this.hygId = hygId;
        this.properName = properName;
        this.position = position;
    }
}
