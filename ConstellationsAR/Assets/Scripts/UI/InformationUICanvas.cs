using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using DG.Tweening;

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
        bttn4CloseInfo.onClick.AddListener(CloseInformationMotion);
    }

   
    public void OnEnable()
    {
        //Action when this object activieSelf == true
        //InformationPanel open...  

        // Scale Up Motion
        // InformationPanel.transform.DOScale(Vector3.one * 0.8f, 0.5f).SetEase(Ease.OutQuad);
        
        InformationPanel.transform.localPosition = new Vector3(0,-1000,0);
        InformationPanel.transform.DOLocalMoveY(0 , 0.4f).SetEase(Ease.OutQuad);

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

    public void CloseInformationMotion()
    {   
        // Scale Up Motion
        // InformationPanel.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.OutQuad).OnComplete(CloseInformationCanvas);
        InformationPanel.transform.DOLocalMoveY(-1000 , 0.4f).SetEase(Ease.OutQuad).OnComplete(CloseInformationCanvas);
    }
    public void CloseInformationCanvas()
    {
        this.gameObject.SetActive(false);
        HomeCanvas.SetActive(true);
    }
    
}
