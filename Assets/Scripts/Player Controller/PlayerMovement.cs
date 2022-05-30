using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator anim;
    public Transform firePoint;
    public Transform interactor;
    public GameObject arrowPrefab;

    Vector2 movement;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("Horizontal", movement.x); 
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);

        if(Input.GetAxisRaw("Horizontal")==1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            anim.SetFloat("LastHorizontal", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("LastVertical", Input.GetAxisRaw("Vertical"));
        }

        if (Input.GetAxisRaw("Horizontal") > 0)
            interactor.localRotation = Quaternion.Euler(0, 0, 0);
        else if (Input.GetAxisRaw("Horizontal") < 0)
            interactor.localRotation = Quaternion.Euler(0, 0, 180);
        else if (Input.GetAxisRaw("Vertical") > 0)
            interactor.localRotation = Quaternion.Euler(0, 0, 90);
        else if (Input.GetAxisRaw("Vertical") < 0)
            interactor.localRotation = Quaternion.Euler(0, 0, -90);

        if(anim.GetFloat("Speed") < 0.01)
        {
            if (Input.GetButtonDown("Fire1") && !anim.GetBool("Attack"))
                anim.SetBool("Attack", true);
            else
                anim.SetBool("Attack", false);
        }

        if (anim.GetBool("Attack"))
            Shoot();

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }
    
    void Shoot()
    {
        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
    }

}
