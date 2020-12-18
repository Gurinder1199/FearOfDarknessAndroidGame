using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class joyPlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    //public Camera playerCam;
    private interactScript interactObject;

    public float speed = 5f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public static int openMainDoorCount;
    public static bool keyIsChanged = false;
    public Text keysTaken;

    public float x = 0;
    public float z = 0;

    public int buttonE = 0;

    Vector3 velocity;
    bool isGrounded;

    public void setE()
    {
        buttonE = 1;
    }

    public void setW()
    {
        z = 1;
    }

    public void setS()
    {
        z = -1;
    }

    public void setA()
    {
        x = -1;
    }

    public void setD()
    {
        x = 1;
    }

    public void resetXZ()
    {
        x = 0;
        z = 0;
    }

    void Start()
    {
        openMainDoorCount = PlayerPrefs.GetInt("NumberOfKeys");
        keysTaken.text = "" + 0;
    }

    void Update()
    {
        if (keyIsChanged)
        {
            int keys = PlayerPrefs.GetInt("NumberOfKeys") - openMainDoorCount;
            keysTaken.text = "" + keys;
            keyIsChanged = false;
        }
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //float x = Input.GetAxis("Horizontal");
        //float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        //resetXZ();

        controller.Move(move * speed * Time.deltaTime);
        //

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (buttonE==1)
        {
            //var ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            var hitInfo = new RaycastHit();
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.transform.gameObject.tag != "InteractableObject")
                    return;
                interactObject = hitInfo.transform.gameObject.GetComponent<interactScript>();

                if (interactObject.name == "Door.005" && openMainDoorCount!=0)
                {
                                        
                }
                else
                {
                    interactObject.open = (interactObject.open + 1) % 2;
                    interactObject.change = true;
                }


                //var newPos = transform.position;
                //newPos.x = hitInfo.point.x;
                //transform.position = newPos;
            }
            buttonE = 0;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        //delta s=g t^2 /2;
    }


}
