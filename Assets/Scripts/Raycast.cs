using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public SpriteRenderer sp;
    public GameObject rayObstacle;
    public Transform target;

    void Update()
    {
        //transform.Translate(target.position.x, -0.5f, target.position.z);

        transform.position = new Vector2(target.position.x, target.position.y - 0.6f);

        RaycastHit2D obstacleDetected = Physics2D.Raycast(rayObstacle.transform.position, -Vector2.up, 10f);
        Debug.DrawRay(rayObstacle.transform.position, -Vector2.up, Color.green);


        if (obstacleDetected.collider != null && obstacleDetected.collider != GameObject.FindWithTag("Player"))
        {
            Debug.DrawRay(rayObstacle.transform.position, -Vector2.up, Color.red);
            Debug.Log("Ray Hit: " + obstacleDetected.transform.name);
            //Debug.Log("Obstacle");
            sp.sortingOrder = 0;
        }
        else
        {
            //Debug.Log("Ray Hit: " + obstacleDetected.transform.name);
            //Debug.Log("player");
            sp.sortingOrder = 2;
        }

    }
}
