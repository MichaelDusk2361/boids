using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidInstatiator : MonoBehaviour
{
    public GameObject boid;
    public int targetInstanceCount = 0;
    private int currentInstanceCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (; currentInstanceCount < targetInstanceCount; currentInstanceCount++)
        {
            Instantiate(boid, Vector3.zero, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(currentInstanceCount < targetInstanceCount)
        {
            Instantiate(boid, Vector3.zero, Quaternion.identity);
            currentInstanceCount++;
        }
    }
}
