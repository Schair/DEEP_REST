using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstScene : MonoBehaviour
{
    private bool sceneEnd;
    private int dirPointer;
    private int secPointer;
    
    public InGameManager inGameManager;
    [Header("SCRIPTED MOVEMENT")]
    [SerializeField] [Tooltip("[0 N], [1 NE], [2 E], [3 SE],\n[4 S], [5 SW], [6 W], [7 NW]")]
    private int[] directionsToMove;
    [SerializeField] private float[] secondsToMove;
    [Header("AUXILIAR ANIMATORS")]
    public Animator phone;
    void Awake()
    {
        inGameManager = FindObjectOfType<InGameManager>();

        dirPointer = 0;
        secPointer = 0;

    }
    void Start()
    {
        inGameManager.DisableAllUsables();
        StartCoroutine(FirstSceneStep());
    }
    void Update()
    {

    }

    private void UpdateDirections(){
        if(dirPointer + 1 < directionsToMove.Length) dirPointer++;
        //Debug.Log("CURRENT DIRECTION: " + directionsToMove[dirPointer] + "\nPOINTER: " + dirPointer);
    }

    private void UpdateSeconds(){
        if(secPointer + 1 < secondsToMove.Length) secPointer++;
        //Debug.Log("CURRENT SECONDS: " + secondsToMove[secPointer] + "\nPOINTER: " + secPointer);
    }
    
    private IEnumerator FirstSceneStep(){
        inGameManager.Move(directionsToMove[dirPointer], secondsToMove[secPointer]);
        UpdateDirections();

        yield return new WaitForSeconds(secondsToMove[secPointer]);
        UpdateSeconds();

        inGameManager.DisableMovement();
        yield return new WaitForSeconds(1.0f);
        inGameManager.TriggerThink();
        yield return new WaitUntil(() => inGameManager.thinkManager.dialogueEnd);

        inGameManager.Move(directionsToMove[dirPointer], secondsToMove[secPointer]);
        UpdateDirections();

        yield return new WaitForSeconds(secondsToMove[secPointer]);
        UpdateSeconds();

        inGameManager.SetCharacterDirection(directionsToMove[dirPointer]);
        UpdateDirections();

        yield return new WaitForSeconds(1.0f);

        phone.SetTrigger("RingPhone");
        yield return new WaitForSeconds(0.25f);
        inGameManager.SetCharacterDirection(directionsToMove[dirPointer]);
        UpdateDirections();
        
        //TODO: Mobile asset, animation and sound
        yield return new WaitForSeconds(1.5f);

        inGameManager.TriggerThink();
        yield return new WaitUntil(() => inGameManager.thinkManager.dialogueEnd);

        inGameManager.EnableAllUsables();
        inGameManager.DisableNonTaggedUsables();
        inGameManager.EnableMovement();
    }
    
}
