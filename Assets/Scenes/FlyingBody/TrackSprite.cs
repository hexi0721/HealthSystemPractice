using UnityEngine;
using System;

public class TrackSprite : MonoBehaviour
{

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(h, v);
        float moveSpeed = 1f;
        rb.MovePosition(rb.position + move * moveSpeed * Time.deltaTime);
    }



}
