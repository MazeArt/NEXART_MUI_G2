using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class OrbitManager : MonoBehaviour
{
    // public PlanetManager planetManager;


    //  public enum dropoptions { Opt1, Opt2, Opt3 };
    //  public dropoptions option;
    public PlanetPropertiesDict planetPropertiesDict;

    public enum dropoptions { opt1,opt0, opt2 };
    [Header("Solar System Scale Options")]
    public dropoptions selectedOption;

    [HideInInspector]
    public string dropdOption;
    [HideInInspector]
    public string _prevOption;

    [Header("Oribtal Control")]
    [Range(-30f, 30f)]
    public float orbit_fastfwd = 1f;
    public float earthOrbitPeriodAbs = 300f;
    public bool orbitActive = true;

    public float bulletSpeed;
    public float bulletDestroySeconds;

    [Serializable]
    public class massVariableHolder
    {
        [Header("Mass of Planets (non-editable)")]
        public float massEarth;
        public float massSun;
        public float massVenus;
        public float massMars;
        public float massJupiter;
        public float massSaturn;
    }
    [Space(10)]
    public massVariableHolder massOfPlanets = new massVariableHolder();

    [Serializable]
    public class xAxisVariableHolder
     {
        [Header("Distance from the Sun (non-editable) ")]
        public float distEarth  ;
        public float distSun ;
        public float distVenus ;
        public float distMars ;
        public float distJupiter ;
        public float distSaturn;
     }
    [Space(10)]
    public xAxisVariableHolder distOfPlanets = new xAxisVariableHolder();
    
    [Serializable]
    public class SizeVariableHolder
    {
        [Header("Size of Planet Relative to Earth (non-editable) ")]
        public double sizeEarth;
        public double sizeSun;
        public double sizeVenus;
        public double sizeMars ;
        public double sizeJupiter;
        public double sizeSaturn ;
    }
    [Space(10)]
    public SizeVariableHolder sizeOfPlanets = new SizeVariableHolder();

    [Serializable]
    public class periodVariableHolder
    {
        [Header("Periods of Planets (non-editable)")]
        public float orbitPeriodMercury ;
        public float orbitPeriodVenus;
        public float orbitPeriodMars ;
        public float orbitPeriodJupipter;
        public float orbitPeriodSaturn ;

    }
    [Space(10)]
    public periodVariableHolder periodsOfPlanets = new periodVariableHolder();




    void Start()
    {
        
        dropdOption = selectedOption.ToString();
        _prevOption = dropdOption;
        getvalues();
        
    }   


    void Update()
    {
        dropdOption = selectedOption.ToString();
        if(_prevOption != dropdOption)
        {

            _prevOption = dropdOption;
            getvalues();

        }





    }

    void getvalues()
    {
        massOfPlanets.massEarth =   planetPropertiesDict.EarthOptions[dropdOption].planetMass;
        massOfPlanets.massSun =     planetPropertiesDict.SunOptions[dropdOption].planetMass;
        massOfPlanets.massMars =    planetPropertiesDict.MarsOptions[dropdOption].planetMass;
        massOfPlanets.massJupiter = planetPropertiesDict.JupiterOptions[dropdOption].planetMass;
        massOfPlanets.massSaturn =  planetPropertiesDict.SaturnOptions[dropdOption].planetMass;

        distOfPlanets.distEarth =   planetPropertiesDict.EarthOptions[dropdOption].planetxAxis / planetPropertiesDict.EarthOptions[dropdOption].planetxAxis; 
        distOfPlanets.distVenus =   planetPropertiesDict.VenusOptions[dropdOption].planetxAxis   / planetPropertiesDict.EarthOptions[dropdOption].planetxAxis;
        distOfPlanets.distMars =    planetPropertiesDict.MarsOptions[dropdOption].planetxAxis  / planetPropertiesDict.EarthOptions[dropdOption].planetxAxis;
        distOfPlanets.distJupiter = planetPropertiesDict.JupiterOptions[dropdOption].planetxAxis/planetPropertiesDict.EarthOptions[dropdOption].planetxAxis; 
        distOfPlanets.distSaturn =  planetPropertiesDict.SaturnOptions[dropdOption].planetxAxis/ planetPropertiesDict.EarthOptions[dropdOption].planetxAxis; 

        sizeOfPlanets.sizeEarth =   planetPropertiesDict.EarthOptions[dropdOption].planetScale / planetPropertiesDict.EarthOptions[dropdOption].planetScale;
        sizeOfPlanets.sizeSun =     planetPropertiesDict.SunOptions[dropdOption].planetScale / planetPropertiesDict.EarthOptions[dropdOption].planetScale;
        sizeOfPlanets.sizeMars =    planetPropertiesDict.MarsOptions[dropdOption].planetScale  / planetPropertiesDict.EarthOptions[dropdOption].planetScale;
        sizeOfPlanets.sizeVenus =   planetPropertiesDict.VenusOptions[dropdOption].planetScale/planetPropertiesDict.EarthOptions[dropdOption].planetScale;
        sizeOfPlanets.sizeJupiter = planetPropertiesDict.JupiterOptions[dropdOption].planetScale/ planetPropertiesDict.EarthOptions[dropdOption].planetScale;
        sizeOfPlanets.sizeSaturn =  planetPropertiesDict.SaturnOptions[dropdOption].planetScale/planetPropertiesDict.EarthOptions[dropdOption].planetScale;



        periodsOfPlanets.orbitPeriodVenus = planetPropertiesDict.VenusOptions[dropdOption].planetorbitPeriod;
        periodsOfPlanets.orbitPeriodMars = planetPropertiesDict.MarsOptions[dropdOption].planetorbitPeriod;
        periodsOfPlanets.orbitPeriodJupipter = planetPropertiesDict.JupiterOptions[dropdOption].planetorbitPeriod;
        periodsOfPlanets.orbitPeriodSaturn = planetPropertiesDict.SaturnOptions[dropdOption].planetorbitPeriod;

        bulletSpeed=planetPropertiesDict.bulletOptions[dropdOption].bulletSpeed;
        bulletDestroySeconds = planetPropertiesDict.bulletOptions[dropdOption].bulletDestroySeconds; 

}
}
