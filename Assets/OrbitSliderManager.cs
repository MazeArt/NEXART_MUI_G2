using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitSliderManager : MonoBehaviour
{

    [Range(-100f, 100f)]
    public float orbit_fastfwd = 1f;
    public float earth_orbitPeriod = 300f;
    public bool orbitActive = true;
    public float orbitPeriod_Ura = 50f;
    public float orbitPeriod_Jup = 11.86f;
    public float orbitPeriod_Sat = 29.46f;
    public float orbitPeriod_Mar = 1.88f;
    public float orbitPeriod_Mer = 0.5f;
    public float orbitPeriod_Ven = 0.8f;
    public float orbitPeriod_Nep = 90f;



}
