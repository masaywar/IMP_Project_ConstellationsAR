using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    private Dictionary<GameObject, UIWindow> _uiWindowDict;
    public Dictionary<GameObject, UIWindow> uiWindowDict 
    {
        get 
        {
            if (_uiWindowDict == null)
                _uiWindowDict = new Dictionary<GameObject, UIWindow>();

            return _uiWindowDict;
        }
        
    }
    
    private void Awake()
    {
        
    }
}
