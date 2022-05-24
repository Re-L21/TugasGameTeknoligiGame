using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public GameObject rayObstacle;
    public Camera cam;
    public SpriteRenderer sp;

    Vector2 movement;
    Vector2 mousePos;
    
    void Update()
    {
        RaycastHit2D obstacleDetected =  Physics2D.Raycast(rayObstacle.transform.position, -Vector2.up, 10f);
        Debug.DrawRay(rayObstacle.transform.position, -Vector2.up, Color.red);

        if (obstacleDetected.collider != null )
        {
            Debug.Log("behind");
            sp.sortingOrder = 0;
        }
        else
        {
            Debug.Log("in front");
            sp.sortingOrder = 2;
        }


        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

    }

    // need to fix rotation point for raycast 

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

}
