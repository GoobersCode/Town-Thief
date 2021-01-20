using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerAI : MonoBehaviour
{
    [SerializeField] Transform player;

    CharacterController c;

    [SerializeField] float testAngle = 90f;

    [SerializeField] float testDist = 8f;

    float rotationToPlayer = 0f;

    float distFromVillager = 0f;

    // Start is called before the first frame update
    void Start()
    {
        c = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        rotationToPlayer = Quaternion.LookRotation(player.position - transform.position, Vector3.up).eulerAngles.y - transform.rotation.eulerAngles.y;
        distFromVillager = (player.position - transform.position).magnitude;

        if ((rotationToPlayer < testAngle && rotationToPlayer > -testAngle) && distFromVillager < testDist)
        {
            
            //print("rotation to player: " + rotationToPlayer);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.forward * 1000f);
    }
}
