using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField] Camera cm;
    [SerializeField] float mouseSpeed = 5f;

    float mouseX = 0;
    float mouseY = 0;

    // Update is called once per frame
    void LateUpdate()
    {
        bool menuIsOpen = GetComponent<PlayerMove>().menuIsOpen;

        if (!menuIsOpen)
        {
            RotatePlayer();
        }
    }

    void RotatePlayer()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);
        cm.transform.Rotate(Vector3.right * -mouseY);
    }
}
