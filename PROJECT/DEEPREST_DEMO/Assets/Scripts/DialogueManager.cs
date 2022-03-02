using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText, messageText;
    public Animator dialogueAnimation;
    public Image textArrow;
    private Queue<string> lines, names;
    [HideInInspector] public bool ongoingDialogue;
    [HideInInspector] public bool textOngoing;
    [HideInInspector] public bool dialogueEnd;

    private void Awake() 
    {
        lines = new Queue<string>();
        names = new Queue<string>();
        textArrow.enabled = false;
    }

    void Start()
    {
        //lines = new Queue<string>();
        //names = new Queue<string>();
    }

    private void Update() {
        CheckDialogue();
        CheckArrowVisibility();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        ongoingDialogue = true;
        textOngoing = true;
        dialogueAnimation.SetBool("IsOpen", true);
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
        //nameText.text = nextName;
        if(nextName == "ç") nextName = GameInfoIO.ReadName().ToUpper();

        nameText.text = nextName;

        //messageText.text = nextLine;
        StopAllCoroutines();
        StartCoroutine(TypeLine(nextLine));
        
    }

    IEnumerator TypeLine(string line){
        float juicyWaiting = 0.01f;
        messageText.text = "";
        textOngoing = true;
        foreach(char letter in line.ToCharArray()){
            if(textOngoing){
                // Now lets make the text a little bit juicy
                if(letter == ',') juicyWaiting = 0.3525f;
                else if(letter == '.' || letter == '?' || letter == '!') juicyWaiting = 0.75f;
                else if(letter == '¡') 
                {
                    dialogueAnimation.SetTrigger("MoveText");
                }

                else if(letter == 'ç'){
                    messageText.text += GameInfoIO.ReadName();
                }

                else juicyWaiting = 0.01f;

                if(letter != 'ç') messageText.text += letter;

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
        dialogueEnd = false;
        dialogueAnimation.SetBool("IsOpen", false);
        Debug.Log("END OF THE DIALOGUE");
    }

    private void CheckDialogue(){
        /*
        ongoingDialogue = ongoingDialogue ? true : false;
        
        switch(ongoingDialogue){
            case true:
                if(Input.GetButtonDown("Jump")) DisplayNextLine();
                break;
        }
        */
        if(ongoingDialogue && textOngoing && Input.GetButtonDown("Fire1")){
            textOngoing = false;
        }
        else if(ongoingDialogue && !textOngoing && Input.GetButtonDown("Fire1")){
            DisplayNextLine();
        }
    }

    private void CheckArrowVisibility(){
        if(ongoingDialogue && !textOngoing){
            textArrow.enabled = true;
        } else{
            textArrow.enabled = false;
        }
    }

    private string GetDialogueNames(Dialogue dialogue)
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
