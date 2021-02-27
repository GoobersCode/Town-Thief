using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class VillagerPath : MonoBehaviour
{
    [SerializeField] VillagerAI villager;

    // Update is called once per frame
    void Update()
    {
        villager.SetPathNodesInEditor();
        
    }

    private void LateUpdate()
    {
        villager.AlignNodesToGround();
    }
}
