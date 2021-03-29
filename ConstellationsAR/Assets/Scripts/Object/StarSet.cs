using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSet : Object
{
    public Star starObj;
    private List<Star> stars = new List<Star>();
    private StarDatabaseLoader starDB;
    private void Awake()
    {
        starDB = (StarDatabaseLoader)StarDatabaseLoader.Instance;
    }

    private void Start()
    {
        MakeStarSet();
    }

    private void MakeStarSet() 
    {
        foreach (StarData starData in starDB.stars) 
        {
            Star star = Instantiate(starObj, starData.position, Quaternion.identity, this.transform);
            star.properName = starData.properName;
            star.position = starData.position;
            star.hygId = starData.hygId;
            star.gameObject.SetActive(true);
            stars.Add(star);
        }
    }
}
