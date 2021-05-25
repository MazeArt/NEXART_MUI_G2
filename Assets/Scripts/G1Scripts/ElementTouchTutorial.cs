using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElementTouchTutorial : MonoBehaviour
{        
    public Canvas myCanvas;
    public TutorialTravel ttravel;
    private bool firstStep;
    public GameObject tuto2;
    
    public GameObject naveCam;

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
                    SceneManager.LoadScene(1);
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
                    tuto2.SetActive(true);
                    ttravel.warp.GetComponent<Animator>().Play("Warpdrive__Sequence");
                    ttravel.starendtuto = true;
                    ttravel.sliderTuto.SetActive(false);
                    

                }
            }
            Debug.Log("Mouse is down");
        }
    }
}
