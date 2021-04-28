using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    public ConstellationJsonDataArray.Data[] datas;
    public StarDatabaseLoader starDatabaseLoader;

    private enum LoadingState { 
        init, load,inGame,  end
    }

    LoadingState loadingState = LoadingState.init;

    private void Awake()
    {
        InstanceManager.Instance.GenerateAndInstantiatePrefab();
        ConstellationJsonDataArray c = new ConstellationJsonDataArray();
        datas = c.data;

       
    }

    private void Update()
    {
        switch (loadingState)
        {
            case LoadingState.init:
                loadingState = LoadingState.load;
                print(loadingState);
                break;

            case LoadingState.load:
                InstanceManager.Instance.GenerateAndInstantiatePrefab();
                loadingState = LoadingState.inGame;
                break;

            case LoadingState.inGame:
                break;

            case LoadingState.end:
                Application.Quit(0);
                break;
        }
    }
}
