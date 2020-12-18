using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactScript : MonoBehaviour
{
    //door properties start
    [Range(0, 1)]
    public int open = 0;
    [Range(0, 1)]
    public int openOutside = 1;
    //door properties end

    public bool change = false;
    [Range(0, 3)]
    public int objectType = 0;

    void Update()
    {
        if (change)
        {
            switch (objectType)
            {
                case 0:
                    if (open == 0)
                    {
                        if (openOutside == 1)
                            transform.localRotation *= Quaternion.Euler(0f, 0f, 90f);
                        else
                            transform.localRotation *= Quaternion.Euler(0f, 0f, -90f);
                    }
                    else
                    {
                        if (openOutside == 1)
                            transform.localRotation *= Quaternion.Euler(0f, 0f, -90f);
                        else
                            transform.localRotation *= Quaternion.Euler(0f, 0f, 90f);
                    }
                    break;
                case 1:
                    if (open == 0)
                    {
                        if (openOutside == 1)
                            transform.localRotation *= Quaternion.Euler(0f, -90f, 0f);
                        else
                            transform.localRotation *= Quaternion.Euler(0f, 90f, 0f);
                    }
                    else
                    {
                        if (openOutside == 1)
                            transform.localRotation *= Quaternion.Euler(0f, 90f, 0f);
                        else
                            transform.localRotation *= Quaternion.Euler(0f, -90f, 0f);
                    }
                    break;
                case 2:
                    vrPlayerMovementCase();
                    transform.gameObject.SetActive(false);
                    break;
            }
            change = false;
        }
    }

    void joyPlayerMovementCase()
    {
        joyPlayerMovement.openMainDoorCount -= 1;
        joyPlayerMovement.keyIsChanged = true;
    }

    void vrPlayerMovementCase()
    {
        playerControl.openMainDoorCount -= 1;
        playerControl.keyIsChanged = true;
    }
}
