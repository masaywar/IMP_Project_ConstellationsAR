using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FromTelescopeToARMainScene : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Vector3 touchpos = Input.GetTouch(0).position;
            Ray ray = Camera.main.ScreenPointToRay(touchpos);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject.CompareTag("Telescope"))
                {
                    SceneManager.LoadScene("ARMainScene");
                }
            }
        }
    }
}
