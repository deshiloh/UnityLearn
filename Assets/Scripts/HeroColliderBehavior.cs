using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeroColliderBehavior : MonoBehaviour
{
    public GameObject dialogObject;
    
    public TMP_Text dialogText;
    
    private Collider2D otherObject;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Sign")) return;
        otherObject = col;
        var signBehavior = otherObject.gameObject.GetComponent<SignBehavior>();
        signBehavior.signUI.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Sign")) return;
        var signBehavior = otherObject.gameObject.GetComponent<SignBehavior>();
        signBehavior.signUI.SetActive(false);
        if (dialogObject.activeSelf)
        {
            dialogObject.SetActive(false);
        }

        otherObject = null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && otherObject != null)
        {
            var signBehavior = otherObject.gameObject.GetComponent<SignBehavior>();
            dialogText.SetText(signBehavior.panelText);
            dialogObject.SetActive(true);
        }
    }
}
