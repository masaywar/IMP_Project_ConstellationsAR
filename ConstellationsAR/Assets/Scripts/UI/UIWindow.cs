using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWindow : MonoBehaviour
{
    // Start is called before the first frame update
    private UIManager cachedUIManager;

    private void Awake()
    {
        cachedUIManager = UIManager.Instance;
        if (!cachedUIManager.uiWindowDict.ContainsKey(this.gameObject))
        {
            cachedUIManager.uiWindowDict.Add(this.gameObject, this);
        }
    }
}
