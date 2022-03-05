using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{

    [Header("DIALOGUE COLLIDERS")] 
    [SerializeField] private Usable[] dialogueCollisions;
    [SerializeField] private UsableThink[] thinkCollisions;

    [Header("SCRIPTED MOVEMENT")]
    [SerializeField] public ScriptedMovement scriptedMovement;

    [Header("DIALOGUE TRIGGERS AND MANAGERS")]
    [SerializeField] private DialogueTrigger dialogueTrigger;
    [SerializeField] private ThinkTrigger thinkTrigger;
    public DialogueManager dialogueManager;
    public ThinkManager thinkManager;


    
    void Awake()
    {
        dialogueCollisions = FindObjectsOfType<Usable>();
        thinkCollisions = FindObjectsOfType<UsableThink>();

        scriptedMovement = FindObjectOfType<ScriptedMovement>();

        dialogueTrigger = FindObjectOfType<DialogueTrigger>();
        thinkTrigger = FindObjectOfType<ThinkTrigger>();

        dialogueManager = FindObjectOfType<DialogueManager>();
        thinkManager = FindObjectOfType<ThinkManager>();
    }
    void Start()
    {
        disableAllUsables();
    }

    void Update()
    {

    }

    public void disableAllUsables(){
        foreach(UsableThink coll in thinkCollisions){
            coll.disableUsable();
        }
        /*// TODO: create methods in Usable.cs
        foreach(Usable coll in dialogueCollisions){
            coll.disableUsable();
        }
        */
    }

    public void enableAllUsables(){
        foreach(UsableThink coll in thinkCollisions){
            coll.enableUsable();
        }
        /*// TODO: create methods in Usable.cs
        foreach(Usable coll in dialogueCollisions){
            coll.enableUsable();
        }
        */
    }

    public void Move(int dir, float sec){
        scriptedMovement.MoveCharacterCertainSeconds(dir, sec);
    }

    public void SetCharacterDirection(int dir){
        scriptedMovement.SetCharacterDirection(dir);
    }

    public void TriggerDialogue(){
        dialogueTrigger.TriggerDialogue();
    }

    public void TriggerThink(){
        thinkTrigger.TriggerDialogue();
    }
}
