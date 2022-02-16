using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Usable : Interactable
{
    public DialogueTrigger dialogue;
    private bool playerCollision = false;
    public override void Interact()
    {
        dialogue.TriggerDialogue();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            other.GetComponent<PlayerMovement>().OpenInteractIcon();
            playerCollision = true;
        } 
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")){
            other.GetComponent<PlayerMovement>().CloseInteractIcon();
            playerCollision = false;
        }
    }
    private void Update() {
        CheckInteraction();
    }

    private void CheckInteraction(){
        if(playerCollision && Input.GetButtonDown("Fire1")) Interact();
    }
}
