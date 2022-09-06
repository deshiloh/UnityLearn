using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehevior : MonoBehaviour
{
    public int xp;
    
    public int gold;
    
    public GameObject[] paths;

    public float speed;

    private Vector2 _direction;

    public SpriteRenderer spriteRenderer;

    private void Awake()
    {
        gameObject.transform.position = paths[0].transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        _direction = Vector2.right;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_direction * (speed * (Time.deltaTime)));
        if (transform.position.x >= paths[1].transform.position.x)
        {
            _direction = Vector2.left;
            spriteRenderer.flipX = true;
        }

        if (transform.position.x <= paths[0].transform.position.x)
        {
            _direction = Vector2.right;
            spriteRenderer.flipX = false;
        }
    }
}
