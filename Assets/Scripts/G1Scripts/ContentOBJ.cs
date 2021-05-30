using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentOBJ : MonoBehaviour
{
    public Vector3 maxLocalScale;
    
    public void NewScale(float newSize)
    {
        float minScaleX = float.MaxValue;
        float maxScaleX = float.MinValue;

        foreach (Transform child in transform)
        {
            float maxX  =  child.GetComponent<Renderer>().bounds.max.x;
            float minX  = child.GetComponent<Renderer>().bounds.min.x;

            if (maxX > maxScaleX)
            {
                maxScaleX = maxX;
            }

            if (minX < minScaleX)
            {
                minScaleX = minX;
            }
        }

        float size = maxScaleX - minScaleX;       

        Vector3 rescale = transform.localScale;

        rescale = newSize * rescale / size;
        

        transform.localScale = rescale;

    }

}