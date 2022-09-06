using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameObject gamePanel;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gamePanel.SetActive(!gamePanel.activeInHierarchy);
        }
    }
}