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
    [Header("SCENE VARIABLES")]
    public bool scene;
    [SerializeField] private int sceneNumber;
    [SerializeField] private int numberOfLines;
    [SerializeField] private float[] listOfWaiting; 
    public override void Interact()
    {
        Debug.Log(scene);
        if(!scene) dialogue.TriggerAndSetCertainDialogue(dialogueNumber);
        else StartCoroutine(sceneStart());
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

    private IEnumerator sceneStart(){
        switch(sceneNumber){
            case 0:
                dialogue.TriggerAndSetCertainDialogue(dialogueNumber);
                yield return new WaitUntil(() => dialogueManager.dialogueEnd);

                FindObjectOfType<FirstScene>().phone.SetBool("Visible", true);

                FindObjectOfType<PhoneMenu>().OpenMenu();

                yield return new WaitForSeconds(listOfWaiting[0]);

                FindObjectOfType<PhoneMenu>().CloseMenu();
                GameInfoIO.EnablePhone();
                yield return new WaitForSeconds(0.3f);
                
                for (int i = 1; i < numberOfLines; i++)
                {
                    dialogue.TriggerDialogue();
                    yield return new WaitUntil(() => dialogueManager.dialogueEnd);
                    yield return new WaitForSeconds(listOfWaiting[i]);
                }

                scene = false;
                FindObjectOfType<InGameManager>().scenes = false;
                break;
            default:
                Debug.Log("SCENE NOT FOUND");
                break;
        }
    }
}
