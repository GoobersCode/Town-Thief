using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[ExecuteInEditMode]
[SelectionBase]
public class LandEditor : MonoBehaviour
{
    enum LandType
    {
        ramp,
        raised
    }

    [SerializeField] LandType landType;

    int gridSize = 4;

    // these offsets exist because I couldn't get the center of the imported models to be absolutely precise
    // TODO remove
    float offsetRampZ = -0.9487f;
    float offsetRampX = -0.005f;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int snapX = Mathf.RoundToInt(transform.position.x / gridSize);
        int snapZ = Mathf.RoundToInt(transform.position.z / gridSize);

        

        if (landType == LandType.ramp)
        {
            Vector3Int gridPos = new Vector3Int(snapX, 0, snapZ);
            transform.position = new Vector3((gridPos.x * gridSize) + offsetRampX, 0f, (gridPos.z * gridSize) + offsetRampZ + -1f);
        }
        else
        {
            Vector3Int gridPos = new Vector3Int(snapX, 2, snapZ);
            transform.position = new Vector3((gridPos.x * gridSize), gridPos.y, (gridPos.z * gridSize));
        }
    }
}
