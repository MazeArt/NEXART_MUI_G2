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

    public enum dropoptions { opt1, opt2 };
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
        public double sizeEarth = 1f;
        public double sizeSun = 100f;
        public double sizeVenus = 1f;
        public double sizeMars = 0.4f;
        public double sizeJupiter = 10f;
        public double sizeSaturn = 10f;
    }
    [Space(10)]
    public SizeVariableHolder sizeOfPlanets = new SizeVariableHolder();
                
    [Header("Periods of Planets (non-editable)")]
    public float orbitPeriodMercury ;
    public float orbitPeriodVenus;
    public float orbitPeriodMars ;
    public float orbitPeriodJupipter ;
    public float orbitPeriodSaturn ;



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
            getvalues();
            _prevOption = dropdOption;

        }





    }

    void getvalues()
    {
        orbitPeriodVenus = GameObject.Find("Venus").GetComponent<OrbitMotion>().OrbitPeriodRelativeToEarth;
        orbitPeriodMars = GameObject.Find("Mars").GetComponent<OrbitMotion>().OrbitPeriodRelativeToEarth;
        orbitPeriodJupipter = GameObject.Find("Jupiter").GetComponent<OrbitMotion>().OrbitPeriodRelativeToEarth;
        orbitPeriodSaturn = GameObject.Find("Saturn").GetComponent<OrbitMotion>().OrbitPeriodRelativeToEarth;


        massOfPlanets.massSun = GameObject.Find("Sun").GetComponent<Rigidbody>().mass;
        massOfPlanets.massEarth = GameObject.Find("Earth").GetComponent<Rigidbody>().mass;
        massOfPlanets.massMars = GameObject.Find("Mars").GetComponent<Rigidbody>().mass;
        massOfPlanets.massJupiter = GameObject.Find("Jupiter").GetComponent<Rigidbody>().mass;
        massOfPlanets.massSaturn = GameObject.Find("Saturn").GetComponent<Rigidbody>().mass;

        distOfPlanets.distEarth = GameObject.Find("Earth").GetComponent<OrbitMotion>().orbitPath.xAxis / GameObject.Find("Earth").GetComponent<OrbitMotion>().orbitPath.xAxis;
        distOfPlanets.distVenus = GameObject.Find("Venus").GetComponent<OrbitMotion>().orbitPath.xAxis / GameObject.Find("Earth").GetComponent<OrbitMotion>().orbitPath.xAxis; ;
        distOfPlanets.distMars = GameObject.Find("Mars").GetComponent<OrbitMotion>().orbitPath.xAxis / GameObject.Find("Earth").GetComponent<OrbitMotion>().orbitPath.xAxis; ;
        distOfPlanets.distJupiter = GameObject.Find("Jupiter").GetComponent<OrbitMotion>().orbitPath.xAxis / GameObject.Find("Earth").GetComponent<OrbitMotion>().orbitPath.xAxis; ;
        distOfPlanets.distSaturn = GameObject.Find("Saturn").GetComponent<OrbitMotion>().orbitPath.xAxis / GameObject.Find("Earth").GetComponent<OrbitMotion>().orbitPath.xAxis; ;

        sizeOfPlanets.sizeSun = GameObject.Find("Sun").GetComponent<Transform>().localScale.x / GameObject.Find("Earth").GetComponent<Transform>().localScale.x;
        sizeOfPlanets.sizeEarth = GameObject.Find("Earth").GetComponent<Transform>().localScale.x / GameObject.Find("Earth").GetComponent<Transform>().localScale.x;
        sizeOfPlanets.sizeMars = GameObject.Find("Mars").GetComponent<Transform>().localScale.x / GameObject.Find("Earth").GetComponent<Transform>().localScale.x;
        sizeOfPlanets.sizeVenus = GameObject.Find("Venus").GetComponent<Transform>().localScale.x / GameObject.Find("Earth").GetComponent<Transform>().localScale.x;
        sizeOfPlanets.sizeJupiter = GameObject.Find("Jupiter").GetComponent<Transform>().localScale.x / GameObject.Find("Earth").GetComponent<Transform>().localScale.x;
        sizeOfPlanets.sizeSaturn = GameObject.Find("Saturn").GetComponent<Transform>().localScale.x / GameObject.Find("Earth").GetComponent<Transform>().localScale.x;

    }
}
