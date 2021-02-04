using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class VillagerPath : MonoBehaviour
{
    [SerializeField] Transform path;
    [SerializeField] Transform[] pathNodes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
}
