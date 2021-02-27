using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepScore : MonoBehaviour
{
    [SerializeField] Transform[] sheeps;

    // Start is called before the first frame update
    void Start()
    {
        sheeps = new Transform[transform.childCount];
    }

    int currentChildCount = 0;
    int prevChildCount = 0;
    void Update()
    {
        CountSheep();
    }

    private void CountSheep()
    {
        currentChildCount = transform.childCount;

        if (currentChildCount != prevChildCount)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                sheeps[i] = transform.GetChild(i);
            }
        }

        prevChildCount = currentChildCount;
    }
}
