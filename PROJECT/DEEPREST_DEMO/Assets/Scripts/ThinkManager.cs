using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ThinkManager : MonoBehaviour
{
    public TextMeshProUGUI nameText, messageText;
    public Animator thinkAnimation;
    private Queue<string> lines, names;
    public bool ongoingDialogue;
    public bool textOngoing;
    public bool dialogueEnd;
    private void Awake() 
    {
        lines = new Queue<string>();
        names = new Queue<string>();
        
    }

    void Start()
    {
        
    }

    private void Update() {
        CheckDialogue();
    }

    public void StartDialogue(ThinkDialogue dialogue)
    {
        ongoingDialogue = true;
        textOngoing = true;
        thinkAnimation.SetBool("IsOpen", true);
        // Debugging purposes
        string dialogueNames = GetDialogueNames(dialogue);
        Debug.Log("STARTING CONVERSATION WITH " + dialogueNames);

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
        textOngoing = true;
        foreach(char letter in line.ToCharArray()){
            if(textOngoing){
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
            else{
                messageText.text += letter;
            }
        }
        textOngoing = false;
    }

    public void EndDialogue(){
        //ongoingDialogue = false;
        dialogueEnd = true;
        thinkAnimation.SetBool("IsOpen", false);
        Debug.Log("END OF THE DIALOGUE ");
    }

    private void CheckDialogue(){
        if(ongoingDialogue && textOngoing && Input.GetButtonDown("Fire1")) {
            textOngoing = false;
            Debug.Log("MESSAGE WAS BEING WRITTEN");
        } else if (ongoingDialogue && !textOngoing && Input.GetButtonDown("Fire1")){
            DisplayNextLine();
            Debug.Log("MESSAGE HAD FINISHED");
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
