using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;

public class ScreenShotUICanvas : UIWindow
{
    public GameObject HomeCanvas;
    public WholeUICanvas parentUI;

    public Button bttn4Screenshot;
    public Button bttn4CloseScreenshotCanvas;

    public TextMeshProUGUI CountText;

    void Start()
    {
        Canvas thisCanvas = GetComponent<Canvas>();
        thisCanvas.worldCamera = Camera.main;
        thisCanvas.planeDistance = 1;

        CountText.gameObject.SetActive(false);
    }
    void Awake() 
    {
        bttn4CloseScreenshotCanvas.onClick.AddListener(CloseScreenshotCanvas);
        bttn4Screenshot.onClick.AddListener(TakeScreenShot);
    }

    public void TakeScreenShot()
    {   
        bttn4Screenshot.gameObject.SetActive(false);
        bttn4CloseScreenshotCanvas.gameObject.SetActive(false);
        CountText.gameObject.SetActive(true);
        
        StartCoroutine(Wait());
    }

    public void CloseScreenshotCanvas()
    {
        this.gameObject.SetActive(false);
        HomeCanvas.SetActive(true);
        parentUI.OnHomeUIOpened();
    }
    IEnumerator Wait()
    {
        for(int i = 3; i>=0; i--)
        {
            if (i ==0)
            {
                CountText.gameObject.SetActive(false);
                ScreenCapture.CaptureScreenshot("ConstellationScreenshot.png");
                yield return new WaitForSeconds(1.0f);
                bttn4Screenshot.gameObject.SetActive(true);
                bttn4CloseScreenshotCanvas.gameObject.SetActive(true);
            }
            else
            {
                CountText.text = i.ToString();
                yield return new WaitForSeconds(1.0f);
            }
        }
    }
}
