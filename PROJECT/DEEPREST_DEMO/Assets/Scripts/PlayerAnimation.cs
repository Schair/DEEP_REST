using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    public string[] staticDirections = { "STATIC_N", "STATIC_NW", "STATIC_W", "STATIC_SW", "STATIC_S", "STATIC_SE", "STATIC_E", "STATIC_NE" };
    public string[] walkDirections = { "WALK_N", "WALK_NW", "WALK_W", "WALK_SW", "WALK_S", "WALK_SE", "WALK_E", "WALK_NE" };

    int lastDirection;

    private void Awake() {
        animator = GetComponent<Animator>();

        /*

        float result1 = Vector2.SignedAngle(Vector2.up, Vector2.right);
        Debug.Log("R1 " + result1);

        float result2 = Vector2.SignedAngle(Vector2.up, Vector2.left);
        Debug.Log("R2 " + result2);

        float result3 = Vector2.SignedAngle(Vector2.up, Vector2.down);
        Debug.Log("R1 " + result3);

        */
        
    }

    public void SetDirection(Vector2 _direction){
        string[] directionArray = null;
        if(_direction.magnitude < 0.01f){
            directionArray = staticDirections;
        }
        else{
            directionArray = walkDirections;

            lastDirection = DirectionToIndex(_direction);
        }
        animator.Play(directionArray[lastDirection]);
    }

    private int DirectionToIndex(Vector2 _direction)
    {
        Vector2 norDir = _direction.normalized;

        float step = 360 / 8;
        float offset = step / 2;

        float angle = Vector2.SignedAngle(Vector2.up, norDir);

        angle += offset;

        if(angle < 0) angle += 360;
        
        float stepCount = angle / step;

        return Mathf.FloorToInt(stepCount);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
