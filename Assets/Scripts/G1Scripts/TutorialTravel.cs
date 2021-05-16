using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTravel : MonoBehaviour
{
    public Material[] skyboxesTutorial;
    public int tutorialPart;
    public GameObject tuto1;
    

    private void Update()
    {
        if (tutorialPart == 1)
        {
            RenderSettings.skybox = skyboxesTutorial[1];
            tuto1.SetActive(false);
        }
        if (tutorialPart == 2)
        {
            RenderSettings.skybox = skyboxesTutorial[2];
        }
        if (tutorialPart == 3)
        {

        }
        if (tutorialPart == 4)
        {

        }
    }
}
