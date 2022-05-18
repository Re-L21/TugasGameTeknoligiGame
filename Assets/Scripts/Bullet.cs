using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collided");
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, effect.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject);
            
    }
}
