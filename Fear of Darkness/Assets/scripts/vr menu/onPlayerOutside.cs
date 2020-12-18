using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class onPlayerOutside : MonoBehaviour
{
    public GameObject character;
    public GameObject apartment;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == character.transform.name)
        {
            apartment.SetActive(false);
            PlayerPrefs.SetInt("HasWon", 1);
        }
    }
}