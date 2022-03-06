using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptedMovement : MonoBehaviour
{
    public PlayerMovement moves;
    private Vector2[] directions;
    private bool characterMoving;
    private float currentSecs;
    [SerializeField]private float time;
    [Header("MOVEMENT VARIABLES")]
    [Tooltip("[0 N], [1 NE], [2 E], [3 SE],\n[4 S], [5 SW], [6 W], [7 NW]")]
    public int initialDirection;
    void Awake()
    {
        moves = FindObjectOfType<PlayerMovement>();

        directions = new Vector2[] {new Vector2(0.0f, 1.0f).normalized, //[0] NORTH         
            new Vector2(1.0f, 1.0f).normalized,                         //[1] NORTH-EAST    
            new Vector2(1.0f, 0.0f).normalized,                         //[2] EAST          
            new Vector2(1.0f, -1.0f).normalized,                        //[3] SOUTH-EAST    
            new Vector2(0.0f, -1.0f).normalized,                        //[4] SOUTH         
            new Vector2(-1.0f, -1.0f).normalized,                       //[5] SOUTH_WEST    
            new Vector2(-1.0f, 0.0f).normalized,                        //[6] WEST          
            new Vector2(-1.0f, 1.0f).normalized };                      //[7] NORTH_WEST    

        for (int i = 0; i < directions.Length; i++) {
            float moveH = directions[i].x * moves.moveSpeed;
            float moveV = directions[i].y * moves.moveSpeed;
            directions[i] = new Vector2(moveH, moveV);
        }

        characterMoving = false;

        SetCharacterDirection(initialDirection);
        resetTime();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        if(characterMoving){
            time = time + Time.fixedDeltaTime;
            if(time > currentSecs){
                characterMoving = false;
                moves.disableMovement = false;
                resetTime();
            }
        }
    }

    public void SetCharacterDirection(int dir){
        if(dir > -1 && dir < directions.Length) FindObjectOfType<PlayerAnimation>().SetDirection(directions[dir]);
        else Debug.Log("SPECIFIED DIRECTION OUT OF ARRAY BOUNDS");
    }

    public void resetTime(){
        time = 0.0f;
    }

    public void MoveCharacterCertainSeconds(int dir, float sec){
        currentSecs = sec;
        StartCoroutine(MoveOneSec(directions[dir]));
    }

    private IEnumerator MoveOneSec(Vector2 direction){
        resetTime();
        moves.disableMovement = true;
        moves.rigidBody.velocity = direction;    
        FindObjectOfType<PlayerAnimation>().SetDirection(direction);
        characterMoving = true;
        yield return null;
    }
}
