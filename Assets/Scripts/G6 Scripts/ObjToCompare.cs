using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjToCompare : MonoBehaviour
{
    public float massCam1Space;
    public float volCam1Space;
    public string massCam1SpaceString;
    public float massCam2Earth;
    public float volCam2Earth;
    private Vector3 myPosition;

    private void Start()
    {
        myPosition = gameObject.transform.position;
    }
    public void ResetMyPosition()
    {
        gameObject.transform.position = myPosition;
    }
}
