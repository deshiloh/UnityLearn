using TMPro;
using UnityEngine;

namespace QuestSystem
{
    [System.Serializable]
    public class Quest
    {
        public string title;
        public string description;
        public int xp = 0;
        public int gold = 0;
        public bool isActive = false;
        public bool isCompleted = false;
        public bool isTerminated = false;
        public GameObject giver;
        public string questObjectTag;
        public int quantityNeeded;
        public int actualQuantity = 0;

        public void IncrementActualQuantity()
        {
            actualQuantity++;
            if (actualQuantity >= quantityNeeded)
            {
                isCompleted = true;
                giver.GetComponent<QuestGiver>().questIcon.SetActive(true);
            }
        }
    }
}