using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ThinkManager : MonoBehaviour
{
    public TextMeshProUGUI nameText, messageText;
    public Animator thinkAnimation;
    private Queue<string> lines, names;
    private bool ongoingDialogue = false;
    private void Awake() 
    {
        lines = new Queue<string>();
        names = new Queue<string>();
    }

    void Start()
    {
        //lines = new Queue<string>();
        //names = new Queue<string>();
    }

    private void Update() {
        CheckDialogue();
    }

    public void StartDialogue(ThinkDialogue dialogue)
    {
        ongoingDialogue = true;
        thinkAnimation.SetBool("IsOpen", true);
        // Debugging purposes
        string dialogueNames = GetDialogueNames(dialogue);
        Debug.Log("Starting conversation with " + dialogueNames);

        lines.Clear();
        names.Clear();

        foreach(string line in dialogue.lines)
        {
            lines.Enqueue(line);
        }
        foreach(string name in dialogue.names)
        {
            names.Enqueue(name);
        }

        DisplayNextLine();
    }

    public void DisplayNextLine(){
        if(lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        string nextLine = lines.Dequeue();
        string nextName = names.Dequeue();
        //Debug.Log(nextLine);
        nameText.text = nextName;
        //messageText.text = nextLine;
        StopAllCoroutines();
        StartCoroutine(TypeLine(nextLine));
        
    }

    IEnumerator TypeLine(string line){
        float juicyWaiting = 0.02f;
        messageText.text = "";
        foreach(char letter in line.ToCharArray()){
            messageText.text += letter;

            // Now lets make the text a little bit juicy
            if(letter == ',') juicyWaiting = 0.3525f;
            else if(letter == '.' || letter == '?' || letter == '!') juicyWaiting = 0.75f;
            else if(letter == '¡') 
            {
                thinkAnimation.SetTrigger("MoveText");
            }
            else juicyWaiting = 0.02f;

            
            // The text writes itself with different timings depending on the char that has been written
            yield return new WaitForSeconds(juicyWaiting);
        }
    }

    public void EndDialogue(){
        ongoingDialogue = false;
        thinkAnimation.SetBool("IsOpen", false);
        Debug.Log("End of the dialogue");
    }

    private void CheckDialogue(){
        ongoingDialogue = ongoingDialogue ? true : false;
        
        switch(ongoingDialogue){
            case true:
                if(Input.GetButtonDown("Jump")) DisplayNextLine();
                break;
        }
    }

    private string GetDialogueNames(ThinkDialogue dialogue)
    {
        List<string> names = new List<string>();
        foreach(string name in dialogue.names){
            if (!names.Contains(name) || names.Count == 0) names.Add(name);
        }
        string rNames = "";
        foreach(string name in names){
            rNames += name + " ";
        }
        return rNames;
    }
}
