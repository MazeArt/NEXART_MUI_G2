using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class naveControl : MonoBehaviour
{   
    private float rotation = 35;    
    public Slider sliderRot;   

    [Header("BulletEffect")]
    public float bulletSpeed = 10;
    public Rigidbody bullet;
    public Transform bulletOrigin;

    private void Start()
    {
        sliderRot.value = rotation;
    }
    private void Update()
    {
        transform.localEulerAngles = new Vector3(0, 0, Mathf.PingPong(sliderRot.value, 70) - 35);       

    }

    public void Fire()
    {
        Rigidbody bulletClone = (Rigidbody)Instantiate(bullet, bulletOrigin.transform.position, bulletOrigin.transform.rotation);
        bulletClone.velocity = transform.up * bulletSpeed;
        
    }

    



}