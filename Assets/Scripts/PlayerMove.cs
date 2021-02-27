using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] CharacterController characterController;

    [SerializeField] float speed = 1f;

    float moveX = 0;
    float moveZ = 0;
    float jump = 0;
    
    public bool menuIsOpen = false;

    

    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!menuIsOpen && Input.GetKeyDown(KeyCode.Escape))
        {
            menuIsOpen = true;
        }
        else if (menuIsOpen && (Input.GetKeyDown(KeyCode.Escape) || Input.GetButton("Fire1")))
        {
            menuIsOpen = false;
        }

        if (!menuIsOpen)
        {
            MovePlayer();
        }
    }

    void MovePlayer()
    {
        moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        {
            jump = speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            jump = -speed * Time.deltaTime;
        }
        else
        {
            jump = 0f;
        }
        
        characterController.Move(transform.right * moveX + transform.forward * moveZ + transform.up * jump);
    }

    
}


