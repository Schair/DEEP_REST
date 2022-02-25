using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarratorTrigger : MonoBehaviour
{
    public bool triggerAtStart;
    public float timeTillStart = 3.0f;
    public NarratorDialogue dialogue;
    
    

    public void TriggerDialogue()
    {
        FindObjectOfType<NarratorManager>().StartDialogue(dialogue);
    }
    void Start()
    {
        if(triggerAtStart) StartCoroutine(WaitToStart(timeTillStart));
        //TriggerDialogue();
        //FindObjectOfType<DialogueManager>().StartDialogue(this.dialogue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     IEnumerator WaitToStart(float time){
        yield return new WaitForSeconds(time);
        TriggerDialogue();
    }
}
