using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class G1NaveRotation : MonoBehaviour
{
    private float rotation = 90;
    public Slider sliderRot;
      private void Start()
    {
        sliderRot.value = rotation;
        
        
    }
    private void Update()
    {
        transform.localEulerAngles = new Vector3(0, Mathf.PingPong(sliderRot.value, 180) - 90, 0);

    }
}
