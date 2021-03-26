using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DatabaseLoader : Singleton<DatabaseLoader>
{
    public string filepath;

    public abstract void OnDatabaseLoad(string path);
}
