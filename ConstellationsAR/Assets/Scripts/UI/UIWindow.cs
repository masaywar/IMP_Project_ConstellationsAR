using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWindow : MonoBehaviour
{
    public bool IsOpened() 
    {
        if (gameObject.activeSelf)
        {
            return true;
        }

        return false;
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    { 
        gameObject.SetActive(false);
    }
    // If touch event is existed, implement event method on class which inherit this class. 
}
