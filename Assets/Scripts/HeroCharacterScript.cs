using System;
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

    private HeroStats _heroStats;

    private void Awake()
    {
        _heroStats = GetComponent<HeroStats>();

        var startPointPosition = GameObject.Find("StartZones/StartPosition").transform.position;

        var teleportPositionX = PlayerPrefs.GetFloat("PositionX", startPointPosition.x);
        var teleportPositionY = PlayerPrefs.GetFloat("PositionY", startPointPosition.y);

        transform.position = new Vector3(teleportPositionX, teleportPositionY, 0);
        
        // Handle end fight
        if (ApplicationData.HasBeenKilled)
        {
            Destroy(GameObject.Find("Enemies/" + ApplicationData.CurrentEnemy));

            if (ApplicationData.EnemyGold > 0)
            {
                _heroStats.GetGold(ApplicationData.EnemyGold);    
            }

            if (ApplicationData.EnemyXp > 0) 
            {
                _heroStats.GetXp(ApplicationData.EnemyXp);    
            }

            ApplicationData.EnemyGold = 0;
            ApplicationData.EnemyXp = 0;
            ApplicationData.CurrentEnemy = null;
            ApplicationData.HasBeenKilled = false;
            
            PlayerPrefs.SetFloat("PositionX", 0);
            PlayerPrefs.SetFloat("PositionY", 0);
        }
    }

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
