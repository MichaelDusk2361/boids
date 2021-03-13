using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boidMovement : MonoBehaviour
{
    public float speed = 1;
    public float radius = 0.1f;
    public float avoidanceWeight = 1f;
    
    private Camera main;

    // Start is called before the first frame update
    void Start()
    {
        main = Camera.main;
    }

    private bool isWrappingX = false;
    private bool isWrappingY = false;

    void ScreenWrap()
    {
        Vector3 viewPortPos = main.WorldToViewportPoint(transform.position);

        if (viewPortPos.x < 1 && viewPortPos.x > 0)
            isWrappingX = false;
        if (viewPortPos.y < 1 && viewPortPos.y > 0)
            isWrappingY = false;

        if (isWrappingX || isWrappingY)
            return;

        Vector3 newPos = transform.position;

        if (viewPortPos.x > 1.01 || viewPortPos.x < -0.01)
        {
            newPos.x = -newPos.x;
            isWrappingX = true;
        }

        if (viewPortPos.y > 1.01 || viewPortPos.y < -0.01)
        {
            newPos.y = -newPos.y;
            isWrappingY = true;
        }

        transform.position = newPos;
    }

  

    Collider2D[] getSurroundingBoids()
    {
        return Physics2D.OverlapCircleAll(transform.position, radius);
    }

    private void OnDrawGizmos()
    {
        Vector3 basePos = gameObject.transform.position;

        Gizmos.color = new Color(0.6f, 0.6f, 0.6f, 0.5f);
        Gizmos.DrawSphere(basePos, radius);

    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] boidColliders = getSurroundingBoids();
        Vector3 lookAt = Vector3.right;
        Vector3 avoidance = new Vector3(0,0,0);
        foreach (Collider2D boidCollider in boidColliders)
        {
            avoidance = boidCollider.gameObject.transform.position - transform.position;
            avoidance = avoidance.normalized;
        }

        lookAt -= avoidance * avoidanceWeight;

        if (Input.GetMouseButton(0))
            lookAt = main.ScreenToWorldPoint(Input.mousePosition) - transform.position;


        transform.rotation = Quaternion.LookRotation(Vector3.forward, lookAt);
        transform.Translate(Vector3.up * Time.deltaTime * speed);

        ScreenWrap();
        
    }
}
