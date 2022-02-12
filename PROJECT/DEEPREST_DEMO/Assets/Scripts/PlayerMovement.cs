using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private float moveH, moveV;
    [SerializeField] private float moveSpeed = 2.0f;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        moveH = Input.GetAxisRaw("Horizontal") * moveSpeed;
        moveV = Input.GetAxisRaw("Vertical") * moveSpeed;
    }

    private void FixedUpdate() 
    {
        rigidBody.velocity = new Vector2(moveH, moveV);    
    }
}
