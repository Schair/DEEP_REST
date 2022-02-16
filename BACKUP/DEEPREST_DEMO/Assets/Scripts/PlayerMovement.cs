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

    private void FixedUpdate() 
    {
        moveH = Input.GetAxisRaw("Horizontal") * moveSpeed;
        moveV = Input.GetAxisRaw("Vertical") * moveSpeed;
        rigidBody.velocity = new Vector2(moveH, moveV);    

        Vector2 direction = new Vector2(moveH, moveV);
        FindObjectOfType<PlayerAnimation>().SetDirection(direction);
    }

    

}
