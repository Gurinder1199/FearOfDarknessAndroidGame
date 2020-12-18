using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateKey : MonoBehaviour
{
    public float speed = 100f;

    void Update()
    {
        transform.localRotation *= Quaternion.Euler(0f, speed*Time.deltaTime, 0f);
    }
}
