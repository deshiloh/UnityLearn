using System;
using System.Collections;
using System.Collections.Generic;
using QuestSystem;
using TMPro;
using UnityEngine;

public class HeroColliderBehavior : MonoBehaviour
{
    public GameObject dialogObject;
    
    public TMP_Text dialogText;
    
    private Collider2D _otherObject;

    private QuestTaker _questTaker;

    private void Start()
    {
        _questTaker = GetComponent<QuestTaker>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        _otherObject = col;
        if (col.CompareTag("Sign"))
        {
            var signBehavior = _otherObject.gameObject.GetComponent<SignBehavior>();
            signBehavior.signUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Sign")) return;
        var signBehavior = _otherObject.gameObject.GetComponent<SignBehavior>();
        signBehavior.signUI.SetActive(false);
        if (dialogObject.activeSelf)
        {
            dialogObject.SetActive(false);
        }

        _otherObject = null;
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.A) || _otherObject == null) return;
        
        if (_otherObject.CompareTag("Sign"))
        {
            var signBehavior = _otherObject.gameObject.GetComponent<SignBehavior>();
            dialogText.SetText(signBehavior.panelText);
            dialogObject.SetActive(true);    
        }

        if (_otherObject.CompareTag("QuestPickUp"))
        {
            var currentPickedUpItemGameObject = _otherObject.gameObject;

            foreach (var quest in _questTaker.quests)
            {
                if (currentPickedUpItemGameObject.CompareTag(quest.questObjectTag) && quest.isActive && !quest.isCompleted)
                {
                    quest.IncrementActualQuantity();
                    currentPickedUpItemGameObject.SetActive(false);
                    _otherObject = null;
                }
            }
        }
    }
}
