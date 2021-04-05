using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class HomeUICanvas : UIWindow
{   
    public GameObject InformationCanvas;
    public GameObject ScreenShotCanvas;

    public Button bttn4OpenInfo;
    public Button bttn4OpenScreenshot;

    void Awake() 
    {   
        bttn4OpenInfo.onClick.AddListener(OpenInformationCanvas);
        bttn4OpenScreenshot.onClick.AddListener(OpenScreenShotCanvas);
    }

    private void OpenInformationCanvas()
    {
        this.gameObject.SetActive(false);
        InformationCanvas.SetActive(true);
    }
    private void OpenScreenShotCanvas()
    {
        this.gameObject.SetActive(false);
        ScreenShotCanvas.SetActive(true);
    }
}
