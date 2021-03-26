using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWindow : MonoBehaviour
{
    private UIManager cachedUIManager;

    private void Awake()
    {
        //All UI will be added to Dictionary of UIManager.
        //You can access any UIWindow with UIManager Dictionary.

        cachedUIManager = UIManager.Instance;
        if (!cachedUIManager.uiWindowDict.ContainsKey(this.gameObject))
        {
            cachedUIManager.uiWindowDict.Add(this.gameObject, this);
        }
    }

    // If touch event is existed, implement event method on class which inherit this class. 
}
