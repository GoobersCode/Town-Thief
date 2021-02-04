using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    [SerializeField] new Camera camera;

    [SerializeField] float sheepRangeCheck = 4f;

    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(Physics.Raycast(camera.transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            //print("sheep is in range");
            //PickUpSheep();
        }

        
        //if (Vector3.Distance(transform.position, ))
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        // Gizmos.DrawLine(camera.transform.position, transform.forward * 100f);
    }

    private void PickUpSheep()
    {
        if (hit.collider.tag == "Sheep" && Input.GetMouseButtonDown(0) && Vector3.Distance(transform.position, hit.transform.position) < sheepRangeCheck)
        {
            print("picked up sheep");
        }
    }
}
