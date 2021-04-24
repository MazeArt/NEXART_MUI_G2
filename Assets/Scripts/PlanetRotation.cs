using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    public float rotationSpeed;
    private void Update()
    {
        transform.Rotate(0, 1 * rotationSpeed, 0);
    }
}
