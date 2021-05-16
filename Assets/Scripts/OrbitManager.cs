using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class OrbitManager : MonoBehaviour
{
    public PlanetManager planet;
  //  public enum dropoptions { Opt1, Opt2, Opt3 };
  //  public dropoptions option;

    [Header("Oribtal Control")]
    [Range(-30f, 30f)]
    public float orbit_fastfwd = 1f;
    public float earthOrbitPeriodAbs = 300f;
    public bool orbitActive = true;

    [Header("Periods of Planets")]
    public float orbitPeriodMercury = 0.5f;
    public float orbitPeriodVenus = 0.8f;
    public float orbitPeriodMars = 1.88f;
    public float orbitPeriodJupipter = 11.86f;
    public float orbitPeriodSaturn = 29.46f;

    [Header("Mass of Planets")]
    //public v1PlanetMass.massVenus;
    public float massEarth = 200f;
    public float massMars = 160f;
    public float massJupiter = 5000f;
    public float massSaturn = 8000f;

     [Serializable]
     public class VariableHolder
     {
        [Header("Size of Planet Relative to Earth ")]
        public float sizeEarth = 1f;
        public float sizeSun = 100f;
        public float sizeVenus = 1f;
        public float sizeMars = 0.4f;
        public float sizeJupiter = 10f;
        public float sizeSaturn = 10f;

     }
     public VariableHolder siezeOfPlanets = new VariableHolder();

    //public float orbitPeriod_Nep = 90f;
    //public float orbitPeriod_Ura = 50f;



    void Start()
    {
   //     if (option.ToString() == "Opt2")
   //     {
  //      
  //      Debug.Log("Dropdown Selection is " + option);
  //      Debug.Log("Opt2 has been selected in Dropwdown " );
 //       }


    }


}
