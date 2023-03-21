using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : PhysicsObject
{
    [Header("Attributes")]

    [SerializeField] private int attackPower = 10;
    private int direction = 1;
    [SerializeField] private float maxSpeed;
    public int health = 100;
    private int maxHealth = 100;

    [Header("Raycast")]

    private RaycastHit2D rightLedgeRaycastHit;
    private RaycastHit2D leftLedgeRaycastHit;
    private RaycastHit2D rightWallRaycastHit;
    private RaycastHit2D leftWallRaycastHit;
    [SerializeField] private LayerMask raycastlayerMask;
    [SerializeField] private Vector2 rayCastOffset;
    [SerializeField] private float rayCastLength =1.5f;

    void Update()
    {
        targetVelocity = new Vector2(maxSpeed*direction, 0);

        //check for right ledge
        rightLedgeRaycastHit = Physics2D.Raycast(new Vector2(transform.position.x + rayCastOffset.x, transform.position.y + rayCastOffset.y), Vector2.down, rayCastLength);
        Debug.DrawRay(new Vector2(transform.position.x + rayCastOffset.x, transform.position.y + rayCastOffset.y), Vector2.down * rayCastLength, Color.blue);
        if(rightLedgeRaycastHit.collider == null)
        {
            direction = -1;
        }
       
        //check for left ledge
        leftLedgeRaycastHit = Physics2D.Raycast(new Vector2(transform.position.x -rayCastOffset.x, transform.position.y -rayCastOffset.y), Vector2.down, rayCastLength);
        Debug.DrawRay(new Vector2(transform.position.x -rayCastOffset.x, transform.position.y -rayCastOffset.y), Vector2.down * rayCastLength, Color.blue);
        if (leftLedgeRaycastHit.collider == null)
        {
            direction = 1;
        }

        //check for right wall
        rightWallRaycastHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.right, rayCastLength, raycastlayerMask);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y), Vector2.right* rayCastLength, Color.red);
        if (rightWallRaycastHit.collider != null)
        {
            direction = -1;
        }       

        //check for left wall
        leftWallRaycastHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.left, rayCastLength, raycastlayerMask);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y), Vector2.left * rayCastLength, Color.red);
        if (leftWallRaycastHit.collider != null)
        {
            direction = 1;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == NewPlayer.Instance.gameObject)
        {
            NewPlayer.Instance.health -= attackPower;
            NewPlayer.Instance.UpdateUI();
        }
    }
}
