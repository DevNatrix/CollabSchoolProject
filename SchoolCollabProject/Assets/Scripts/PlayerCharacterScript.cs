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
    private Transform direction;

    private void Start()
    {
        
    }

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
            transform.position += transform.right * speed * Time.deltaTime;
        }
        else if(spriteRenderer.flipX == true)
        {
            transform.position += -transform.right * speed * Time.deltaTime;
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
