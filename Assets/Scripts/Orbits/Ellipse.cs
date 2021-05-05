using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ellipse 
{
    public float xAxis;
    public float eccentricty;

    public Ellipse (float xAxis,float eccentricty)
    {
        this.xAxis = xAxis;
        this.eccentricty = eccentricty; //this should be yAxis 
    }

    public Vector2 Evaluate(float t)
    {
        float angle = Mathf.Deg2Rad * 360f * t;
        float x = Mathf.Sin(angle) * xAxis;
        float y = Mathf.Cos(angle) * xAxis * eccentricty;
        return new Vector2(x, y);
        
    }
}
