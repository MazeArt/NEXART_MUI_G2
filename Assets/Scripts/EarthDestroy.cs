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
<<<<<<< Updated upstream
=======
    public Rigidbody EarthRb;
    public GameObject ImpactAnim;
    public GameObject ZoomDestroy;
    //public OrbitMotion EarthOrb;
>>>>>>> Stashed changes

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
<<<<<<< Updated upstream
            Destroy(gameObject);
=======
            EarthRb.constraints = RigidbodyConstraints.FreezeAll;
            ImpactAnim.SetActive(true);
            ZoomDestroy.SetActive(true);

            Debug.Log("this is current orbit progress: " + this.gameObject.GetComponent<OrbitMotion>().orbitProgress);
            Debug.Log("this is current fastwd: " + GameObject.Find("OrbitSlideManager").GetComponent<OrbitManager>().orbit_fastfwd);
            this.gameObject.GetComponent<OrbitMotion>().orbitProgress = 0.87f;
            GameObject.Find("OrbitSlideManager").GetComponent<OrbitManager>().orbit_fastfwd = 0f;

>>>>>>> Stashed changes
            if (add)
            {
                Puntaje.valorpuntaje++;
                add = false;
            }
        }
        
    }

    
}
