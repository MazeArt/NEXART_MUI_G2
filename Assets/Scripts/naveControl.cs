using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class naveControl : MonoBehaviour
{   
    private float rotation = 35;    
    public Slider sliderRot;   

    [Header("BulletEffect")]
    public float bulletSpeed = 25.5f;
    public Rigidbody bullet;
    public Transform bulletOrigin;
    public static bool fireOn;
    

    private void Start()
    {
        sliderRot.value = rotation;
        fireOn = true;
    }
    private void Update()
    {
        transform.localEulerAngles = new Vector3(0, Mathf.PingPong(sliderRot.value, 70) - 35, 0 );       

    }

    public void Fire()
    {
        if (fireOn)
        {
            Rigidbody bulletClone = (Rigidbody)Instantiate(bullet, bulletOrigin.transform.position, bulletOrigin.transform.rotation);
            bulletClone.velocity = transform.right * bulletSpeed;
            fireOn = false;
            StartCoroutine(FireOnTrue());
        }
              
    }

    public IEnumerator FireOnTrue()
    {
        yield return new WaitForSeconds(5);
        fireOn = true;
    }





}