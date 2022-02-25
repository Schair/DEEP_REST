using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsableThink : Interactable
{
    public ThinkTrigger dialogue;
    public ThinkManager dialogueManager;
    private Collider2D playerCollider;
    private bool playerCollision = false;
    public override void Interact()
    {
        dialogue.TriggerDialogue();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            playerCollider = other;
            other.GetComponent<PlayerMovement>().OpenInteractIcon();
            playerCollision = true;
        } 
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")){
            playerCollider = new Collider2D();
            other.GetComponent<PlayerMovement>().CloseInteractIcon();
            playerCollision = false;
        }
    }
    private void Update() {
        CheckInteraction();
    }

    private void CheckInteraction(){
        if(playerCollision && Input.GetButtonDown("Fire1") && !dialogueManager.ongoingDialogue) {
            playerCollider.GetComponent<PlayerMovement>().CloseInteractIcon();
            Interact();
        }
    }
}
