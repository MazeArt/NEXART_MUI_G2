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
    public movimientoBotones movimiento;
    public GameObject dot;
    public bool picarteIntruccions;
    public GameObject BotonesUI;

    private void Awake()
    {
        picarteIntruccions = true;
    }

    void Update()
    {


        #region Anterior Metodo
        //if (Input.GetMouseButtonDown(0))
        //{   
        //    RaycastHit hitInfo = new RaycastHit();
        //    bool hit = Physics.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0)), out hitInfo);

        //    if (hit)
        //    {
        //        // Agrega a inventario
        //        Debug.Log("Hit " + hitInfo.transform.gameObject.name);
        //        if (hitInfo.transform.gameObject.name != onObjectNameInfo)
        //        {
        //            //confirmObject = false;
        //            //return;                    
        //        }

        //        //if (hitInfo.transform.gameObject.tag == "Element")
        //        //{
        //        //    inventory.TakeElement(hitInfo.transform.gameObject.name);
        //        //    GameObject p = GameObject.Find(hitInfo.transform.gameObject.name);
        //        //    p.GetComponent<SphereCollider>().enabled = false;
        //        //    confirmObject = false;
        //        //}

        //        //Debug.Log("Hit " + hitInfo.transform.gameObject.name);
        //        //if (hitInfo.transform.gameObject.tag == "wrongElement")
        //        //{
        //        //    Debug.Log("Not the Element");
        //        //}

        //        if (hitInfo.transform.gameObject.tag == "Galaxy")
        //        {
        //            GameObject c = GameObject.Find(hitInfo.transform.gameObject.name);
        //            c.GetComponent<GalaxyAdding>().GalaxySon.SetActive(true);
        //            inventory.FinalCount++;
        //            inventory.points += 10;
        //            c.GetComponent<SphereCollider>().enabled = false;
        //        }               
        //    }
        //    else
        //    {
        //        Debug.Log("No hit");
        //    }
        //    Debug.Log("Mouse is down");
        //}
        #endregion

        #region despliegue de info

        RaycastHit hitInfoOutSide = new RaycastHit();
            bool hitOutside = Physics.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0)), out hitInfoOutSide);
            if (hitOutside && chlvl.changeLVL == false)
            {
                //muestra la informacion
                Debug.Log("Hit " + hitInfoOutSide.transform.gameObject.name);
                if (hitInfoOutSide.transform.gameObject)
                {
                    textInfo.SetActive(true);
                    inventory.ElementInfo(hitInfoOutSide.transform.gameObject.name);
                    Vector2 pos;
                    RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, dot.transform.position, myCanvas.worldCamera, out pos);
                    textInfo.transform.position = myCanvas.transform.TransformPoint(pos); 
 
                     confirmObject = true;
                    onObjectNameInfo = hitInfoOutSide.transform.gameObject.name;

                }
            }

        else
        {
            textInfo.SetActive(false);
        }

        #endregion

        #region Movimiento Camara

        RaycastHit HitButtonInfo = new RaycastHit();
        bool HitBool = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out HitButtonInfo);
        if (Input.GetMouseButton(0) && !picarteIntruccions )
            {
            BotonesUI.SetActive(true);
                if (HitBool && chlvl.changeLVL == false)
                {
                if (HitButtonInfo.transform.gameObject.tag == "izquierda")
                {
                    movimiento.LeftButton();
                }
                if (HitButtonInfo.transform.gameObject.tag == "derecha")
                {
                    movimiento.RightButton();
                }
                if (HitButtonInfo.transform.gameObject.tag == "arriba")
                {
                    movimiento.UPButton();
                }
                if (HitButtonInfo.transform.gameObject.tag == "abajo")
                {
                    movimiento.DownButton();
                }
                if (HitButtonInfo.transform.gameObject.tag == "Selector")
                {
                    movimiento.Selector();
                    RecolectarFuncion();
                }
                if (HitButtonInfo.transform.gameObject.tag == "Forward")
                {
                    movimiento.Forward();
                }
                if (HitButtonInfo.transform.gameObject.tag == "Backward")
                {
                    movimiento.Backward();
                }
            }
        }
        #endregion
    }

    public void RecolectarFuncion()
    {
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0)), out hitInfo);

        if (hit)
        {

            #region uslessCode
            // Agrega a inventario
            Debug.Log("Hit " + hitInfo.transform.gameObject.name);
            if (hitInfo.transform.gameObject.name != onObjectNameInfo)
            {
                //confirmObject = false;
                //return;                    
            }

            //if (hitInfo.transform.gameObject.tag == "Element")
            //{
            //    inventory.TakeElement(hitInfo.transform.gameObject.name);
            //    GameObject p = GameObject.Find(hitInfo.transform.gameObject.name);
            //    p.GetComponent<SphereCollider>().enabled = false;
            //    confirmObject = false;
            //}

            //Debug.Log("Hit " + hitInfo.transform.gameObject.name);
            //if (hitInfo.transform.gameObject.tag == "wrongElement")
            //{
            //    Debug.Log("Not the Element");
            //}

            #endregion

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
        
    }
}

