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
    public TextMeshProUGUI SessionDetail;
    public TextMeshProUGUI StoryDetail;
    public Image ConstellationImage;

    
    private ConstellationJsonDataArray.Data[] JsonData;
    private string url;

    void Start()
    {
        JsonData = GamaManager.Instance.datas;
    }

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

        foreach (ConstellationJsonDataArray.Data data in JsonData)
        {
            if (data.name== buttonname)
            {   
                string path = "Pictures/" + data.name;
                SessionDetail.text = data.period;
                StoryDetail.text = data.story;
                ConstellationImage.sprite = Resources.Load<Sprite>(path) as Sprite;
            }
        }

    }
    private void OpenScreenShotCanvas()
    {
        this.gameObject.SetActive(false);
        ScreenShotCanvas.SetActive(true);
    }

    /*
    IEnumerator SetSprite()
    {
         using (WWW www = new WWW(url))
         {  
             yield return www;

             Texture2D tex = new Texture2D(5, 5, TextureFormat.DXT1, false);
             www.LoadImageIntoTexture(tex);
             ConstellationImage.sprite = Sprite.Create(tex, new Rect(0,0, tex.width, tex.height), Vector2.one * 0.5f);
         }
    }*/
}
