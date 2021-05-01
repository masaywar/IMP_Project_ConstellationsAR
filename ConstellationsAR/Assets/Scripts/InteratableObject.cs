using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class InteratableObject : MonoBehaviour
{
    private ARSessionOrigin arsessionOrigin;

    public Canvas annotationCanvas;

    private void Start()
    {
        annotationCanvas.renderMode = RenderMode.WorldSpace;
        annotationCanvas.worldCamera = Camera.main;

        arsessionOrigin = FindObjectOfType<ARSessionOrigin>();
        transform.SetParent(arsessionOrigin.trackablesParent);

        print(annotationCanvas.worldCamera);
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector3 touchPos = touch.position;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(touchPos), out var hit))
            {
                OnClick("OnClick"+hit.collider.name);
            }
        }
    }

    private void OnClick(string methodName)
    {
        Invoke(methodName, 0);
    }

    private void OnClickRespawn()
    {
        gameObject.SetActive(false);
        Invoke("InvokePlaneDetect", 0.3f);
    }

    private void InvokePlaneDetect()
    {
        FindObjectOfType<PlaneIndicator>().EnablePlaneDetection();
    }

    private void OnClickStart()
    {
        GameManager.Instance.loadingState = GameManager.LoadingState.load;
    }
}
