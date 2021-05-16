using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_Destruct : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
