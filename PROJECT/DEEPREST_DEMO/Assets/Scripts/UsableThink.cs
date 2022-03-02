using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsableThink : Interactable
{
    [Header("COMPONENTS")][SerializeField]
    public ThinkTrigger dialogue;
    public ThinkManager dialogueManager;
    [Header("DIALOGUE VARIABLES")][SerializeField]
    public int dialogueNumber;

    [Header("INTERACTION STATE")][SerializeField]
    public bool disableInteraction;
    private Collider2D playerCollider;
    private bool playerCollision = false;
    public override void Interact()
    {
        dialogue.TriggerAndSetCertainDialogue(dialogueNumber);
    }

    public void disableUsable(){
        disableInteraction = true;
    }

    public void enableUsable(){
        disableInteraction = false;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && !disableInteraction){
            playerCollider = other;
            other.GetComponent<PlayerMovement>().OpenInteractIcon();
            playerCollision = true;
        } 
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player") && !disableInteraction){
            playerCollider = new Collider2D();
            other.GetComponent<PlayerMovement>().CloseInteractIcon();
            playerCollision = false;
        }
    }
    private void Update() {
        CheckInteraction();
    }

    private void CheckInteraction(){
        if(playerCollision && Input.GetButtonDown("Fire1") && !dialogueManager.ongoingDialogue && !disableInteraction) {
            playerCollider.GetComponent<PlayerMovement>().CloseInteractIcon();
            Interact();
        }
    }
}
