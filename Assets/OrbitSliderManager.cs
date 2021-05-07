using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitSliderManager : MonoBehaviour
{

    [Range(-100f, 100f)]
    public float orbit_fastfwd = 1f;
    public float earth_orbitPeriod = 300f;
    public bool orbitActive = true;
   

}
