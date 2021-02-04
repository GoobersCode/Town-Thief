using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SetMainGround : MonoBehaviour
{
    [SerializeField] int gridSize = 8;
    [SerializeField] int gridScale = 4;

    Vector3 gridPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(gridSize * gridScale, gridScale, gridSize * gridScale);
        gridPos = new Vector3((gridSize - 1) * gridScale / 2f, -2f, (gridSize - 1) * gridScale / 2f);
        transform.position = gridPos;
    }
}
