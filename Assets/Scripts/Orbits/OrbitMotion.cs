using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitMotion : MonoBehaviour
{
    public Transform orbitingObject;
    public Ellipse orbitPath;

    // Orbit Manager Variable
    public OrbitManager orbitManager;
    //Variables from Orbit Manager
      // [Range(1f, 100f)]
      // public float orbit_fastfwd = 1f;
      // public float earth_orbitPeriod = 300f;
      // public bool  orbitActive = true;
    
          [Range(0f, 1f)]
          public float orbitProgress ;
    


    //Planet Variables


    public float orbitOrigin;
    private float planet_orbitPeriod;
    private float orbitPeriod;




    // Start is called before the first frame update
    void Start()
    {
       
        if(orbitingObject == null)
            {
                orbitManager.orbitActive = false;
                    return;
            }
        // set orbitign object position
        SetOrbitingObjectPosition();
        StartCoroutine(AnimateOrbit());
        
        //start orbit animation
    }

    void SetOrbitingObjectPosition()
    {
        planet_orbitPeriod = Check_planet(orbitingObject.name, orbitManager.earthOrbitPeriodAbs);
        //set orbiting speed
        orbitPeriod = planet_orbitPeriod / (orbitManager.orbit_fastfwd * Mathf.Abs(orbitManager.orbit_fastfwd) );

        //read orbitProgress
        //orbitProgress = orbitProgress + orbit_fastfwd / 100;
        Vector2 orbitPos = orbitPath.Evaluate(orbitProgress + orbitOrigin);
        orbitingObject.localPosition = new Vector3(orbitPos.x, 0, orbitPos.y);
    }

        IEnumerator AnimateOrbit()
        {

        while (orbitManager.orbitActive)
        {
            if(orbitPeriod < 0.1f)
            {
                //orbitPeriod = 0.1f;
            }
            float orbitSpeed = 1f / orbitPeriod;
            orbitProgress += Time.deltaTime * orbitSpeed;
            orbitProgress %= 1f;
            SetOrbitingObjectPosition();
            yield return null;
        }
        }

    float Check_planet(string planet_name,float oribtPeriod_planet)
    {  

        switch (planet_name)
        {
            case "Mercury":
                oribtPeriod_planet = oribtPeriod_planet * orbitManager.orbitPeriodMercury;
                Debug.Log("This is " + planet_name + " , orbit period is: " + oribtPeriod_planet);
                break;

            case "Venus":
                oribtPeriod_planet = oribtPeriod_planet * orbitManager.orbitPeriodVenus;
                Debug.Log("This is " + planet_name + " , orbit period is: " + oribtPeriod_planet);
                break;

            case "Mars":
                oribtPeriod_planet = oribtPeriod_planet * orbitManager.orbitPeriodMars;
                Debug.Log("This is " + planet_name + " , orbit period is: " + oribtPeriod_planet);
                break;

            case "Jupiter":
                oribtPeriod_planet = oribtPeriod_planet * orbitManager.orbitPeriodJupipter;
                Debug.Log("This is "+ planet_name+" , orbit period is: " + oribtPeriod_planet);
                break;
            
            case "Saturn":
                oribtPeriod_planet = oribtPeriod_planet * orbitManager.orbitPeriodSaturn;
                Debug.Log("This is " + planet_name + " , orbit period is: " + oribtPeriod_planet);
                break;

        //   case "Uranus":
        //       oribtPeriod_planet = oribtPeriod_planet * orbitManager.orbitPeriod_Ura;
        //       Debug.Log("This is " + planet_name + " , orbit period is: " + oribtPeriod_planet);
        //       break;
        //      
        //
        //   case "Neptune":
        //       oribtPeriod_planet = oribtPeriod_planet * orbitManager.orbitPeriod_Nep;
        //       Debug.Log("This is " + planet_name + " , orbit period is: " + oribtPeriod_planet);
        //       break;
            
        }
        return oribtPeriod_planet;

    }
}
