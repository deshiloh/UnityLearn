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
    private static readonly int MoveX = Animator.StringToHash("MoveX");
    private static readonly int MoveY = Animator.StringToHash("MoveY");

    private void Awake()
    {
        _heroStats = GetComponent<HeroStats>();
        
        var teleportPositionObject = GameObject.Find("StartZones/" + PlayerPrefs.GetString("TeleportZone", "StartPosition"));

        transform.position = teleportPositionObject.transform.position;

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
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        
        animator.SetFloat(MoveX, direction.x);
        animator.SetFloat(MoveY, direction.y);
    }

    private void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + direction * (moveSpeed * Time.fixedDeltaTime));
    }
}
