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

    //Panel
    private GameObject homepanel;
    private GameObject infopanel;
    private GameObject screenshotpanel;

    // Button
    // In Home
    private Button getinfo;
    private Button getscreen;

    // Information in panel or canvas
    private Button closeinfo;

    // Screenshot
    private Button takescreenshot;
    private Button closescreen;

    // Motion Animation Boolean (Test)
    private bool transition;

    // Start is called before the first frame update
    void Start()
    { 
        // Get Canvas
        HomeCanvas = transform.Find("Home Canvas").gameObject;
        InformationCanvas = transform.Find("Information Canvas").gameObject;  // possible to modify
        ScreenshotCanvas = transform.Find("Screenshot Canvas").gameObject;
        
        // Get Panel
        homepanel = HomeCanvas.transform.Find("Home Panel").gameObject;
        infopanel = InformationCanvas.transform.Find("Information Panel").gameObject;
        screenshotpanel = ScreenshotCanvas.transform.Find("Screenshot Panel").gameObject;

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

        // Information Panel Motion
        if (transition == true)
        {
            OpenMotion();
        }
        if (transition == false)
        {
            CloseMotion();
        }
        

    }
    void OpenMotion()
    {
        GameObject infopanel = InformationCanvas.transform.GetChild(0).gameObject;
    
        if (infopanel.GetComponent<RectTransform>().localScale.x < 0.8f)
        {
            infopanel.GetComponent<RectTransform>().localScale += new Vector3(1,1,1) * 2.0f * Time.deltaTime;
        }
        else if (infopanel.GetComponent<RectTransform>().localScale.x >= 0.8f && infopanel.GetComponent<RectTransform>().localScale.x < 1)
        {
            infopanel.GetComponent<RectTransform>().localScale += new Vector3(1,1,1) * 1.0f * Time.deltaTime;
        }
        else
        {
            infopanel.GetComponent<RectTransform>().localScale = new Vector3 (1,1,1);
        }
    }
    void CloseMotion()
    {
        GameObject infopanel = InformationCanvas.transform.GetChild(0).gameObject;
        
        if (infopanel.GetComponent<RectTransform>().localScale.x > 0.2f)
        {
            infopanel.GetComponent<RectTransform>().localScale -= new Vector3(1,1,1) * 2.0f * Time.deltaTime;
        }
        else if (infopanel.GetComponent<RectTransform>().localScale.x <= 0.2f && infopanel.GetComponent<RectTransform>().localScale.x > 0)
        {
            infopanel.GetComponent<RectTransform>().localScale -= new Vector3(1,1,1) * 1.0f * Time.deltaTime;
        }
        else
        {
            infopanel.GetComponent<RectTransform>().localScale = new Vector3 (0,0,0);
            InformationCanvas.SetActive(false);
            HomeCanvas.SetActive(true);
        }
    }

    void OpenInformation()
    {
        HomeCanvas.SetActive(false);
        InformationCanvas.SetActive(true);
        transition = true;
    }

    void CloseInformation()
    {   
        transition = false;
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
