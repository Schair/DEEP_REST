using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PrologueManager : MonoBehaviour
{
    [SerializeField] private Vector2[] movements;
    private int currentMovement = 0;
    public Animator transition;
    public Animator canvasAnimation;
    public float transitionTime;
    public Camera mainCamera;
    public Canvas nameInput;
    public ThinkManager thinkManager;
    public ThinkTrigger thinkTrigger;
    [HideInInspector] public bool textEnter;
    [HideInInspector] public bool textEnterCouple;
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
            //StartCoroutine(NextStep(0));
            switch(thinkTrigger.GetCurrentDialogue()){
                case 0:
                    StartCoroutine(NextStep(1));
                    break;
                case 1:
                    StartCoroutine(NextStep(2));
                    break;
                default:
                    StartCoroutine(NextStep(0));
                    break;
            }
        }
        if(textEnter){
            textEnter = false;
            canvasAnimation.SetBool("IsOpen", false);
            StartCoroutine(NextStep(0));
        }
        if(textEnterCouple){
            textEnterCouple = false;
            canvasAnimation.SetBool("IsOpenCouple", false);
            StartCoroutine(NextStep(0));
        }
        if(thinkManager.ongoingDialogue && thinkManager.dialogueEnd && thinkTrigger.GetCurrentDialogue() + 1 == thinkTrigger.dialogue.Length){
            //StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
            LoadNextLevel();
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
        yield return new WaitForSeconds(1.5f);
        switch(action){
            case 0:
                thinkTrigger.TriggerDialogue();
                break;
            case 1:
                canvasAnimation.SetBool("IsOpen", true);
                break;
            case 2:
                canvasAnimation.SetBool("IsOpenCouple", true);
                break;
        }
    }

    public void LoadNextLevel(){
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex){
        // Play animation
        transition.SetTrigger("Start");
        // Wait
        yield return new WaitForSeconds(transitionTime);
        // Load Scene
        SceneManager.LoadScene(levelIndex);
    }
}
