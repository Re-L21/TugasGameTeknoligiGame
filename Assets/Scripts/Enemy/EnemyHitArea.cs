using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitArea : MonoBehaviour
{
    public int damage = 25;
    private float lastDmg = 0;

    private void OnTriggerStay2D(Collider2D hit)
    {
        Player player = hit.GetComponent<Player>();

        if (player != null)
        {
            lastDmg += Time.deltaTime;
            if(lastDmg >= 0.6f)
            {
                player.TakeDamage(damage);
                lastDmg = 0;
            }
        }

    }

}
