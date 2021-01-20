using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepAI : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    CharacterController c;

    Vector3 moveDirection;

    bool didWait = true;

    float dirX = 0f;
    float dirY = 0f;
    
    void Start()
    {
        c = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (didWait)
        {
            StartCoroutine(CalculateMoveDirection());
        }

        MoveSheep();
    }

    IEnumerator CalculateMoveDirection()
    {
        didWait = false;
        dirX = Random.Range(-1.0f, 1.0f);
        dirY = Random.Range(-1.0f, 1.0f);
        moveDirection = new Vector3(dirX * moveSpeed * Time.deltaTime, transform.position.y, dirY * moveSpeed * Time.deltaTime);
        print(dirX + ", " + dirY);
        print("Move direction: " + moveDirection + ", Up direction: " + transform.up);
        Quaternion.LookRotation(moveDirection.normalized, transform.up);
        yield return new WaitForSeconds(5f);
        didWait = true;
    }

    void MoveSheep()
    {
        c.Move(moveDirection);
    }
}
