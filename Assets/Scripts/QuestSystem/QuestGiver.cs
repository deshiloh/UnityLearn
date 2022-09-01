using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace QuestSystem
{
    public class QuestGiver : MonoBehaviour
    {
        public Quest quest;
        
        // Panel variables
        public GameObject questPanel;
        private TMP_Text _questTitle;
        private TMP_Text _questDescription;
        private TMP_Text _questXp;
        private TMP_Text _questGold;

        private void Start()
        {
            _questTitle = questPanel.transform.GetChild(1).gameObject.GetComponent<TMP_Text>();
            _questDescription = questPanel.transform.GetChild(2).gameObject.GetComponent<TMP_Text>();
            _questXp = questPanel.transform.GetChild(3).gameObject.GetComponent<TMP_Text>();
            _questGold = questPanel.transform.GetChild(4).gameObject.GetComponent<TMP_Text>();
            quest.giver = gameObject;
        }

        public void ShowQuestPanel()
        {
            _questTitle.SetText(quest.title);
            _questDescription.SetText(quest.description);
            _questXp.SetText($"Experience: {quest.xp.ToString()}");
            _questGold.SetText($"Or: {quest.gold.ToString()}");
            

            questPanel.SetActive(!questPanel.activeSelf);
        }

        public void HideQuestPanel()
        {
            questPanel.SetActive(false);
        }
    }
}