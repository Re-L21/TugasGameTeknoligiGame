using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public float speed = 80f;
    public float nextWaypointDist = 3f;

    //public GameObject deathEffect;
    public Transform target;
    public Transform enemyGFX;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    private void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }
    
    private void FixedUpdate()
    {
        if (path == null)
            return;

        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float disctance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if(disctance < nextWaypointDist)
        {
            currentWaypoint++;
        }

        if (force.x >= 0.01f)
            enemyGFX.localScale = new Vector3(1f, 1f, 1f);
        else if (force.x <= -0.01f)
            enemyGFX.localScale = new Vector3(-1f, 1f, 1f);

    }

    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


}
