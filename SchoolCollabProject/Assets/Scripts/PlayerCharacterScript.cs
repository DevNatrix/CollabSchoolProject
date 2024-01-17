using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerCharacterScript : MonoBehaviour
{
    [Header("Character Variables")]
    public float speed = 5f;
    public float jumpForce = 5f;
    public Rigidbody2D rb2d;
    public SpriteRenderer spriteRenderer;
    public bool Grounded;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        CheckIfGrounded();
    }

    private void CheckIfGrounded()
    {
        RaycastHit hit;
        Ray landingRay = new Ray(transform.position, Vector3.down);
        Debug.DrawRay(transform.position, Vector3.down * 5);

        if (Physics.Raycast(landingRay, out hit, 5))
        {
            if (hit.collider == null)
            {
                Grounded = false;
                Debug.Log(Grounded);
            }
            else
            {
                Grounded = true;
                Debug.Log(Grounded);
            }

        }
    }

    private void Jump()
    {
        if(Grounded)
        {
            rb2d.AddForce(Vector2.up * jumpForce * Time.deltaTime, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if(spriteRenderer.flipX == false)
        {
            transform.position += transform.right * speed * Time.fixedDeltaTime;
        }

        if (spriteRenderer.flipX == transform)
        {
            transform.position += -transform.right * speed * Time.fixedDeltaTime;
        }
    }

    void FlipSprite()
    {
        if(spriteRenderer.flipX == true)
        {
            spriteRenderer.flipX = false;
        }

        if(spriteRenderer.flipX == false)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("RightWall"))
        {
            spriteRenderer.flipX = true;
        }

        if(collision.gameObject.CompareTag("LeftWall"))
        {
            spriteRenderer.flipX = false;
        }
    }

}
