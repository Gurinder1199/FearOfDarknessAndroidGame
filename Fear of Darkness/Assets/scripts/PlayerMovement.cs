using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : characterController
{
    //public CharacterController controller;
    ////public Camera playerCam;
    //private interactScript interactObject;

    //public float speed = 12f;
    //public float gravity = -9.81f;
    //public float jumpHeight = 3f;

    //public Transform groundCheck;
    //public float groundDistance = 0.4f;
    //public LayerMask groundMask;

    //Vector3 velocity;
    //bool isGrounded;

    protected override void Update()
    {
        base.Update();
        //isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //if (isGrounded && velocity.y < 0)
        //{
        //    velocity.y = -2f;
        //}

        //float x = Input.GetAxis("Horizontal");
        //float z = Input.GetAxis("Vertical");

        //Vector3 move = transform.right * x + transform.forward * z;

        //controller.Move(move * speed * Time.deltaTime);
        ////

        //if (Input.GetButtonDown("Jump") && isGrounded)
        //{
        //    velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        //    Debug.Log("Jumped just now");
        //}

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Key E is pressed");
            //var ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            var hitInfo = new RaycastHit();
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.transform.gameObject.tag != "InteractableObject")
                    return;
                interactObject = hitInfo.transform.gameObject.GetComponent<interactScript>();

                interactObject.open = (interactObject.open + 1) % 2;
                interactObject.change = true;

                //var newPos = transform.position;
                //newPos.x = hitInfo.point.x;
                //transform.position = newPos;
            }
        }

        //velocity.y += gravity * Time.deltaTime;

        //controller.Move(velocity * Time.deltaTime);
        ////delta s=g t^2 /2;
    }
}
