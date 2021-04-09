using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;

public class HomeUICanvas : UIWindow
{   
    public GameObject InformationCanvas;
    public GameObject ScreenShotCanvas;

    public Button bttn4OpenScreenshot;
    public List<Button> bttn4OpenInfo = new List<Button>();
    public TextMeshProUGUI ConstellationName;

    void Awake() 
    {           
        for (int i = 0; i < this.transform.childCount; i++)
        {
            bttn4OpenInfo.Add(this.transform.GetChild(i).GetComponent<Button>());
        }
        
        for (int i=0; i< bttn4OpenInfo.Count; i++)
        {
            if(bttn4OpenInfo[i].name == "ToScreenshotButton")
            {
                bttn4OpenInfo.RemoveAt(i);
            }
        }

        foreach (Button button in bttn4OpenInfo)
        {
            button.onClick.AddListener(() => OpenInformationCanvas(button.name));
        }
        
        bttn4OpenScreenshot.onClick.AddListener(OpenScreenShotCanvas);
    }

    private void OpenInformationCanvas(string buttonname)
    {
        InformationCanvas.SetActive(true);
        ConstellationName.text = buttonname;

    }
    private void OpenScreenShotCanvas()
    {
        this.gameObject.SetActive(false);
        ScreenShotCanvas.SetActive(true);
    }
}
