using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrologueManager : MonoBehaviour
{
    [SerializeField] private Vector2[] movements;
    private int currentMovement = 0;
    public Camera mainCamera;
    public ThinkManager thinkManager;
    public ThinkTrigger thinkTrigger;
    public bool textEnter;
    private Vector3 camPos;
    void Awake()
    {
        camPos = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y,mainCamera.transform.position.z);
    }

    void Start()
    {

    }

    void Update()
    {
        mainCamera.transform.position = camPos;

        if(thinkManager.ongoingDialogue && thinkManager.dialogueEnd && (thinkTrigger.GetCurrentDialogue() + 1) < thinkTrigger.dialogue.Length){
            StartCoroutine(NextStep(0));
        }
        
        if(Input.GetButtonDown("Jump")){
            //NextCameraMovement();
        }
        
    }

    private void NextCameraMovement(){
        if(currentMovement < movements.Length){
            //MoveCameraTo(movements[currentMovement].x, movements[currentMovement].y);
            StartCoroutine(MoveCameraToInOneSec(movements[currentMovement].x, movements[currentMovement].y));
            currentMovement++;
        }
        else {
            Debug.Log("NO MORE CAMERA MOVEMENTS LEFT");
        }
    }

    private void MoveCameraTo(float x, float y){
        StartCoroutine(MoveCameraToInOneSec(x, y));
    }


    private IEnumerator MoveCameraToInOneSec(float x, float y){

        float xVariation = (Mathf.Round(((x - camPos.x) * 100.0f)) * 0.01f) * 0.01f;
        float yVariation = (Mathf.Round(((y - camPos.y) * 100.0f)) * 0.01f) * 0.01f;

        for (int i = 0; i < 100; i++)
        {
            camPos.x += xVariation;
            camPos.y += yVariation;
            yield return new WaitForSeconds(0.01f);
        }
        
        Debug.Log("CAMERA MOVEMENT ENDS");
    }

    private IEnumerator NextStep(int action){
        NextCameraMovement();
        yield return new WaitForSeconds(1.0f);
        switch(action){
            case 0:
                thinkTrigger.TriggerDialogue();
                break;
        }
        
    }
}
