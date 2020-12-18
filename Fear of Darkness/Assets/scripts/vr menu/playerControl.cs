using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerControl : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpheight = 3f;

    public bool vrMove = false;
    public float vrSpeed = 6f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    //related to interactable object
    private interactScript interactObject;
    public int buttonE = 0;

    public void setE()
    {
        buttonE = 1;
    }

    /// <key>
    public static int openMainDoorCount;
    public static bool keyIsChanged = false;
    public Text keysTaken;
    /// </key>
    //<
    GameObject City;


    void Start()
    {
        openMainDoorCount = PlayerPrefs.GetInt("NumberOfKeys");
        City=GameObject.Find("Amaryllis City");
        City.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        //playerMovementUpdate();

        playerVRMovementUpdate();
        keyChangedTextUpdate();
        interactWithObject();
        createCity();
    }

    void interactWithObject()
    {
        if (buttonE == 1)
        {
            //var ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            var hitInfo = new RaycastHit();
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.transform.gameObject.tag != "InteractableObject")
                    return;
                interactObject = hitInfo.transform.gameObject.GetComponent<interactScript>();

                if (interactObject.name == "Door.005" && openMainDoorCount != 0)
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
    }

    void playerMovementUpdate()
    {
        //isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        isGrounded = false;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;


        //// change velocity direction to the direction in which the character is seeing
        move = Camera.main.transform.TransformDirection(move);
        ////

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    void playerVRMovementUpdate()
    {
        if(vrMove)
        {
            //isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            isGrounded = false;
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.forward * 1;


            //// change velocity direction to the direction in which the character is seeing
            move = Camera.main.transform.TransformDirection(move);
            ////

            controller.Move(move * vrSpeed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);

        }
        
    }

    public void setVRMove()
    {
        vrMove = true;
    }
    public void resetVRMove()
    {
        vrMove = false;
    }

    public void toggleVRMove()
    {
        if (vrMove)
        {
            vrMove = false;
        }
        else
        {
            vrMove = true;
        }
    }

    void keyChangedTextUpdate()
    {
        if (keyIsChanged)
        {
            int keys = PlayerPrefs.GetInt("NumberOfKeys") - openMainDoorCount;
            keysTaken.text = "" + keys;
            keyIsChanged = false;
        }
    }

    void createCity()
    {
        if(openMainDoorCount==0)
        {
            City.SetActive(true);
        }
    }
}