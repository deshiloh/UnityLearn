using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem
{
    public class QuestTaker : MonoBehaviour
    {
        private QuestGiver _questGiver;

        public List<Quest> quests = new List<Quest>();
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("QuestGiver"))
            {
                _questGiver = col.gameObject.GetComponent<QuestGiver>();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("QuestGiver"))
            {
                _questGiver.HideQuestPanel();
                _questGiver = null;
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A) && _questGiver != null)
            {
                if (!_questGiver.quest.isActive)
                {
                    _questGiver.ShowQuestPanel();    
                }

                if (_questGiver.quest.isActive && _questGiver.quest.isCompleted && !_questGiver.quest.isTerminated)
                {
                    print("Rewards");
                    _questGiver.questIcon.SetActive(false);
                    _questGiver.quest.isTerminated = true;
                }
                
            }
            
        }

        public void TakeQuest()
        {
            _questGiver.quest.isActive = true;
            quests.Add(_questGiver.quest);
            _questGiver.HideQuestPanel();
            _questGiver.questIcon.SetActive(false);
        }
    }
}