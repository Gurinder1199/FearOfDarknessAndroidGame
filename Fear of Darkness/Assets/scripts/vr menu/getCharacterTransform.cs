using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getCharacterTransform : MonoBehaviour
{
    public Transform character;

    void Start()
    {
        character.GetComponent<Transform>();
    }
    void Update()
    {
        transform.position = character.position;
    }
}