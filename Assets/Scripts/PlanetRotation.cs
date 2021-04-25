using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    public GameObject sun;
    public float rotationSpeed;
    public float sunRotationSpeed;
    public bool isMars;

    private void Start()
    {
        StartCoroutine(stopMars());
    }
    private void Update()
    {
        transform.Rotate(0, 1 * rotationSpeed, 0);
        transform.RotateAround(sun.transform.position, Vector3.forward, sunRotationSpeed * Time.deltaTime);
    }
    public IEnumerator stopMars()
    {
        yield return new WaitForSeconds(8);
        if (isMars)
        {
            this.sunRotationSpeed = 0;
        }
        
    }
}
