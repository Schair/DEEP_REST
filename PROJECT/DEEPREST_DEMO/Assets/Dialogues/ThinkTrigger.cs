using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThinkTrigger : MonoBehaviour
{
    public ThinkDialogue dialogue;
    

    public void TriggerDialogue()
    {
        FindObjectOfType<ThinkManager>().StartDialogue(dialogue);
    }
    void Start()
    {
        //TriggerDialogue();
    }

    void Update()
    {
        
    }
}
