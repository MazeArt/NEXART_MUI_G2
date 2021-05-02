using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeLevel : MonoBehaviour
{
    public GameObject[] planetsLevel;
    public Slider sliderRot;

    public int lvl;

    public Material[] sky;

    


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.GetComponent<Animator>().Play("Warpdrive__Sequence");
            sliderRot.value = 90;
            sliderRot.gameObject.SetActive(false);

        }
    }

    public void ChangeAnimation()
    {
        gameObject.GetComponent<Animator>().Play("IdleParticle");
        sliderRot.gameObject.SetActive(true);
    }

    public void StartJourney()
    {
        
        if (lvl == 0)
        {
            
        }

        if (lvl == 1)
        {
            planetsLevel[0].SetActive(false);
            
        }

        if (lvl == 2)
        {
            planetsLevel[1].SetActive(false);

        }
        
        if (lvl == 3)       
        {
            planetsLevel[2].SetActive(false);
        }
        
        if (lvl == 4)       
        {
            planetsLevel[3].SetActive(false);
        }


    }


    public void EndJourney()
    {
        if (lvl == 0)
        {
            planetsLevel[0].SetActive(true);
            RenderSettings.skybox = sky[0];           
            lvl = 1;

        }
        
        else if (lvl == 1)
        {
            planetsLevel[1].SetActive(true);
            RenderSettings.skybox = sky[1];
            lvl = 2;

        }
        
        else if (lvl == 2)
        {
            planetsLevel[2].SetActive(true);
            RenderSettings.skybox = sky[2];           
            lvl = 3;

        }
        
        else if (lvl == 3)
        {
            planetsLevel[3].SetActive(true);
            RenderSettings.skybox = sky[3];
            lvl = 4;

        }
                
    }
}
