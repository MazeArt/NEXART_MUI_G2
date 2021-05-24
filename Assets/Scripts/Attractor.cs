using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{

    //constante Gravitatoria de Newton
    // valor original 6.674, pero se modifica para jugar con las escalas
    const float G = 6.674f;

    public Rigidbody rb;
    public OrbitManager orbitManager;

    void FixedUpdate()
    {
        Attractor[] attractors = FindObjectsOfType<Attractor>();
        //for para cada Attractor component llamado attractor en array attractors
        foreach (Attractor attractor in attractors)
        {
            if (attractor != this)
                Attract(attractor);
        }
    }
    // Start is called before the first frame update
    void Attract(Attractor objToAttract)
    {
        Rigidbody rbToAttract = objToAttract.rb;
        //calcula la posion de este objeto menos la pos del obj-to-attract
        Vector3 direction = rb.position - rbToAttract.position;
        //genera un vector de distancia del vector direcci?n
        float distance = direction.magnitude;

       // rb.mass = Check_planet_mass(rb.gameObject.name);

        // aqu? usamos la ecuaci?n de Newton : F = G* (m1 * m2 ) / d^2 
        float forceMagnitude = G * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);

        //aqu? creamos un vector de fureza : una fuerza en la direcci?n de los objetos con una magnitude dada la ecuaci?n de Newton
        Vector3 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);
    }

   
}