using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 2f;          // Horizontal speed
    public float moveDistance = 1f;   // Patrol distance from start position

    private Rigidbody2D rb;
    private float leftBoundary;
    private float rightBoundary;
    private int direction = 1;        // 1 = right, -1 = left

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        float startX = transform.position.x;
        leftBoundary = startX - moveDistance;
        rightBoundary = startX + moveDistance;
        
        transform.rotation = Quaternion.Euler(0f, 180f, 0f);
    }

    void FixedUpdate()
    {
        // Move horizontally using physics
        rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);

        // Flip direction smoothly at boundaries and rotate
        if (direction > 0 && transform.position.x >= rightBoundary)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            direction = -1;
        }
        else if (direction < 0 && transform.position.x <= leftBoundary)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            direction = 1;
        }
    }
}
