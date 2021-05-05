using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitMotion : MonoBehaviour
{
    public Transform orbitingObject;
    public Ellipse orbitPath;

    [Range(1f, 100f)]
    public float orbit_fastfwd = 1f;
    public float orbitOrigin;
    [Range(0f, 1f)]
    public float orbitProgress ;
    public float earth_orbitPeriod = 300f;
    public bool orbitActive = true;
    private float orbitPeriod;
    private float planet_orbitPeriod;




    // Start is called before the first frame update
    void Start()
    {
        planet_orbitPeriod = Check_planet(orbitingObject.name, earth_orbitPeriod);
       
        if(orbitingObject == null)
            {
                orbitActive = false;
                    return;
            }
        // set orbitign object position
        SetOrbitingObjectPosition();
        StartCoroutine(AnimateOrbit());
        
        //start orbit animation
    }

    void SetOrbitingObjectPosition()
    {
        //set orbiting speed
        orbitPeriod = planet_orbitPeriod / (orbit_fastfwd * orbit_fastfwd);

        //read orbitProgress
        //orbitProgress = orbitProgress + orbit_fastfwd / 100;
        Vector2 orbitPos = orbitPath.Evaluate(orbitProgress + orbitOrigin);
        orbitingObject.localPosition = new Vector3(orbitPos.x, 0, orbitPos.y);
    }

        IEnumerator AnimateOrbit()
        {

        while (orbitActive)
        {
            if(orbitPeriod < 0.1f)
            {
                orbitPeriod = 0.1f;
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
            case "Jupiter":
                oribtPeriod_planet = oribtPeriod_planet * 11.86f;
                Debug.Log("This is "+ planet_name+" , orbit period is: " + oribtPeriod_planet);
                break;
            
            case "Saturn":
                oribtPeriod_planet = oribtPeriod_planet * 29.46f;
                Debug.Log("This is " + planet_name + " , orbit period is: " + oribtPeriod_planet);
                break;

            case "Mars":
                oribtPeriod_planet = oribtPeriod_planet * 1.88f;
                Debug.Log("This is " + planet_name + " , orbit period is: " + oribtPeriod_planet);
                break;


        }

        return  oribtPeriod_planet;

    }


}
