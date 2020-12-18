using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winAnimation : MonoBehaviour
{
    public float startScale=1;
    public float endScale = 2;
    public float speed = 1;


    // Update is called once per frame
    void Update()
    {
        float newSpeed = speed * Time.deltaTime;
        transform.localScale += new Vector3(newSpeed, newSpeed, newSpeed);
        if( transform.localScale.x < startScale || transform.localScale.x > endScale)
        {
            speed *= -1;
        }
    }
}
