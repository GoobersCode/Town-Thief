using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VillagerAI : MonoBehaviour
{
    enum PathMoveState
    {
        forward,
        backward
    }

    [SerializeField] Transform head;
    [SerializeField] Transform path;
    [SerializeField] Transform[] pathNodes;
    [SerializeField] Transform player;

    [SerializeField] float moveForce = 5f;
    [SerializeField] float nodeDistanceCheck = 0.01f;
    [SerializeField] float viewAngleHorizontal = 120f;
    [SerializeField] float viewAngleVertical = 120f;
    [SerializeField] float viewDist = 10f;

    PathMoveState pathDirection = PathMoveState.forward;

    NavMeshAgent meshAgent;

    RaycastHit hit;

    Vector3 directionTo;

    float distanceToNode = 0f;
    float distanceToPlayer = 0f;
    float playerAngleH = 0f;
    float playerAngleV = 0f;

    bool playerIsStealing = false;
    bool didHit = false;

    void Start()
    {
        meshAgent = GetComponent<NavMeshAgent>();
        directionTo = new Vector3();
        pathNodes = new Transform[path.childCount];

        for(int i = 0; i < path.childCount; i++)
        {
            pathNodes[i] = path.GetChild(i);
        }

        transform.position = pathNodes[0].position;
    }

    int currentNode = 1;
    void Update()
    {
        directionTo = (player.position - transform.position).normalized;
        playerAngleH = Quaternion.LookRotation(directionTo, Vector3.up).eulerAngles.y - transform.rotation.eulerAngles.y;
        playerAngleV = Quaternion.LookRotation(directionTo, Vector3.up).eulerAngles.x - transform.rotation.eulerAngles.x;
        distanceToPlayer = Vector3.Distance(player.position, transform.position);

        // correcting angle representation cus' it don't work like it should for some reason
        if (playerAngleH > 180f && playerAngleH <= 240f)
        {
            playerAngleH -= 360f;
        }

        //print("Vertical angle: " + playerAngleV + ", Horizontal angle: " + playerAngleH + "\nplayer distance: " + playerDist);

        SetStealingState();

        if (playerIsStealing)
        {
            print("player is stealing");
            // ChasePlayer();
        }
        else 
        {
            FollowPath();
        }

    }

    private void FollowPath()
    {
        //print("current node: " + currentNode);
        didHit = Physics.Raycast(transform.position, transform.forward, out hit, viewDist);
        if (!didHit || hit.distance >= 1f)
        {
            meshAgent.destination = new Vector3(pathNodes[currentNode].position.x, 
                pathNodes[currentNode].position.y + transform.position.y, 
                pathNodes[currentNode].position.z);
            CalculateDirection();
        }
        else
        {
            meshAgent.destination = transform.position;
        }
        
    }

    private void CalculateDirection()
    {
        distanceToNode = Vector3.Distance(
            new Vector3(transform.position.x, 0f, transform.position.z),
            new Vector3(meshAgent.destination.x, 0f, meshAgent.destination.z)
            );

        // print("distance to node: " + distanceToNode + ", current node: " + currentNode);
        if (distanceToNode > nodeDistanceCheck) return;

        if (pathDirection == PathMoveState.forward)
        {
            if (currentNode < pathNodes.Length - 1)
            {
                currentNode++;
            }
            else
            {
                pathDirection = PathMoveState.backward;
                currentNode--;
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
                currentNode++;
            }
        }
    }

    private void ChasePlayer()
    {
        throw new NotImplementedException();
    }

    public void SetPathNodesInEditor()
    {
        pathNodes = new Transform[path.childCount];

        for (int i = 0; i < path.childCount; i++)
        {
            pathNodes[i] = path.GetChild(i);
        }

        for (int i = 0; i < pathNodes.Length - 1; i++)
        {
            Debug.DrawLine(pathNodes[i].position, pathNodes[i + 1].position, Color.yellow);
        }
    }

    public void AlignNodesToGround()
    {
        RaycastHit hitGround;

        foreach(Transform node in pathNodes)
        {
            // RaycastUp:
            bool didHit = Physics.Raycast(node.position, Vector3.up, out hitGround, 10f);
            if (didHit == true) goto SetNodePos;

            didHit = Physics.Raycast(node.position, Vector3.down, out hitGround, 5f);
            if (didHit == false)
            {
                //print("No ground to align nodes to. ");
                return;
            }

            SetNodePos:
            if (hitGround.transform.tag == "Ground" || hitGround.transform.tag == "LandRaised" || hitGround.transform.tag == "LandRamp")
            {
                print(hitGround.point);
                node.position = new Vector3(node.position.x, hitGround.point.y + 0.04f, node.position.z);
            }
        }
        
    }

    private void SetStealingState()
    {
        didHit = Physics.Raycast(transform.position, directionTo, out hit, viewDist);
        if (didHit == false) return;

        // TODO if playerIsStealing will always be false in this condition, remove condition
        if (player.GetComponent<PlayerInteract>().holdingObject == false)
        {
            playerIsStealing = false;
            return;
        }

        if (distanceToNode < viewDist &&
            (playerAngleH + (viewAngleHorizontal / 2) < viewAngleHorizontal) &&
            player.GetComponent<PlayerInteract>().GetObjectInHand().tag == "Sheep" &&
            hit.transform.tag == "Player")
        {
            playerIsStealing = true;
        }
        else
        {
            playerIsStealing = false;
        }
    }
}
