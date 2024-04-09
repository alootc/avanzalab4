using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private bool isMovable;
    [SerializeField] private string color;
    [SerializeField] private float speed;

    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;

    private bool isGoal;
    private Rigidbody2D rb;

    public string Color { get { return color; } }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (!isMovable) return;

        float disA = Vector2.Distance(transform.position, pointA.position);
        float disB = Vector2.Distance(transform.position, pointB.position);

        if (disA < 0.2f)
        {
            isGoal = true;
        }
        else if (disB < 0.2f)
        {
            isGoal = false;
        }

        Vector2 dir = pointB.position - transform.position;
        dir.Normalize();
        rb.velocity = dir * speed;
    }
}
