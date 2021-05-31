using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balanza : MonoBehaviour
{
    ManagerG6 manager;
    string IAm;
    // Start is called before the first frame update
    void Start()
    {
        IAm = gameObject.name;
        manager = FindObjectOfType<ManagerG6>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {

        var massC1 = collision.gameObject.GetComponent<ObjToCompare>().massCam1Space;
        var sizeC1 = collision.gameObject.GetComponent<ObjToCompare>().sizeCam1Space;
        var massC2 = collision.gameObject.GetComponent<ObjToCompare>().massCam2Earth;
        var sizeC2 = collision.gameObject.GetComponent<ObjToCompare>().sizeCam2Earth;
        switch (IAm)
        {
            case "BalanzaR":
                manager.BalanzaCanvasUpdate(massC1, sizeC1, massC2, sizeC2, 0);
                break;
            case "BalanzaL":
                manager.BalanzaCanvasUpdate(massC1, sizeC1, massC2, sizeC2, 1);
                break;
            default:
                break;

        }
    }
    //private void OnCollisionExit(Collision collision)
    //{
    //    switch (IAm)
    //    {
    //        case "BalanzaDer":
    //            manager.panelCam1R.SetActive(false);
    //            manager.panelCam2R.SetActive(false);
    //            break;
    //        case "BalanzaIzq":
    //            manager.panelCam1L.SetActive(false);
    //            manager.panelCam2L.SetActive(false);
    //            break;
    //        default:
    //            break;
    //    }
    //}
}
