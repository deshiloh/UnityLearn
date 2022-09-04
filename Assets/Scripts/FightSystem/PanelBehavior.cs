using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FightSystem
{
    public class PanelBehavior : MonoBehaviour
    {
        public string playerName;
        public float maxValue; 
        
        public TMP_Text playerNameUI;
        public Slider slider;
        public TMP_Text lifeDisplay;
        

        private void Start()
        {
            playerNameUI.SetText(playerName);
            slider.maxValue = maxValue;
            
            UpdateSlider(maxValue);
        }

        public void UpdateSlider(float value)
        {
            slider.value = value;
            var currentPourcent = slider.value / slider.maxValue * 100;
            lifeDisplay.SetText($"{slider.value}/{slider.maxValue} - {Mathf.CeilToInt(currentPourcent)} %");
        }
    }
}