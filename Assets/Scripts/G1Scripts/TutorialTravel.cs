using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTravel : MonoBehaviour
{
    public Material[] skyboxesTutorial;
    public int tutorialPart;
    public GameObject tuto1;
    public GameObject naveCam;
    public GameObject warp;
    public bool starendtuto;
    public GameObject galaxyKey;
    public GameObject sliderTuto;
    private void Update()
    {
        if (tutorialPart == 1)
        {
            
            tuto1.SetActive(false);
            if (starendtuto == true)
            {
                StartCoroutine(countAnim());
                starendtuto = false;
            }
        }
        if (tutorialPart == 2)
        {
            RenderSettings.skybox = skyboxesTutorial[2];
        }        
    }

    public void FinWarpTutorial()
    {
        
        RenderSettings.skybox = skyboxesTutorial[1];
        warp.GetComponent<Animator>().Play("IdleParticle");
        naveCam.GetComponent<Animator>().Play("landing");
        Debug.Log("FinWarpTutorial");
        galaxyKey.SetActive(true);
        sliderTuto.SetActive(true);

    }

    IEnumerator countAnim()
    {
        
        yield return new WaitForSeconds(7.5f);
        FinWarpTutorial();
        
    }
}
