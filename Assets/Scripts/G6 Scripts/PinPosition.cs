using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinPosition : MonoBehaviour
{
    GameObject origin;
    public float step;
    public bool returning;

    private void OnTriggerEnter(Collider other)
    {   
        returning = true;
        origin = other.gameObject;
    }
    private void Update()
    {
        if (returning)
        {
            gameObject.transform.position = transform.position = Vector3.MoveTowards(transform.position, origin.transform.position, step * Time.deltaTime);
            if (gameObject.transform.position == origin.transform.position)
            {
                returning = false;
            }
        }

    }
}
