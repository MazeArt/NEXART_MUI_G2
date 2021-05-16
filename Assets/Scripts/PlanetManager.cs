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
    public string option;
    private string _prevValueOfOption;
    
    
    //to move planets 
    private Vector3 target;
    private float speed = 100;

    void Start()
    {

        // string option = "opt2";

        //  earthOptions = new PlanetOptions("opt1", new PlanetProperties(111, 222, 1, 1));
        //   Debug.Log("test class opt1 earth  " + this.JupiterOptions["opt1"].planetMass);
        _prevValueOfOption = option;
        option = selectedOption.ToString();
        Debug.Log("OPTION ENUM ::  " + option);

        updateAllPlanets();

    }

     void Update()
    {
        option = selectedOption.ToString();
       
        if(_prevValueOfOption != option)
        {
            _prevValueOfOption = option;

            //float currentz=Jupiter.GetComponent<Transform>().position.z;
            
            float xtarget = planetDictionary.JupiterOptions[option].planetxAxis;
            float movingx = Jupiter.GetComponent<OrbitMotion>().orbitPath.xAxis;
            while (movingx < xtarget)
            {
                Debug.Log("moving , target ::  " + movingx + " " + xtarget);

                //Jupiter.GetComponent<OrbitMotion>().orbitPath.xAxis += 1; 
            }
            
            //Jupiter.GetComponent<OrbitMotion>().orbitPath.xAxis = ;
            
            
            //target = new Vector3(-1f * planetDictionary.JupiterOptions[option].planetxAxis, 0, currentz);
            //transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);

           // updateAllPlanets();

        }
    }

    public void changePlanetProperties(GameObject targetPlanet, Dictionary<string, PlanetProperties> planetOption, string opt)
   {
       targetPlanet.GetComponent<Rigidbody>().mass = planetOption[opt].planetMass;
       targetPlanet.GetComponent<OrbitMotion>().orbitPath.xAxis = planetOption[opt].planetxAxis;
        
       float scaleValue = planetOption[opt].planetScale;
       targetPlanet.GetComponent<Transform>().localScale = new Vector3(scaleValue, scaleValue, scaleValue);
       
       targetPlanet.GetComponent<OrbitMotion>().OrbitPeriodRelativeToEarth = planetOption[opt].planetorbitPeriod;

        Debug.Log(targetPlanet + " SHOW MEE  " + planetOption[opt].planetorbitPeriod);


    }

    void updateAllPlanets()
    {
        changePlanetProperties(Earth, planetDictionary.EarthOptions, option);
        //changePlanetProperties(Mercury, planetDictionary.MercuryOptions, "opt1");
        changePlanetProperties(Venus, planetDictionary.VenusOptions, option);
        changePlanetProperties(Mars, planetDictionary.MarsOptions, option);
        changePlanetProperties(Jupiter, planetDictionary.JupiterOptions, option);
        changePlanetProperties(Saturn, planetDictionary.SaturnOptions, option);
        //Debug.Log(" hasupdateall planets SUCESSSSSS: ");
    }
}


