using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCharacterScript : MonoBehaviour
{
    // Variables
    public SpriteRenderer spritRenderer;
    
    public float moveSpeed = 5.0f;

    public Rigidbody2D rigidBody;

    public Vector2 direction;

    public Animator animator;

    private int _animationState = 0;
    
    private static readonly int Dir = Animator.StringToHash("dir");

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        
        rigidBody.MovePosition(rigidBody.position + direction * (moveSpeed * Time.fixedDeltaTime));
        
        animator.SetInteger(Dir, _animationState);
    }

    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction = Vector2.up;
            _animationState = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            direction = Vector2.down;
            _animationState = 3;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = Vector2.left;
            _animationState = 2;
            spritRenderer.flipX = false;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = Vector2.right;
            _animationState = 2;
            spritRenderer.flipX = true;
        }
        else
        {
            direction = Vector2.zero;
            _animationState = 0;
        }
    }
}
