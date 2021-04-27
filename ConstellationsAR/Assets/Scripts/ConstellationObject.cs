using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstellationObject : MonoBehaviour
{
    public bool isVisible;
    public ConstellationDatabaseLoader loader;

    private MeshRenderer meshRenderer;
    private Color color;
    private Vector3 pos;
    private Vector3 targetPos;
    private Vector2 middlePos = new Vector3(Screen.width/2, Screen.height/2);

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        color = new Color(meshRenderer.material.color.r, meshRenderer.material.color.g, meshRenderer.material.color.b, 1);

        foreach (var c in loader.constellations)
        {
            if (c.name == name)
            {
                pos = c.position;
                break;
            }
        }
        
        targetPos = Camera.allCameras[0].WorldToScreenPoint(pos);
    }

    private bool IsVisible()
    {
        if (targetPos.x < 0f || targetPos.y < 0f || targetPos.z < 0f || targetPos.x > Camera.allCameras[0].pixelWidth || targetPos.y > Camera.allCameras[0].pixelHeight)
            return false;

        return true;
    }

    private void Update()
    {
        targetPos = Camera.allCameras[0].WorldToScreenPoint(pos);
        Vector2 tempPos = new Vector2(targetPos.x, targetPos.y);
        if (IsVisible())
        {
            float distance = Vector2.Distance(tempPos, middlePos);

            if (distance <= 600)
            {
                meshRenderer.material.color = color;
            }

            else if (distance <= 800)
            {
                meshRenderer.material.color = new Vector4(color.r, color.g, color.b, 0.7f);
            }

            else if (distance <= 1200)
            {
                meshRenderer.material.color = new Vector4(color.r, color.g, color.b, 0.4f);
            }

            else 
            {
                meshRenderer.material.color = new Vector4(color.r, color.g, color.b, 0f);
            }


            // print(string.Format("{0}:{1}", name, distance));
        }
    }
}
