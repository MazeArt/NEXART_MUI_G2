using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class naveControl : MonoBehaviour
{
    private float rotation = 35;
    public GameObject meteorito;
    public Slider sliderRot;

    private void Start()
    {
        sliderRot.value = rotation;
    }
    private void Update()
    {
        transform.localEulerAngles = new Vector3(0, 0, Mathf.PingPong(sliderRot.value, 70) -35);
        
    }
}
