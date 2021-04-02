using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickedButtonForDebug : MonoBehaviour
{
    public void OnClickedButton(GameObject go) 
    {
        print(go.name);
    }
}
