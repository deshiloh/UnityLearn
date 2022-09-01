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
        public GameObject giver;
        public GameObject questObject;
        public int quantityNeeded;
        public int actualQuantity = 0;
    }
}