using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{    
    public GameObject cam1;
    public GameObject cam2;
    public Transform CameraOrigin;
    public GameObject MeteorCamera;
    private Transform MeteorTransform;
    private bool fireOn;


    private void Start()
    {
        fireOn = true;
    }
    void Update()
    {                   
        if (MeteorTransform)
        {
            MeteorCamera.transform.position = new Vector3(MeteorTransform.position.x, MeteorTransform.position.y, MeteorCamera.transform.position.z);
        }
        if (!MeteorTransform)
        {
            Destroy(MeteorCamera);
        }
    }

    public IEnumerator BulletDestroy()
    {
        yield return new WaitForSeconds(10);
        Destroy(MeteorCamera);
    }

    public void SpawnCamera2()
    {
        if (fireOn)
        {
            MeteorCamera = Instantiate(cam2, CameraOrigin);
            MeteorTransform = GameObject.Find("AsteoirdBullet1(Clone)").transform;
            StartCoroutine(BulletDestroy());
        }
        
    }
    public IEnumerator FireOnTrue()
    {
        yield return new WaitForSeconds(10);
        fireOn = true;
    }

}
