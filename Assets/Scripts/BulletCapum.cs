using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCapum : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(BulletDestroy());
    }
    public IEnumerator BulletDestroy()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
