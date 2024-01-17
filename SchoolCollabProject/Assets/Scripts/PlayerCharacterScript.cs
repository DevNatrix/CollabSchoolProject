using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCharacterScript : MonoBehaviour
{
    [Header("Character Variables")]
    public float speed = 5f;
    public Rigidbody2D rb2d;
    public SpriteRenderer spriteRenderer;

    private void Update()
    {

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
