using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;

    public Rigidbody2D rb;
    public GameObject hitEffect;

    private void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D hit)
    {

        Enemy enemy = hit.collider.GetComponent<Enemy>();

        if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, effect.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject);

    }
}
