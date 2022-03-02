using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NarratorManager : MonoBehaviour
{
    public TextMeshProUGUI narratorText;
    public float timeBetweenLines = 3.0f;
    private CrossfadeAnimation crossfade;
    private Queue<string> lines;
    private bool ongoingDialogue = false, messageFinished = false;

    private void Awake() {
        lines = new Queue<string>();
        crossfade = FindObjectOfType<CrossfadeAnimation>();
    }

    void Start()
    {
        //lines = new Queue<string>();
    }

    private void Update() {
        CheckDialogue();
    }

    public void StartDialogue(NarratorDialogue dialogue)
    {
        ongoingDialogue = true;

        // Debugging purposes
        Debug.Log("NARRATION STARTING...");

        lines.Clear();

        foreach(string line in dialogue.lines)
        {
            lines.Enqueue(line);
        }

        DisplayNextLine();
    }

    public void DisplayNextLine(){
        if(lines.Count == 0)
        {
            ongoingDialogue = false;
            EndDialogue();
            return;
        }

        string nextLine = lines.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeLine(nextLine));
        
    }

    IEnumerator TypeLine(string line){
        float juicyWaiting = 0.03f;
        narratorText.text = "";
        foreach(char letter in line.ToCharArray()){
            narratorText.text += letter;

            // Now lets make the text a little bit juicy
            if(letter == ',') juicyWaiting = 1.0f;
            else if(letter == '.' || letter == '?' || letter == '!') juicyWaiting = 1.75f;
            else juicyWaiting = 0.03f;

            
            // The text writes itself with different timings depending on the char that has been written
            yield return new WaitForSeconds(juicyWaiting);
        }
        messageFinished = true;
    }

    public void EndDialogue(){
        Debug.Log("End of the dialogue");
        narratorText.text = "";
        crossfade.startFade = true;
    }

    private void CheckDialogue(){
        ongoingDialogue = ongoingDialogue ? true : false;
        
        switch(ongoingDialogue){
            case true:
            StartCoroutine(WaitForNextLine(timeBetweenLines));
                //if(Input.GetButtonDown("Jump")) DisplayNextLine();
                //DisplayNextLine();
                break;
        }
    }

    IEnumerator WaitForNextLine(float time){
        if(messageFinished)
        {
            messageFinished = false;
            yield return new WaitForSeconds(time);
            DisplayNextLine();
        }
        
    }
}
