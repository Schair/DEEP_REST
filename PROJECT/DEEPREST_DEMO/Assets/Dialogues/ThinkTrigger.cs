using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThinkTrigger : MonoBehaviour
{
    public bool triggerAtStart;
    public float timeTillStart;
    public ThinkDialogue[] dialogue;
    private int currentDialogue = 0;
    

    public void TriggerDialogue()
    {
        FindObjectOfType<ThinkManager>().StartDialogue(dialogue[currentDialogue]);
    }

    public void TriggerCertainDialogue(int index){
        FindObjectOfType<ThinkManager>().StartDialogue(dialogue[index]);
    }

    public void TriggerAndSetCertainDialogue(int index){
        currentDialogue = index;
        TriggerDialogue();
    }

    void Start()
    {
        if(triggerAtStart) StartCoroutine(WaitToStart());
    }

    void Update()
    {
        if(FindObjectOfType<ThinkManager>().ongoingDialogue && FindObjectOfType<ThinkManager>().dialogueEnd){
            MoveToNextDialogue();
        }
    }

    private void MoveToNextDialogue(){
        FindObjectOfType<ThinkManager>().ongoingDialogue = false;
        FindObjectOfType<ThinkManager>().dialogueEnd = false;

        // let's assure that our currentDialogue variable never gets a value higher than the dialogue array size
        currentDialogue += ((currentDialogue + 1) < dialogue.Length) ? 1 : 0;

        // Debug.Log(dialogue.Length + ", " + currentDialogue);
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
