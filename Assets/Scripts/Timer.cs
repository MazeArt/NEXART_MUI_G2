using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time;
    public Text timerUI;
    public bool start = false;

    private void Start()
    {
        timerUI.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (start) 
        { 
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            time = 0;
        }
        timerUI.text = time.ToString("f0");

    }
         }

    public void starGame()
    {
        start = true;

    }
}
