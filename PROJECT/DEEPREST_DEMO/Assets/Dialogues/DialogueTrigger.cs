using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public bool triggerAtStart;
    public float timeTillStart;
    public Dialogue dialogue;
    
    

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
    void Start()
    {
        if(triggerAtStart) StartCoroutine(WaitToStart());
        //TriggerDialogue();
        //FindObjectOfType<DialogueManager>().StartDialogue(this.dialogue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator WaitToStart(){
        yield return new WaitForSeconds(timeTillStart);
        TriggerDialogue();
    }
}
