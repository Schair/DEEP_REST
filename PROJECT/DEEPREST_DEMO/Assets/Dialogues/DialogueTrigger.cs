using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public bool triggerAtStart;
    public float timeTillStart;
    public Dialogue[] dialogue;
    private int currentDialogue = 0;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue[currentDialogue]);
    }

    public void TriggerCertainDialogue(int index){
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue[index]);
    }

    public void TriggerAndSetCertainDialogue(int index){
        currentDialogue = index;
        TriggerDialogue();
    }
    void Start()
    {
        if(triggerAtStart) StartCoroutine(WaitToStart());
    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<DialogueManager>().ongoingDialogue && FindObjectOfType<DialogueManager>().dialogueEnd){
            MoveToNextDialogue();
        }
    }

    private void MoveToNextDialogue(){
        FindObjectOfType<DialogueManager>().ongoingDialogue = false;
        FindObjectOfType<DialogueManager>().dialogueEnd = false;

        // let's assure that our currentDialogue variable never gets a value higher than the dialogue array size
        currentDialogue += ((currentDialogue + 1) < dialogue.Length) ? 1 : 0;
    }

    private IEnumerator WaitToStart(){
        triggerAtStart = false;
        yield return new WaitForSeconds(timeTillStart);
        TriggerDialogue();
    }

    public int GetCurrentDialogue(){
        return this.currentDialogue;
    }
}
