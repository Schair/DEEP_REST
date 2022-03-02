using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameInputMenu : MonoBehaviour
{
    public Animator anim;
    public Image errorBox;
    public TMP_InputField textName;
    public TMP_InputField textNameCouple;
    private string[] nameToWrite;
    
    void Awake()
    {
        anim.SetBool("ErrorOpen", false);
        textName.characterLimit = 8;
        nameToWrite = new string[2];
    }

    void Update()
    {

    }

    public void SetName(){
        if(textName.text == null || textName.text == ""){
            StartCoroutine(ShowErrorBox());
        } else{
            StartCoroutine(SetNameAndContinue());
        }
    }

    public void SetCoupleName(){
        if(textNameCouple.text == null || textNameCouple.text == ""){
            StartCoroutine(ShowErrorBoxCouple());
        } else{
            StartCoroutine(SetNameAndContinueCouple());
        }
    }

    private IEnumerator ShowErrorBox(){
        anim.SetBool("ErrorOpen", true);
        yield return new WaitForSeconds(2.0f);
        anim.SetBool("ErrorOpen", false);
    }

    private IEnumerator ShowErrorBoxCouple(){
        anim.SetBool("ErrorOpenCouple", true);
        yield return new WaitForSeconds(2.0f);
        anim.SetBool("ErrorOpenCouple", false);
    }

    private IEnumerator SetNameAndContinue(){
        nameToWrite[0] =  textName.text;
        GameInfoIO.WriteGameInfo(nameToWrite);
        yield return new WaitForSeconds(0.25f);
        //anim.SetBool("ErrorOpen", false);
        FindObjectOfType<PrologueManager>().textEnter = true;
    }

    private IEnumerator SetNameAndContinueCouple(){
        nameToWrite[1] =  textNameCouple.text;
        GameInfoIO.WriteGameInfo(nameToWrite);
        yield return new WaitForSeconds(0.25f);
        //anim.SetBool("ErrorOpenCouple", false);
        FindObjectOfType<PrologueManager>().textEnterCouple = true;
    }
}
