using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public Transform target;
    public SpriteRenderer sp;
    public GameObject hit;

    void Update()
    {
        transform.position = new Vector2(target.position.x, target.position.y - 0.8f);

        RaycastHit2D rayHit = Physics2D.Raycast(hit.transform.position, -Vector2.up, 1f);
        Debug.DrawRay(hit.transform.position, -Vector2.up, Color.green);

        if (rayHit.collider != null)
        {
            Debug.DrawRay(hit.transform.position, -Vector2.up, Color.red);
            sp.sortingOrder = 0;
        }
        else
        {
            sp.sortingOrder = 2;
        }
    }
}
