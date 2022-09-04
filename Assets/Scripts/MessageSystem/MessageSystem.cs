using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageSystem : MonoBehaviour
{
    public GameObject messagePanel;

    // Start is called before the first frame update
    private void Awake()
    {
        messagePanel = GameObject.Find("UIGroup").gameObject.transform.Find("MessagePanel").gameObject;
    }

    public void ShowMessage(string message)
    {
        messagePanel.SetActive(true);
        messagePanel.transform.Find("Message").gameObject.GetComponent<TMP_Text>().SetText(message);
    }

    public void HideMessage()
    {
        messagePanel.SetActive(false);
    }
}
