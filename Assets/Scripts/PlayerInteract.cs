using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [Header("Held Object Properties")]
    [SerializeField] float heldObjectOffsetY;

    [SerializeField] float heldObjectOffsetZ;

    [SerializeField] Vector3 heldObjectRot;

    [SerializeField] float sheepRangeCheck = 4f;

    public bool holdingObject = false;

    [Header("Camera")]
    [SerializeField] new Camera camera;



    Transform objectInHand;

    RaycastHit hit;

    
    bool didHit = false;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((didHit = Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, Mathf.Infinity)) == false) goto PutDownObject;

        print("Player pressed button: " + Input.GetMouseButtonDown(0));
        if (
            holdingObject == false &&
            Input.GetMouseButtonDown(0) && 
            hit.collider.tag == "HoldableObject" &&
            Vector3.Distance(transform.position, hit.transform.position) < sheepRangeCheck)
        {
            PickUpObject();
        }

        PutDownObject:
        if (Input.GetKeyDown(KeyCode.Q) && holdingObject)
        {
            PutDownObject();
        }

        if (holdingObject)
        {
            objectInHand.position = transform.position + (transform.forward * heldObjectOffsetZ) + (transform.up * heldObjectOffsetY);
            objectInHand.rotation = Quaternion.Euler(new Vector3(
                transform.rotation.eulerAngles.x + heldObjectRot.x,
                transform.rotation.eulerAngles.y + heldObjectRot.y,
                transform.rotation.eulerAngles.z + heldObjectRot.z));
        }
    }

    
    private void PutDownObject()
    {
        holdingObject = false;
        objectInHand.GetComponent<SheepAI>().isBeingHeld = false;
        objectInHand.transform.position += transform.forward * 2f;
        objectInHand = null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(camera.transform.position, camera.transform.forward * 100f);
    }

    private void PickUpObject()
    {
        holdingObject = true;
        objectInHand = hit.transform;

        if (!objectInHand)
        {
            Debug.Log("Can't hold object");
            return;
        }

        objectInHand.GetComponent<SheepAI>().isBeingHeld = true;
        
    }

    public Transform GetObjectInHand()
    {
        return objectInHand;
    }
}
