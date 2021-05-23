using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Puntaje : MonoBehaviour

{
    public static int valorpuntaje = 0;
    public Text puntos;
    public EarthDestroy EartD;
    

    // Start is called before the first frame update
    void Start()
    {        
   //    DontDestroyOnLoad(gameObject);
   //    EartD.destructionEarthEvent.AddListener(destructionEarthEvent);
   //    if (EartD == null)
   //    {
   //        Destroy(gameObject);
   //    }
   //    
        
    }    

    private void destructionEarthEvent()
    {
        StartCoroutine(RestartGame());
    }

    
    void Update()
    {
        puntos.text = "Planetas destruídos:" + valorpuntaje;        
    }


    public IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }
}