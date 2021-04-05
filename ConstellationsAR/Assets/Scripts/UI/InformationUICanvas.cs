using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

/// <summary>
///      
/// This class is example of informationCanvas script.
/// Anyone who engage in ui part, you can modify this script.
/// If you have anyquestion, please cantact to "Lee" 
/// </summary>


public class InformationUICanvas : UIWindow
{
    // Please declare variables as public which are
    // components of this canvas. 

    public GameObject HomeCanvas;

    public RectTransform InformationCanvas;
    public RectTransform InformationPanel;

    public Button bttn4CloseInfo;

    void Awake()
    {
        bttn4CloseInfo.onClick.AddListener(CloseInformationCanvas);
    }
   
    public void OnEnable()
    {
        //Action when this object activieSelf == true
        //InformationPanel open...  
        StartCoroutine(OpenInformationCanvas());      
        //if GetConsellatinfo is success, 
        //  Show data
        //else
        //  Nothing happened
    }

    public void OnDisable()
    {
        //Action when this object activieSelf == false
        //informationPanel close...

        //example of how to find canvas ui in uimanager class. 

        //UIManager.Instance.FindByWindowName<"Your scripted canvas">(this.name);
    }

    private bool GetConstellationInfo() 
    {
        //if load constellation data failed
        //  return false;

        return true;
    }

    private void CloseInformationCanvas()
    {
        this.gameObject.SetActive(false);
        HomeCanvas.SetActive(true);
    }
    
    IEnumerator OpenInformationCanvas()
    {
        if(InformationPanel.localScale.x < 0.8f)
        {
            yield return new WaitForSeconds(1000);
            InformationPanel.localScale += new Vector3(1,1,1) * 0.05f;
            
        }
        else if(InformationPanel.localScale.x >= 0.8f && InformationPanel.localScale.x < 1)
        {
            yield return new WaitForSeconds(1000);
            InformationPanel.localScale += new Vector3(1,1,1) * 0.07f;
        }
        else 
        {
            InformationPanel.localScale = new Vector3(1,1,1);
        }
    }
}
