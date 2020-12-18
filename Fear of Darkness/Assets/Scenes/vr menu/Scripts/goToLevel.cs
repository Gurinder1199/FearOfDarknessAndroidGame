using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goToLevel : MonoBehaviour
{
    public CanvasGroup[] canvasGroups;
    private bool canvasIsInteractable = true;

    public Transform[] doors;
    private Vector3[] backupDoorPositions;
    public Transform[] otherObjects;
    private int closed=1;
    public bool inTransition=false;
    public float timeTaken = 30f;
    public float distanceDoor = 2f;
    public float distanceOtherObjects = 3.3528f;
    private float speedDoor;
    private float speedOtherObjects;
    private float distanceSpannedDoor = 0;
    private float distanceSpannedOtherObjects = 0;
    private float tempDistance = 0;

    public void Start()
    {
        backupDoorPositions = new Vector3[doors.Length];
        speedDoor = distanceDoor / timeTaken;
        speedOtherObjects = distanceOtherObjects / timeTaken;

        for(int i=0;i<doors.Length; i++)
        {
            backupDoorPositions[i] = doors[i].position;
        }

    }

    public void Update()
    {
        if(inTransition)
        {
            transitionDoors();
        }
    }

    public void changeLevel()
    {
        inTransition = true;
        toggleCanvasInteractivity();
    }

    public void toggleCanvasInteractivity()
    {
        canvasIsInteractable = canvasIsInteractable ? false : true;
        for (int i=0;i<canvasGroups.Length;i++)
        {
            //Debug.Log(canvasIsInteractable);
            canvasGroups[i].interactable = canvasIsInteractable;
            canvasGroups[i].blocksRaycasts = canvasIsInteractable;
        }
    }

    private void transitionDoors()
    {
        tempDistance = speedDoor * Time.deltaTime;
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].position -= doors[i].right * tempDistance * closed;
        }
        distanceSpannedDoor += tempDistance;
        tempDistance = speedOtherObjects * Time.deltaTime;

        otherObjects[0].position += otherObjects[0].up * tempDistance * closed;
        otherObjects[1].position += otherObjects[1].forward * tempDistance * closed;

        distanceSpannedOtherObjects += tempDistance;
        if (distanceSpannedDoor >= distanceDoor && distanceSpannedOtherObjects >= distanceOtherObjects)
        {
            float differenceDoor = distanceSpannedDoor - distanceDoor;
            for (int i = 0; i < doors.Length; i++)
            {
                doors[i].position -= doors[i].right * differenceDoor * closed;
                if (closed==-1)
                    doors[i].position = backupDoorPositions[i];
            }
            float differenceOtherObjects = distanceSpannedOtherObjects - distanceOtherObjects;
            otherObjects[0].position -= otherObjects[0].up * differenceOtherObjects * closed;
            otherObjects[1].position += otherObjects[1].forward * differenceOtherObjects * closed;

            distanceSpannedDoor = 0;
            distanceSpannedOtherObjects = 0;
            inTransition = false;
            closed *= -1;
            toggleCanvasInteractivity();
        }
        
    }
}
