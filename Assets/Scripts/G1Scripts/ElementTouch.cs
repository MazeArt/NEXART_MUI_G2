using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementTouch : MonoBehaviour
{

    public Inventory inventory;
    public GameObject textInfo;
    public Canvas myCanvas;
    public ChangeLevel chlvl;
    private bool confirmObject;
    private string onObjectNameInfo;
    

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse is down");


            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

            if (hit)
            {
                // Agrega a inventario
                Debug.Log("Hit " + hitInfo.transform.gameObject.name);
                if (hitInfo.transform.gameObject.name != onObjectNameInfo)
                {
                    confirmObject = false;
                    return;                    
                }

                if (hitInfo.transform.gameObject.tag == "Element")
                {
                    inventory.TakeElement(hitInfo.transform.gameObject.name);
                    GameObject p = GameObject.Find(hitInfo.transform.gameObject.name);
                    p.GetComponent<SphereCollider>().enabled = false;
                    confirmObject = false;
                }

                Debug.Log("Hit " + hitInfo.transform.gameObject.name);
                if (hitInfo.transform.gameObject.tag == "wrongElement")
                {
                    Debug.Log("Not the Element");
                }   
                if (hitInfo.transform.gameObject.tag == "Galaxy")
                {
                    GameObject c = GameObject.Find(hitInfo.transform.gameObject.name);
                    c.GetComponent<GalaxyAdding>().GalaxySon.SetActive(true);
                    inventory.FinalCount++;
                    inventory.points += 10;
                    c.GetComponent<SphereCollider>().enabled = false;
                }               
            }
            else
            {
                Debug.Log("No hit");
            }
            Debug.Log("Mouse is down");
        }

        if (Input.GetMouseButton(0))
        {
            RaycastHit hitInfoOutSide = new RaycastHit();
            bool hitOutside = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfoOutSide);
            if (hitOutside && chlvl.changeLVL == false)
            {
                //muestra la informacion
                Debug.Log("Hit " + hitInfoOutSide.transform.gameObject.name);
                if (hitInfoOutSide.transform.gameObject)
                {
                    textInfo.SetActive(true);
                    inventory.ElementInfo(hitInfoOutSide.transform.gameObject.name);
                    Vector2 pos;
                    RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition, myCanvas.worldCamera, out pos);
                    textInfo.transform.position = myCanvas.transform.TransformPoint(pos);
                    confirmObject = true;
                    onObjectNameInfo = hitInfoOutSide.transform.gameObject.name;
                }
            }
        }
        else
        {
            textInfo.SetActive(false);
        }





    }
}
