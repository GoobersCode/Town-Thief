using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerAI : MonoBehaviour
{
    enum PathMoveState
    {
        forward,
        backward
    }

    PathMoveState pathDirection = PathMoveState.forward;

    // Serialized
    [SerializeField] Transform path;

    [SerializeField] float moveForce = 5f;

    [SerializeField] float distanceCheck = 0.2f;

    // Unserialized
    Transform[] pathNodes;

    Vector3 directionTo;
    float distanceTo = 0f;

    Rigidbody m_rigidbody;

    bool playerIsSpotted = false;

    void Start()
    {
        directionTo = new Vector3();

        pathNodes = new Transform[path.childCount];

        for(int i = 0; i < path.childCount; i++)
        {
            pathNodes[i] = path.GetChild(i);
        }

        transform.position = pathNodes[0].position;
        m_rigidbody = GetComponent<Rigidbody>();
    }

    int currentNode = 0;
    int prevNode = 0;
    void Update()
    {
        if (playerIsSpotted)
        {
            // ChasePlayer();
        }
        else
        {
            FollowPath();
        }
    }

    private void FollowPath()
    {
        distanceTo = (new Vector3(transform.position.x, pathNodes[prevNode].position.y, transform.position.z) - pathNodes[prevNode].position).magnitude;
        Debug.Log("Distance to next node: " + distanceTo);

        if (distanceTo < distanceCheck)
        {
            ChangeNode();
        }
    }

    private void ChangeNode()
    {
        ChangeDirection();

        directionTo = (pathNodes[currentNode].position - pathNodes[prevNode].position).normalized;
        transform.position = pathNodes[prevNode].position;
        transform.rotation = Quaternion.LookRotation(directionTo, Vector3.up);
        m_rigidbody.AddForce(directionTo * moveForce, ForceMode.Impulse);
    }

    private void ChangeDirection()
    {
        if (pathDirection == PathMoveState.forward)
        {
            if (currentNode < pathNodes.Length - 1)
            {
                currentNode++;
            }
            else
            {
                pathDirection = PathMoveState.backward;
            }
        }
        else
        {
            if (currentNode > 0)
            {
                currentNode--;
            }
            else
            {
                pathDirection = PathMoveState.forward;
            }
        }
    }

    private void ChasePlayer()
    {
        throw new NotImplementedException();
    }
}
