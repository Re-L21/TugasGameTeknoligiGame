using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    public float speed;
    public float minDistance;
    public float timeBetweenShots;
    public float projectileForce;

    private float nextShotTime;

    public Transform target;
    public Transform firePoint;
    public GameObject projectile;
    public Rigidbody2D playerPos;
    public Rigidbody2D rb;


    private void Update()
    {
        if(Time.time > nextShotTime)
            Shoot();

        if(Vector2.Distance(transform.position, target.position) < minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);

        }
    }

    private void FixedUpdate()
    {
        Vector2 lookDir = playerPos.position - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(projectile, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(firePoint.up * projectileForce, ForceMode2D.Impulse);
        nextShotTime = Time.time + timeBetweenShots;
    }
}
