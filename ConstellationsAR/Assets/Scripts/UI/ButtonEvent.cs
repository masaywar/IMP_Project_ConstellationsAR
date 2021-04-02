using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class ButtonEvent : MonoBehaviour
{
    // Canvas
    private GameObject HomeCanvas;
    private GameObject InformationCanvas;  // possible to modify
    private GameObject ScreenshotCanvas;

    // Button

    // Home
    private Button getinfo;
    private Button getscreen;

    // Information in panel or canvas
    private Button closeinfo;

    // Screenshot
    private Button takescreenshot;
    private Button closescreen;

    // Start is called before the first frame update
    void Start()
    {
        // Get Canvas

        HomeCanvas = transform.Find("Home Canvas").gameObject;
        InformationCanvas = transform.Find("Information Canvas").gameObject;  // possible to modify
        ScreenshotCanvas = transform.Find("Camera Canvas").gameObject;
        
        // Get Button

        // Button to tranfer information canvas (possible modify)
        getinfo = HomeCanvas.transform.GetChild(0).transform.Find("DetailButton").GetComponent<Button>(); 
        getscreen = HomeCanvas.transform.GetChild(0).transform.Find("CameraButton").GetComponent<Button>();
        
        closeinfo = InformationCanvas.transform.GetChild(0).transform.Find("CancelButton").GetComponent<Button>(); 

        takescreenshot = ScreenshotCanvas.transform.GetChild(0).transform.Find("ShutterButton").GetComponent<Button>(); 
        closescreen = ScreenshotCanvas.transform.GetChild(0).transform.Find("CancelButton").GetComponent<Button>(); 
    }

    // Update is called once per frame
    void Update()
    {
        // Home Screen Button event
        getinfo.onClick.AddListener(OpenInformation);
        getscreen.onClick.AddListener(OpenScreenshot);

        // information screen button event
        closeinfo.onClick.AddListener(CloseInformation);

        // Screenshot screen button event
        closescreen.onClick.AddListener(CloseScreenshot);
        takescreenshot.onClick.AddListener(TakePhoto);

    }

    void OpenInformation()
    {
        HomeCanvas.SetActive(false);
        InformationCanvas.SetActive(true);
    }

    void CloseInformation()
    {
        InformationCanvas.SetActive(false);
        HomeCanvas.SetActive(true);
    }

    void OpenScreenshot()
    {
        HomeCanvas.SetActive(false);
        ScreenshotCanvas.SetActive(true);
    }

    void CloseScreenshot()
    {
        ScreenshotCanvas.SetActive(false);
        HomeCanvas.SetActive(true);
    }
    void TakePhoto()
    {

    }
}
