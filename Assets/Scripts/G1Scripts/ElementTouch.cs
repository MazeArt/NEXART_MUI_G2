using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementTouch : MonoBehaviour
{

    public Inventory inventory;
    public GameObject textInfo;
    public Canvas myCanvas;
    

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
                if (hitInfo.transform.gameObject.tag == "Element")
                {
                    inventory.TakeElement(hitInfo.transform.gameObject.name);
                    GameObject p = GameObject.Find(hitInfo.transform.gameObject.name);
                    p.GetComponent<SphereCollider>().enabled = false;
                }

                Debug.Log("Hit " + hitInfo.transform.gameObject.name);
                if (hitInfo.transform.gameObject.tag == "wrongElement")
                {
                    Debug.Log("Not the Element");
                }               
            }
            else
            {
                Debug.Log("No hit");
            }
            Debug.Log("Mouse is down");
        }

        RaycastHit hitInfoOutSide = new RaycastHit();
        bool hitOutside = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfoOutSide);
        if (hitOutside)
        {
            Debug.Log("Hit " + hitInfoOutSide.transform.gameObject.name);
            if (hitInfoOutSide.transform.gameObject.tag == "Element")
            {
                textInfo.SetActive(true);
                inventory.ElementInfo(hitInfoOutSide.transform.gameObject.name);
                Vector2 pos;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition, myCanvas.worldCamera, out pos);
                textInfo.transform.position = myCanvas.transform.TransformPoint(pos);
            }           
        }
        else
        {
            textInfo.SetActive(false);
        }





    }
}
