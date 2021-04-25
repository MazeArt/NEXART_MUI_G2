using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthDestroy : MonoBehaviour
{
    public int points;   

    public void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);        
    }
}
