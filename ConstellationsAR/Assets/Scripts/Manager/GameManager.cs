using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    public ConstellationJsonDataArray.Data[] datas;
    public StarDatabaseLoader starDatabaseLoader;

    public enum LoadingState {
        init, load, inGame, end
    }

    private LoadingState _loadingState = LoadingState.init;

    public LoadingState loadingState
    {
        set {
            _loadingState = value;
        }
        get {
            return _loadingState;
        }
    }

    private void Awake()
    {
        ConstellationJsonDataArray c = new ConstellationJsonDataArray();
        datas = c.data;
    }

    private void Update()
    {
        switch (loadingState)
        {
            case LoadingState.init:
                break;

            case LoadingState.load:
                loadingState = LoadingState.inGame;

                int loadingScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
                UnityEngine.SceneManagement.SceneManager.LoadScene(loadingScene + 1);
                break;

            case LoadingState.inGame:
                InstanceManager.Instance.GenerateAndInstantiatePrefab();
                loadingState = LoadingState.init;
                break;

            case LoadingState.end:
                Application.Quit(0);
                break;
        }
    }
}
