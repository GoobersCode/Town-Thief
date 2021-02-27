using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepAI : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    [SerializeField] Transform groundCheck;

    public bool isBeingHeld = false;

    Rigidbody m_rigidbody;

    Vector3 moveDirection;

    Quaternion newRotation;

    RaycastHit hit;

    float dirX = 0f;
    float dirY = 0f;

    bool didHit = false;
    
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();

        GroundSheep();
    }

    

    bool prevIsBeingHeld = false;
    // Update is called once per frame
    void Update()
    {
        bool heldStateChanged;
        if (isBeingHeld != prevIsBeingHeld)
        {
            heldStateChanged = true;
        }
        else
        {
            heldStateChanged = false;
        }

        if (!isBeingHeld)
        {
            if (heldStateChanged)
            {
                GroundSheep();
            }

            MoveSheep();
        }

        prevIsBeingHeld = isBeingHeld;
    }

    private void MoveSheep()
    {
        m_rigidbody.velocity = transform.forward * moveSpeed * Time.deltaTime;
    }

    private void GroundSheep()
    {
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
        didHit = Physics.Raycast(transform.position, -Vector3.up, out hit, Mathf.Infinity);
        if (!didHit) return;

        if (hit.collider.tag == "Ground" || hit.collider.tag == "LandRamp" || hit.collider.tag == "LandRaised")
        {

            transform.position = new Vector3(transform.position.x,
                hit.point.y + Vector3.Distance(transform.position, groundCheck.position),
                transform.position.z);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, (-Vector3.up).y * 22f, groundCheck.position.z));
    }
}
