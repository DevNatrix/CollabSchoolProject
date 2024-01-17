using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCharacterScript : MonoBehaviour
{
    [Header("Character Variables")]
    public float speed = 5f;
    public Rigidbody2D rb2d;
    private Vector2 direction;

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

}
