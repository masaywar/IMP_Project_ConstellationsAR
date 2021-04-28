using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WholeUICanvas : MonoBehaviour
{
    public CanvasGroup homeUI;
    public CanvasGroup infoUI;
    public CanvasGroup shotUI;


    public void OnHomeUIOpened()
    {
        homeUI.interactable = true;
        infoUI.interactable = false;
        shotUI.interactable = false;
    }

    public void OnInfoUIOpened()
    {
        homeUI.interactable = false;
        infoUI.interactable = true;
        shotUI.interactable = false;
    }

    public void OnScreenShotOpened()
    {
        homeUI.interactable = false;
        infoUI.interactable = false;
        shotUI.interactable = true;
    }
}
