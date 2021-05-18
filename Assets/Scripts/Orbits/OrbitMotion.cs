using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitMotion : MonoBehaviour
{
    public Transform orbitingObject;
    public OrbitManager orbitManager;
    public Ellipse orbitPath;
    
    // Orbit Manager Variable
    private float orbitPeriod;
    
    [Range(0f, 1f)]
    public float orbitProgress ;
    //Origin in Ellipse
    public float orbitOrigin;

    //review THIS 
    public float OrbitPeriodRelativeToEarth;
    private float planetOrbitPeriod;



    // Start is called before the first frame update
    void Start()
    {
        //public float earthPeriodSpeed = orbitManager.orbit_fastfwd;
       
       
        planetOrbitPeriod = orbitManager.earthOrbitPeriodAbs * OrbitPeriodRelativeToEarth;

      //  Debug.Log(orbitingObject.name + " PLANET ORBIT PERIOD " + planetOrbitPeriod);

        if (orbitingObject == null)
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
        //DEPRECATED
        //planetOrbitPeriod = Check_planet(orbitingObject.name, orbitManager.earthOrbitPeriodAbs);



        // planetOrbitPeriod = orbitPeriod;
        //set orbiting speed
        orbitPeriod = planetOrbitPeriod / (orbitManager.orbit_fastfwd * Mathf.Abs(orbitManager.orbit_fastfwd) );
//        Debug.Log(orbitingObject.name + " PLANET ORBIT PERIOD :: : " + orbitPeriod + " " + planetOrbitPeriod);
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

}
