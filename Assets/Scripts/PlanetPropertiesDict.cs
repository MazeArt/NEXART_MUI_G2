using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetPropertiesDict : MonoBehaviour
{

    public Dictionary<string, PlanetProperties> EarthOptions = new Dictionary<string, PlanetProperties>();
    public Dictionary<string, PlanetProperties> MercuryOptions = new Dictionary<string, PlanetProperties>();
    public Dictionary<string, PlanetProperties> VenusOptions = new Dictionary<string, PlanetProperties>();
    public Dictionary<string, PlanetProperties> MarsOptions = new Dictionary<string, PlanetProperties>();
    public Dictionary<string, PlanetProperties> JupiterOptions = new Dictionary<string, PlanetProperties>();
    public Dictionary<string, PlanetProperties> SaturnOptions = new Dictionary<string, PlanetProperties>();
    public Dictionary<string, PlanetProperties> SunOptions = new Dictionary<string, PlanetProperties>();

    public Dictionary<string, bulletProperties> bulletOptions = new Dictionary<string, bulletProperties>();



    // Start is called before the first frame update

    void Awake()
    {
        // Build OPT1 Options for all planets ( celestial bodies)
        //planetOptions["optx"] :                       mass,   xAxis, scale,   oribtalPeriod}
        EarthOptions["opt1"] = new PlanetProperties     (1000f, 149f,  0.12f,   1f);
        MercuryOptions["opt1"] = new PlanetProperties   (111f,  58f,   1f,      0.5f);
        VenusOptions["opt1"] = new PlanetProperties     (111f,  108f,  0.08f,   0.8f);
        MarsOptions["opt1"] = new PlanetProperties      (160f,  227f,  0.06f,   1.88f);
        JupiterOptions["opt1"] = new PlanetProperties   (15000f, 500f,  0.41f,   11.86f);
        SaturnOptions["opt1"] = new PlanetProperties    (7500f, 720f,  0.25f,   29.46f);
        SunOptions["opt1"] = new PlanetProperties       (10f,   0f,    90.35f,  0f);

        // Build OPT1 Options for all planets ( celestial bodies)
        //Same as opt1 pero sin masa
        //planetOptions["optx"] :                       mass,   xAxis, scale,   oribtalPeriod}
        EarthOptions["opt0"] = new PlanetProperties     (1000f, 151f,  0.12f,   1f);
        MercuryOptions["opt0"] = new PlanetProperties   (0,     0f,    1f,      0.5f);
        VenusOptions["opt0"] = new PlanetProperties     (0,     107f,  0.08f,   0.8f);
        MarsOptions["opt0"] = new PlanetProperties      (0,     231f,  0.06f,   1.88f);
        JupiterOptions["opt0"] = new PlanetProperties   (0,     331f,  0.41f,   11.86f);
        SaturnOptions["opt0"] = new PlanetProperties    (0,     420f,  0.25f,   29.46f);
        SunOptions["opt0"] = new PlanetProperties       (0,     0f,    57.35f,  0f);   


        // Build OPT2 Options for all ...
        //planetOptions["optx"] :                       mass,   xAxis,  scale,      oribtalPeriod}
        EarthOptions["opt2"] = new PlanetProperties     (200f,   81f,   0.12f,      1f);
        MercuryOptions["opt2"] = new PlanetProperties   (111f,   50f,   1f,         0.5f);
        VenusOptions["opt2"] = new PlanetProperties     (111f,   40f,   0.08f,      0.8f);  
        MarsOptions["opt2"] = new PlanetProperties      (160f,   121f,  0.06f,      1.88f);   
        JupiterOptions["opt2"] = new PlanetProperties   (8000f,  208f,  0.25f,      11.86f);
        SaturnOptions["opt2"] = new PlanetProperties    (5000f,  420f,  0.25f,      29.46f);
        SunOptions["opt2"] = new PlanetProperties       (10f,    0f,    35.35f,     0f);


        bulletOptions["opt0"] = new bulletProperties(25f, 10f);
        bulletOptions["opt1"] = new bulletProperties(100f, 10f);
        bulletOptions["opt2"] = new bulletProperties(1f, 10f);

    }



}


public class PlanetProperties
{
    
    public float planetMass;
    public float planetxAxis;
    public float planetScale;
    public float planetorbitPeriod;

    public PlanetProperties(float mass, float xAxis, float scale, float period)
    {
        this.planetMass = mass;
        this.planetxAxis = xAxis;
        this.planetScale = scale;
        this.planetorbitPeriod = period;

    }   
}

public class bulletProperties
{

    public float bulletSpeed;
    public float bulletDestroySeconds;


    public bulletProperties(float speed, float seconds)
    {
        this.bulletSpeed= speed;
        this.bulletDestroySeconds = seconds;

    }
}

// using Dictrionay and Lists alternative
//  Dictionary<string, List<float>> massOptions = new Dictionary<string, List<float>>();









