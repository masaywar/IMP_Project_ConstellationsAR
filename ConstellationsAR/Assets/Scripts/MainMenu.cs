using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.Instance.loadingState = GameManager.LoadingState.tele;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting");
        GameManager.Instance.loadingState = GameManager.LoadingState.end;
    }
}
