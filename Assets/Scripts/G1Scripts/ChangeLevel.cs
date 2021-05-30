using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeLevel : MonoBehaviour
{
    public GameObject[] planetsLevel;
    public Slider sliderRot;

    public int lvl;
    public bool changeLVL = false;

    public Material[] sky;
    public bool forward;
    public bool backward;
    public GameObject naveCam;
    public Timer timeToStart;
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.GetComponent<Animator>().Play("Warpdrive__Sequence");
            sliderRot.value = 90;
            sliderRot.gameObject.SetActive(false);
            forward = true;
        }
        
        if (Input.GetKeyDown(KeyCode.X) && lvl >= 1)
        {
            gameObject.GetComponent<Animator>().Play("Warpdrive__Sequence");
            sliderRot.value = 90;
            sliderRot.gameObject.SetActive(false);
            backward = true;
        }
        Debug.Log(lvl);
    }

    public void Forward()
    {
        gameObject.GetComponent<Animator>().Play("Warpdrive__Sequence");
        sliderRot.value = 90;
        sliderRot.gameObject.SetActive(false);
        forward = true;
    }

    public void Backward()
    {
        gameObject.GetComponent<Animator>().Play("Warpdrive__Sequence");
        sliderRot.value = 90;
        sliderRot.gameObject.SetActive(false);
        backward = true;
    }

    public void ChangeAnimation()
    {
        gameObject.GetComponent<Animator>().Play("IdleParticle");
        sliderRot.gameObject.SetActive(true);
        forward = false;
        backward = false;
        changeLVL = false;
        
    }

    //primer evento en animacion descativa los planetas
    public void StartJourney()
    {
        
        timeToStart.timerUI.gameObject.SetActive(true);
        timeToStart.start = true;
        foreach (var item in planetsLevel)
            {
                item.SetActive(false);
            }
        changeLVL = true;
    }

    //Comparacion de variables, adicion de estas para cambios de escena con planetas diferentes.
    public void EndJourney()
    {
        naveCam.GetComponent<Animator>().Play("landing");
        #region forward
        if (lvl == 0 && forward)
        {
            planetsLevel[0].SetActive(true);
            RenderSettings.skybox = sky[0];           
            lvl = 1;
            
        }
        
        else if (lvl == 1 && forward)
        {
            planetsLevel[1].SetActive(true);
            RenderSettings.skybox = sky[1];
            lvl = 2;
           
        }
        
        else if (lvl == 2 && forward)
        {
            planetsLevel[2].SetActive(true);
            RenderSettings.skybox = sky[2];           
            lvl = 3;
            
        }
        
        else if (lvl == 3 && forward)
        {
            planetsLevel[3].SetActive(true);
            RenderSettings.skybox = sky[3];
            lvl = 4;
            
        }
        #endregion

        #region backward
        
        else if (lvl == 1 && backward)
        {
            planetsLevel[0].SetActive(false);
            RenderSettings.skybox = sky[0];
            lvl = 0;
            
        }
        
        else if (lvl == 2 && backward)
        {
            planetsLevel[0].SetActive(true);
            RenderSettings.skybox = sky[0];           
            lvl = 1;
            
        }
        
        else if (lvl == 3 && backward)
        {
            planetsLevel[1].SetActive(true);
            RenderSettings.skybox = sky[1];
            lvl = 2;
            
        } 
        else if (lvl == 4 && backward)
        {
            planetsLevel[2].SetActive(true);
            RenderSettings.skybox = sky[2];
            lvl = 3;
            
        }
        else if (lvl == 5 && backward)
        {
            planetsLevel[3].SetActive(true);
            RenderSettings.skybox = sky[3];
            lvl = 4;
            
        }

        #endregion

    }
}
