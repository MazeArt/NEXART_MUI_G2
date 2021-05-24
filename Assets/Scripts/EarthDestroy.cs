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
    public GameObject ImpactAsteroid;

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

            Destroy(gameObject);

            EarthRb.constraints = RigidbodyConstraints.FreezeAll;
            ZoomDestroy.SetActive(true);
            StartCoroutine(destructionWaiter());

            Debug.Log("this is current orbit progress: " + this.gameObject.GetComponent<OrbitMotion>().orbitProgress);
            Debug.Log("this is current fastwd: " + GameObject.Find("OrbitSlideManager").GetComponent<OrbitManager>().orbit_fastfwd);
            this.gameObject.GetComponent<OrbitMotion>().orbitProgress = 0.87f;
            GameObject.Find("OrbitSlideManager").GetComponent<OrbitManager>().orbit_fastfwd = 0f;


            if (add)
            {
                Puntaje.valorpuntaje++;
                add = false;
            }
        }

    }

    public IEnumerator destructionWaiter()
    {
        yield return new WaitForSeconds(1);
        ImpactAsteroid.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        ImpactAnim.SetActive(true);
        yield return null;

    }
        
    
}
