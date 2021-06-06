using UnityEngine;
using UnityEngine.UI;

public class ObjBaseOrden : MonoBehaviour
{
    public float massCam1;
    public float volumeCam1;
    public string massCam1String;
    public float massCam2;
    public float volumeCam2;
    private Text[] dataText;

    private void Start()
    {
        dataText = gameObject.GetComponentsInChildren<Text>();
        massCam1 = 0;
        massCam2 = 0;
        volumeCam1 = 0;
        volumeCam2 = 0;
        massCam1String = "0";
        UpdateOnScreenValue();
    }
    private void OnCollisionEnter(Collision collision)
    {
        massCam1 = collision.gameObject.GetComponent<ObjToCompare>().massCam1Space;
        volumeCam1 = collision.gameObject.GetComponent<ObjToCompare>().volCam1Space;
        massCam1String = collision.gameObject.GetComponent<ObjToCompare>().massCam1SpaceString;
        massCam2 = collision.gameObject.GetComponent<ObjToCompare>().massCam2Earth;
        volumeCam2 = collision.gameObject.GetComponent<ObjToCompare>().volCam2Earth;
        UpdateOnScreenValue();
    }
    private void OnCollisionExit(Collision collision)
    {   
        massCam1 = 0;
        massCam2 = 0;
        volumeCam1 = 0;
        volumeCam2 = 0;
        massCam1String = "0";
        UpdateOnScreenValue();
    }
    private void UpdateOnScreenValue()
    {
        dataText[0].text = "Masa: " + massCam1String + "\nVolumen: " + volumeCam1.ToString();
        dataText[1].text = "Masa: " + massCam2.ToString() + "g" + "\nVolumen: " + volumeCam2.ToString() + "cm3";
    }
}
