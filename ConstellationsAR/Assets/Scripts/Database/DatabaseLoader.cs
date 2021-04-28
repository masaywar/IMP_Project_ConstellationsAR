using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DatabaseLoader : Singleton<DatabaseLoader>
{
    public abstract void OnDatabaseLoad();
}
