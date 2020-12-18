using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject keyPrefab;
    public int numberOfKeys;
    public Transform[] spawnLocations;
    private bool[] isSpawned;
    //public GameObject[] whatToSpawnPrefab;
    //public GameObject[] whatToSpawnClone;

    //void spawnObject()
    //{
    //  whatToSpawnClone[0] = Instantiate(whatToSpawnPrefab[0], spawnLocations[0].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;

    //}

    void Start()
    {
        numberOfKeys= PlayerPrefs.GetInt("NumberOfKeys");
        isSpawned = new bool[spawnLocations.Length];
        SpawnObjects();
    }

    void SpawnObjects()
    {
        for (int i=0;i<numberOfKeys;i++)
        {
            //int selection = Random.Range(0, spawnObjects.Count);
            //Instantiate(spawnObjects[selection], spawnPosition.transform.position, spawnPosition.transform.rotation);
            int selectedPosition = getRandomLocationIndex();
            Instantiate(keyPrefab, spawnLocations[selectedPosition].position, spawnLocations[selectedPosition].rotation);
        }
    }

    int getRandomLocationIndex()
    {
        int i;
        do
        {
            i = Random.Range(0, spawnLocations.Length);
        }
        while (isSpawned[i]);
        isSpawned[i] = true;
        return i;
    }

    void assignFalseIsSpawned()
    {
        for(int i=0; i<spawnLocations.Length; i++)
        {
            isSpawned[i] = false;
        }
    }
}
