using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField] Camera cm;
    [SerializeField] float mouseSpeed = 5f;

    Vector3 camRotation;

    float mouseX = 0;
    float mouseY = 0;

    private void Start()
    {
        
    }

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

        //camRotation = cm.transform;
        transform.Rotate(Vector3.up * mouseX);
        cm.transform.Rotate(Vector3.right * -mouseY);
        camRotation = cm.transform.rotation.eulerAngles;

        // TODO fix clamp cam rotation
        if (camRotation.x > 90f && camRotation.x < 95f)
        {
            //print(camRotation.x + " is greater than 270");
            camRotation.x = 89f;
            //goto ApplyChange;
        }
        else if (camRotation.x < 270f && camRotation.x > 265f)
        {
            camRotation.x = 271f;
            //goto ApplyChange;
        }
        
        return;

        //ApplyChange:
        //print("cam rotation after: " + camRotation);
        //cm.transform.rotation = Quaternion.Euler(camRotation);
    }
}
