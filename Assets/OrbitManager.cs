using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitManager : MonoBehaviour
{

    [Range(-30f, 30f)]
    public float orbit_fastfwd = 1f;
    public float earthOrbitPeriodAbs = 300f;
    public bool orbitActive = true;

    public float orbitPeriodMercury = 0.5f;
    public float orbitPeriodVenus = 0.8f;
    public float orbitPeriodMars = 1.88f;
    public float orbitPeriodJupipter = 11.86f;
    public float orbitPeriodSaturn = 29.46f;

    public float massVenus = 100f;
    public float massEarth = 160f;
    public float massMars = 160f;
    public float massJupiter = 5000f;
    public float massSaturn = 8000f;

    //public float orbitPeriod_Nep = 90f;
    //public float orbitPeriod_Ura = 50f;
}
