using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator iconAnimator;
    private Rigidbody2D rigidBody;
    private CircleCollider2D circleCollider;
    private float moveH, moveV;
    private Vector2 boxSize = new Vector2(0.1f, 1f);
    [SerializeField] private float moveSpeed = 2.0f;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();

    }

    private void Update() {
        if(Input.GetButtonDown("Fire1")) CheckInteraction();
    }

    private void FixedUpdate() 
    {
        moveH = Input.GetAxisRaw("Horizontal") * moveSpeed;
        moveV = Input.GetAxisRaw("Vertical") * moveSpeed;
        rigidBody.velocity = new Vector2(moveH, moveV);    

        Vector2 direction = new Vector2(moveH, moveV);
        FindObjectOfType<PlayerAnimation>().SetDirection(direction);
    }

    public void OpenInteractIcon() 
    {
        iconAnimator.SetBool("InteractableOpen", true);
    }

    public void CloseInteractIcon(){
        iconAnimator.SetBool("InteractableOpen", false);
    }

    

    private void CheckInteraction(){
        Debug.Log("SE HA PRESIONADO LA TECLA E");
        /*

        //RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, boxSize, 0, Vector2.zero);
        RaycastHit2D[] hits = Physics2D.CircleCastAll(rigidBody.transform.position, 0.5f, Vector2.zero);

        if(hits.Length > 0)
        {
            foreach(RaycastHit2D raycast in hits)
            {
                Debug.Log(raycast.transform.position);
                if(raycast.transform.GetComponent<Interactable>())
                {
                    raycast.transform.GetComponent<Interactable>().Interact();
                    return;
                }
            }
        }
        */
    }
    

}
