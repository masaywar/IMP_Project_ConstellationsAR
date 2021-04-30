using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;

public class PlaneIndicator : MonoBehaviour
{

    private ARRaycastManager rayManger;
    private GameObject indicator;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    public GameObject PrefabToSpawn;
    private GameObject spawned;

    // Start is called before the first frame update
    void Start()
    {
        rayManger = FindObjectOfType<ARRaycastManager>();
        indicator = transform.GetChild(0).gameObject;
        indicator.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        rayManger.Raycast(new Vector2(Screen.width/2, Screen.height/2), hits, TrackableType.PlaneWithinPolygon); // Set indicator in middle of screen
        
        // hit something
        if(hits.Count >0)
        {
            if(!indicator.activeInHierarchy)
            {
                indicator.SetActive(true);
            }

            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;
            indicator.transform.Rotate(0, 45 *Time.deltaTime,0, Space.World);
        }
        else 
        {
            indicator.SetActive(false);
        }

        if(GetTouchPosition(out Vector2 touchPosition))
        {
            if(spawned == null)
            {
                spawned = Instantiate(PrefabToSpawn, transform.position, transform.rotation); 
            }
            else
            {
                spawned.transform.position = hits[0].pose.position;
            }
        }
    }

    bool GetTouchPosition(out Vector2 touchPosition)
    {
        if(Input.touchCount >0)
        {
            Vector3 touchpos = Input.GetTouch(0).position;
            Ray ray = Camera.main.ScreenPointToRay(touchpos);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject.CompareTag("Telescope"))
                {
                    SceneManager.LoadScene("ArMainScene");
                }
            }
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }
}
