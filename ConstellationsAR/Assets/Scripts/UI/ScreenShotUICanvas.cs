using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ScreenShotUICanvas : UIWindow
{
    public GameObject HomeCanvas;

    public Button bttn4Screenshot;
    public Button bttn4CloseScreenshotCanvas;

    void Awake() 
    {
        bttn4CloseScreenshotCanvas.onClick.AddListener(CloseScreenshotCanvas);
    }

    private void CloseScreenshotCanvas()
    {
        this.gameObject.SetActive(false);
        HomeCanvas.SetActive(true);
    }
}
