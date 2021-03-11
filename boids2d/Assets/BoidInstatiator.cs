using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidInstatiator : MonoBehaviour
{
    public GameObject boid;
    public float spawnWidth = 100;
    public float spawnHeight = 100;
    public int targetInstanceCount = 0;

    private Vector3 topLeft;
    private Vector3 topRight;
    private Vector3 bottomLeft;
    private Vector3 bottomRight;
    private int currentInstanceCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 basePos = gameObject.transform.position;
        for (; currentInstanceCount < targetInstanceCount; currentInstanceCount++)
        {
            float spawnX = Random.Range(basePos.x - spawnWidth / 2, basePos.x + spawnWidth / 2);
            float spawnY = Random.Range(basePos.y - spawnHeight / 2, basePos.y + spawnHeight / 2);
            Instantiate(boid, new Vector3(spawnX, spawnY, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentInstanceCount < targetInstanceCount)
        {
            Vector3 basePos = gameObject.transform.position;
            float spawnX = Random.Range(basePos.x - spawnWidth / 2, basePos.x + spawnWidth / 2);
            float spawnY = Random.Range(basePos.y - spawnHeight / 2, basePos.y + spawnHeight / 2);
            Instantiate(boid, new Vector3(spawnX, spawnY, 0), Quaternion.identity);
            currentInstanceCount++;
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 basePos = gameObject.transform.position;
        topLeft = new Vector3(basePos.x - spawnWidth / 2, basePos.y + spawnHeight / 2, 0);
        topRight = new Vector3(basePos.x + spawnWidth / 2, basePos.y + spawnHeight / 2, 0);
        bottomLeft = new Vector3(basePos.x - spawnWidth / 2, basePos.y - spawnHeight / 2, 0);
        bottomRight = new Vector3(basePos.x + spawnWidth / 2, basePos.y - spawnHeight / 2, 0);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(topLeft, topRight);
        Gizmos.DrawLine(topRight, bottomRight);
        Gizmos.DrawLine(bottomRight, bottomLeft);
        Gizmos.DrawLine(bottomLeft, topLeft);
        Gizmos.DrawSphere(basePos, 0.2f);
    }
}


