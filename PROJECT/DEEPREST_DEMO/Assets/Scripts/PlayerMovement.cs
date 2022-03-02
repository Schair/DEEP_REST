using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator iconAnimator;
    [HideInInspector] public Rigidbody2D rigidBody;
    private CircleCollider2D circleCollider;
    public bool disableMovement;
    private float moveH, moveV;
    [SerializeField] public float moveSpeed = 2.0f;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();

    }

    private void Update() {

    }

    private void FixedUpdate() 
    {
        if(!disableMovement){
            moveH = Input.GetAxisRaw("Horizontal") * moveSpeed;
            moveV = Input.GetAxisRaw("Vertical") * moveSpeed;
            rigidBody.velocity = new Vector2(moveH, moveV);    

            Vector2 direction = new Vector2(moveH, moveV);
            FindObjectOfType<PlayerAnimation>().SetDirection(direction);
        }
    }

    public void OpenInteractIcon() 
    {
        iconAnimator.SetBool("InteractableOpen", true);
    }

    public void CloseInteractIcon(){
        iconAnimator.SetBool("InteractableOpen", false);
    }

}
