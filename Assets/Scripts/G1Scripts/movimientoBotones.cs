using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movimientoBotones : MonoBehaviour
{
    public float speed;
    public GameObject left;
    public GameObject right;
    public GameObject up;
    public GameObject down;
    public GameObject forward;
    public GameObject backward;
    public GameObject selector;
    public bool clickState;
    public float limitadorUp;
    public float limitadorDown;
    public Slider slider;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            clickState = true;
        }
        else 
        { 
            clickState = false;
            right.GetComponent<Renderer>().material.color = Color.white;
            left.GetComponent<Renderer>().material.color = Color.white;
            up.GetComponent<Renderer>().material.color = Color.white;
            down.GetComponent<Renderer>().material.color = Color.white;
            selector.GetComponent<Renderer>().material.color = Color.white;
            forward.GetComponent<Renderer>().material.color = Color.white;
            backward.GetComponent<Renderer>().material.color = Color.white;
            
        }        
    }

    public void LeftButton()
    {
        transform.Rotate(0, -speed, 0);
        if (clickState)
        {
            left.GetComponent<Renderer>().material.color = Color.black;
        }        
    }
    public void RightButton()
    {
        transform.Rotate(0, speed, 0);
        if (clickState)
        {
            right.GetComponent<Renderer>().material.color = Color.black;
        }
    }
    public void UPButton()
    {
        
            
            if (clickState && slider.value < 40)
            {
            transform.Rotate(speed, 0, 0);
            up.GetComponent<Renderer>().material.color = Color.black;
                slider.value++;
            }
        
    }
    public void DownButton()
    {
       
            
            if (clickState && slider.value > -40)
            {
                down.GetComponent<Renderer>().material.color = Color.black;
                transform.Rotate(-speed, 0, 0);
                slider.value--;

            }
        }

    public void Selector()
    {
        if (clickState)
        {
            selector.GetComponent<Renderer>().material.color = Color.black;
        }
    }
    public void Forward()
    {
        if (clickState)
        {
            forward.GetComponent<Renderer>().material.color = Color.black;
        }
    }
    public void Backward()
    {
        if (clickState)
        {
            backward.GetComponent<Renderer>().material.color = Color.black;
        }
    }
    }

       
    

   

