using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : PhysicsObject
{
    [SerializeField] private float maxSpeed;
    private RaycastHit2D rightLedgeRaycastHit;
    private RaycastHit2D leftLedgeRaycastHit;
    [SerializeField] private Vector2 rayCastOffset;
    [SerializeField] private float rayCastLength =2;

    void Update()
    {
        targetVelocity = new Vector2(maxSpeed, 0);
        rightLedgeRaycastHit = Physics2D.Raycast(new Vector2(transform.position.x + rayCastOffset.x, transform.position.y + rayCastOffset.y), Vector2.down, rayCastLength);
        Debug.DrawRay(new Vector2(transform.position.x + rayCastOffset.x, transform.position.y + rayCastOffset.y), Vector2.down * rayCastLength, Color.blue);

        leftLedgeRaycastHit = Physics2D.Raycast(new Vector2(transform.position.x -rayCastOffset.x, transform.position.y -rayCastOffset.y), Vector2.down, rayCastLength);
        Debug.DrawRay(new Vector2(transform.position.x -rayCastOffset.x, transform.position.y -rayCastOffset.y), Vector2.down * rayCastLength, Color.blue);
    }
}
