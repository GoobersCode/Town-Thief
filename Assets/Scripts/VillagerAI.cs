using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerAI : MonoBehaviour
{
    enum MoveState
    {
        forward,
        backward
    }

    enum MovePattern
    {
        backAndForth,
        curcuit
    }

    [SerializeField] Transform player;

    [SerializeField] Transform[] path;

    [SerializeField] MovePattern movePattern1 = MovePattern.backAndForth;

    CharacterController c;

    [SerializeField] float moveSpeed = 1f;

    [Tooltip("The angle to check against to see if player is in the field of view")]
    [SerializeField] float testAngle = 90f;

    [Tooltip("The distance to check against to see if the player is in range")]
    [SerializeField] float testDist = 8f;

    // The 'y' rotation of the player from the enemy
    float rotationToPlayer = 0f;

    // The distance from the enemy
    float distFromVillager = 0f;

    int currentNode = 0;

    Vector3 dirToNextNode;

    float distToNextNode;

    float prevDist = 0f;

    MoveState curMoveState;

    // Start is called before the first frame update
    void Start()
    {
        SetDistToNextNode();
        prevDist = distToNextNode;
        curMoveState = MoveState.forward;
        c = GetComponent<CharacterController>();
        transform.position = SetXZPosition(path[0].position, transform.position.y);
        dirToNextNode = (path[currentNode + 1].localPosition - path[currentNode].localPosition).normalized;
        transform.rotation = Quaternion.LookRotation(dirToNextNode, Vector3.up);
    }

    // Update is called once per frame
    void Update()
    {

        rotationToPlayer = Quaternion.LookRotation(player.position - transform.position, Vector3.up).eulerAngles.y - transform.rotation.eulerAngles.y;
        distFromVillager = (player.position - transform.position).magnitude;

        if ((rotationToPlayer < testAngle && rotationToPlayer > -testAngle) && distFromVillager < testDist)
        {
            // when the villager spots the player

        }

        MoveVillagerAlongPath();
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for(int i = 0; i < path.Length - 1; i++)
        {
            Gizmos.DrawLine(path[i].position, path[i+1].position);
        }
    }

    // sets the 'x' and 'z' position of this transform. the 'y' is the 'y' position of the Vector3 being set.
    private Vector3 SetXZPosition(Vector3 pos, float y)
    {
        return new Vector3(pos.x, y, pos.z);
    }

    // distance from 'transform.localPosition' to 'toPos'
    private Vector3 GetXZDistance(Vector3 toPos)
    {
        return new Vector3(toPos.x - transform.localPosition.x, 0, toPos.z - transform.localPosition.z);
    }

    private void MoveVillagerAlongPath()
    {
        SetDistToNextNode();

        if (distToNextNode > prevDist)
        {
            ChangeDirection();
            SetDistToNextNode();
            transform.localPosition = SetXZPosition(path[currentNode].localPosition, transform.localPosition.y);
            transform.rotation = Quaternion.LookRotation(dirToNextNode, Vector3.up);
        }

        // test //



        // end test //
        
        print("new direction: " + dirToNextNode +
                  ", current node: " + currentNode +
                  "\ncurrent move state: " + curMoveState +
                  ", distance to next node: " + distToNextNode
                  );

        prevDist = distToNextNode;
        print(c.Move(dirToNextNode * Time.deltaTime * moveSpeed));
    }

    private void ChangeDirection()
    {
        if (curMoveState == MoveState.forward)
        {
            MakeDirectionForward();
        }
        else if (curMoveState == MoveState.backward)
        {
            MakeDirectionBackward();
        }
    }

    private void MakeDirectionForward()
    {
        currentNode++;
        if (currentNode < path.Length - 1)
        {
            dirToNextNode = (path[currentNode + 1].localPosition - path[currentNode].localPosition).normalized;
        }
        else
        {
            curMoveState = MoveState.backward;
            dirToNextNode = (path[currentNode - 1].localPosition - path[currentNode].localPosition).normalized;
        }
    }

    private void MakeDirectionBackward()
    {
        currentNode--;
        if (currentNode > 0)
        {
            dirToNextNode = (path[currentNode - 1].localPosition - path[currentNode].localPosition).normalized;
        }
        else
        {
            curMoveState = MoveState.forward;
            dirToNextNode = (path[currentNode + 1].localPosition - path[currentNode].localPosition).normalized;
        }
    }

    private void SetDistToNextNode()
    {
        if (curMoveState == MoveState.forward)
        {
            if (currentNode < path.Length - 1)
            {
                distToNextNode = GetXZDistance(path[currentNode + 1].localPosition).magnitude;
            }
        }
        else if (curMoveState == MoveState.backward)
        {
            if (currentNode > 0)
            {
                distToNextNode = GetXZDistance(path[currentNode - 1].localPosition).magnitude;
            }
        }
    }
}
