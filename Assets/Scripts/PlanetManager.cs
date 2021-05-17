using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    public enum dropoptions { opt1, opt2 };
    public dropoptions selectedOption;

    public GameObject Earth;
    public GameObject Venus;
    public GameObject Mars;
    public GameObject Jupiter;
    public GameObject Saturn;
    public GameObject Sun;

    public PlanetPropertiesDict planetDictionary;
    public OrbitManager orbitManager;
    public string option;
    private string _prevValueOfOption;
    
    
    //to move planets

    public Dictionary<GameObject, PlanetProperties> planetObjDict = new Dictionary<GameObject, PlanetProperties>();

    void Start()
    {

        option = orbitManager.dropdOption;
        //option = selectedOption.ToString();
        _prevValueOfOption = option;

        //build planet dictionary:
        buildPlanetDictionary(option);


        updateAllPlanets();

    }

     void Update()
    {
        option = orbitManager.dropdOption;
       
        if(_prevValueOfOption != option)
        {
            _prevValueOfOption = option;

            buildPlanetDictionary(option);

            // FOR EACH  planet in planetList; 
            foreach (var planet in planetObjDict.Keys)
            {
                float xtarget;
                float movingx;

                
                if (planet != Sun)
                {
                    //AXIS change smooth:
                    xtarget = planetObjDict[planet].planetxAxis;
                    movingx = planet.GetComponent<OrbitMotion>().orbitPath.xAxis;
                    StartCoroutine(movePlanet(planet, movingx, xtarget,3,"xAxis"));
                }

                //SCALE change smooth:
                xtarget = planetObjDict[planet].planetScale;
                movingx = planet.GetComponent<Transform>().localScale.x;
                StartCoroutine(movePlanet(planet, movingx, xtarget, 3,"Scale"));

            }
                //Move Main Camera
                StartCoroutine(moveCamera());

        }
    }

    public void changePlanetProperties(GameObject targetPlanet, Dictionary<string, PlanetProperties> planetOption, string opt)
   {
        if (targetPlanet != Sun)
        {
            targetPlanet.GetComponent<Rigidbody>().mass = planetOption[opt].planetMass;
            targetPlanet.GetComponent<OrbitMotion>().orbitPath.xAxis = planetOption[opt].planetxAxis;

            float scaleValue = planetOption[opt].planetScale;
            targetPlanet.GetComponent<Transform>().localScale = new Vector3(scaleValue, scaleValue, scaleValue);

            targetPlanet.GetComponent<OrbitMotion>().OrbitPeriodRelativeToEarth = planetOption[opt].planetorbitPeriod;
        }else
        {
            //else Sun -> only mass and scale needs to be changed
            targetPlanet.GetComponent<Rigidbody>().mass = planetOption[opt].planetMass;
            float scaleValue = planetOption[opt].planetScale;
            targetPlanet.GetComponent<Transform>().localScale = new Vector3(scaleValue, scaleValue, scaleValue);
        }
        

    }

    void updateAllPlanets()
    {
        changePlanetProperties(Earth, planetDictionary.EarthOptions, option);
        //changePlanetProperties(Mercury, planetDictionary.MercuryOptions, "opt1");
        changePlanetProperties(Venus, planetDictionary.VenusOptions, option);
        changePlanetProperties(Mars, planetDictionary.MarsOptions, option);
        changePlanetProperties(Jupiter, planetDictionary.JupiterOptions, option);
        changePlanetProperties(Saturn, planetDictionary.SaturnOptions, option);

        changePlanetProperties(Sun, planetDictionary.SunOptions, option);
        
    }


    void buildPlanetDictionary(string option)
    {
        Debug.Log("Building Planets  Properties Dictionaries at option: " + option);
        planetObjDict[Earth] = planetDictionary.EarthOptions[option];
        planetObjDict[Mars] = planetDictionary.MarsOptions[option];
        planetObjDict[Venus] = planetDictionary.VenusOptions[option];
        planetObjDict[Jupiter] = planetDictionary.JupiterOptions[option];
        planetObjDict[Saturn] = planetDictionary.SaturnOptions[option];
        planetObjDict[Sun] = planetDictionary.SunOptions[option];
    }

    IEnumerator movePlanet(GameObject planet, float currentValue,float targetValue, int seconds, string param_to_change)
    {
        float delta = (targetValue - currentValue);
        float speed = Mathf.Abs(delta) / seconds;
        int direction = 1;
        float valueChange;
        Debug.LogFormat("moving from current {0} to target {1} at speed {2}",currentValue, targetValue,speed);

        if (delta < 1) //if delta is negative, invert values
        {
            targetValue = -targetValue;
            currentValue = -currentValue;
            direction = -1;
            
        }

        while (currentValue < targetValue)
        {
            Debug.LogFormat("evaluating current {0} vs target {1}::  ", currentValue, targetValue);

            
            float timeElapsed = 0f;
            float startValue = currentValue;

            while (timeElapsed < seconds)
            {
             
                float t = timeElapsed / seconds;
                //t = t * t * (3f - 2f * t);

                currentValue = Mathf.Lerp(startValue, targetValue, Mathf.SmoothStep(0.0f, 1.0f, t));
           
                //Debug.LogFormat("increasing LERPING now:: {0}  {1} seconds" ,currentValue, timeElapsed);

                valueChange = currentValue * direction;

                //planet.GetComponent<OrbitMotion>().orbitPath.xAxis = valueChange;
                ChangeComponent(param_to_change, valueChange);

                timeElapsed = 0.1f + timeElapsed; //Time.deltaTime;
                //Debug.LogFormat("increasing time {0}  {1} seconds", timeElapsed, Time.deltaTime );
                yield return null;
            }
            currentValue = targetValue;

        }

        void ChangeComponent(string param_to_change, float valueChange)
        {
            switch (param_to_change)
            {
                case "xAxis":
                    planet.GetComponent<OrbitMotion>().orbitPath.xAxis = valueChange;
                    break;

                case "Scale":
                    Debug.Log("Changing scale to" + targetValue);
                    planet.GetComponent<Transform>().localScale = new Vector3(valueChange, valueChange, valueChange);
                    break;
            }


        }
    }

    IEnumerator moveCamera()
    {
        float currentCameraPos=GameObject.Find("Main Camera").GetComponent<Transform>().position.x;
        float newCameraPos = -200f + Saturn.GetComponent<OrbitMotion>().orbitPath.xAxis;

        Vector3 tP = GameObject.Find("Main Camera").transform.position;
        tP.x = newCameraPos;
        Debug.Log("Moving Camera to " + newCameraPos);

        yield return null; 
    }
}


