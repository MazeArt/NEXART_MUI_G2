using UnityEngine;

public class SceneIntG2 : MonoBehaviour
{
    public GameObject mars;
    public Light directionalLight;
    public float lightIntensity;
    public bool startWithAnimation;
    public bool animationEnds;

    void Start()
    {
        if (startWithAnimation)
        {
            animationEnds = false;
            directionalLight.intensity = 0;
            gameObject.GetComponent<Animator>().Play("G2MainCameraOnStart");
        }
        else
        {
            gameObject.GetComponent<SceneIntG2>().enabled = false;
        }
    }
    private void Update()
    {
        
        if (animationEnds)
        {

            mars.GetComponent<PlanetRotation>().sunRotationSpeed=0;
            animationEnds = false;
            gameObject.GetComponent<SceneIntG2>().enabled = false;
            
        }
        else
        {
            directionalLight.intensity = lightIntensity;
        }
    }


}
