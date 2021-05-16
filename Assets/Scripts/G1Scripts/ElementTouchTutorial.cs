using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementTouchTutorial : MonoBehaviour
{        
    public Canvas myCanvas;
    public TutorialTravel ttravel;
    private bool firstStep;
    public GameObject galaxyKey;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse is down");

            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {
                Debug.Log("Hit " + hitInfo.transform.gameObject.name);
                if (hitInfo.transform.gameObject.tag == "Galaxy")
                {
                    ttravel.tutorialPart = 3;
                }

                Debug.Log("Hit " + hitInfo.transform.gameObject.name);
                if (hitInfo.transform.gameObject)
                {
                    
                }
            }
            else
            {
                if (firstStep == false)
                {
                    ttravel.tutorialPart = 1;
                    firstStep = true;
                    galaxyKey.SetActive(true);
                }
            }
            Debug.Log("Mouse is down");
        }
    }
}
