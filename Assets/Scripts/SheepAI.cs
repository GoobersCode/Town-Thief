using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepAI : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    CharacterController c;

    Vector3 moveDirection;

    Quaternion newRotation;

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
        moveDirection = new Vector3(dirX, 0f, dirY);
        newRotation = Quaternion.LookRotation(moveDirection.normalized, transform.up);
        yield return new WaitForSeconds(Random.Range(5f, 8f));
        didWait = true;
    }

    void MoveSheep()
    {
        c.Move(moveDirection.normalized * Time.deltaTime * moveSpeed);
        transform.rotation = newRotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
