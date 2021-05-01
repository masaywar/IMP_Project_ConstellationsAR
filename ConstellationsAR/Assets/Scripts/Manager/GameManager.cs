using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    public ConstellationJsonDataArray.Data[] datas;
    public StarDatabaseLoader starDatabaseLoader;

    public enum LoadingState {
        init, tele ,load, inGame, end
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

    public float scaleSize = 1f;

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

            case LoadingState.tele:
#if UNITY_EDITOR
                loadingState = LoadingState.load;
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
                break;
#endif

                loadingState = LoadingState.init;
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex+1);
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
