using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class EarthDestroy : MonoBehaviour
{
    public int points;
    public UnityEvent destructionEarthEvent;
    public bool add;
    public Rigidbody EarthRb;
    public GameObject ImpactAnim;
    public GameObject ZoomDestroy;

    private void Start()
    {
        if (destructionEarthEvent == null)
            destructionEarthEvent = new UnityEvent();
        add = true;

        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("meteorito"))
        {
            destructionEarthEvent.Invoke();
            EarthRb.constraints = RigidbodyConstraints.FreezeAll;
            ImpactAnim.SetActive(true);
            ZoomDestroy.SetActive(true);
            if (add)
            {
                Puntaje.valorpuntaje++;
                add = false;
            }
        }
        
    }

    
}
