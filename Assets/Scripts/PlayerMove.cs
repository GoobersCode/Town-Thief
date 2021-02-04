using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] CharacterController characterController;

    [SerializeField] float speed = 1f;

    float moveX = 0;
    float moveZ = 0;
    
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
        
        characterController.Move(transform.right * moveX + transform.forward * moveZ);
    }

    
}


