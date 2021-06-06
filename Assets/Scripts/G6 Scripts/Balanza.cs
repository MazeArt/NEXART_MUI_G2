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

        var massC1 = collision.gameObject.GetComponent<ObjToCompare>().massCam1Space.ToString();
        var sizeC1 = collision.gameObject.GetComponent<ObjToCompare>().volCam1Space.ToString();
        var massC2 = collision.gameObject.GetComponent<ObjToCompare>().massCam2Earth.ToString();
        var sizeC2 = collision.gameObject.GetComponent<ObjToCompare>().volCam2Earth.ToString();
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
    void OnTriggerExit(Collider other)
    {
        switch (IAm)
        {
            case "BalanzaR":
                manager.panelCam1R.SetActive(false);
                manager.panelCam2R.SetActive(false);
                break;
            case "BalanzaL":
                manager.panelCam1L.SetActive(false);
                manager.panelCam2L.SetActive(false);
                break;
            default:
                break;
        }
    }
}
