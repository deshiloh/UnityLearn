using QuestSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroColliderBehavior : MonoBehaviour
{
    private Collider2D _otherObject;

    private QuestTaker _questTaker;

    private MessageSystem _messageSystem;

    private void Start()
    {
        _questTaker = GetComponent<QuestTaker>();
        _messageSystem = gameObject.GetComponent<MessageSystem>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        _otherObject = col;

        if (col.CompareTag("Sign"))
        {
            var signBehavior = _otherObject.gameObject.GetComponent<SignBehavior>();
            signBehavior.signUI.SetActive(true);
        }

        if (col.CompareTag("SwitchZone"))
        {
            var zoneSwitch = col.gameObject.GetComponent<SwitchZone.SwitchZone>();
            PlayerPrefs.SetString("TeleportZone", zoneSwitch.startPositionName);
            SceneManager.LoadScene(col.name);
        }

        if (col.CompareTag("Mob"))
        {
            var actualPosition = transform.position;

            PlayerPrefs.SetString("ActualScene", SceneManager.GetActiveScene().name);
            PlayerPrefs.SetFloat("PositionX", actualPosition.x);
            PlayerPrefs.SetFloat("PositionY", actualPosition.y);

            var enemyObject = col.gameObject;
            var enemyBhevior = enemyObject.GetComponent<EnemyBehevior>(); 

            ApplicationData.CurrentEnemy = enemyObject.name;
            ApplicationData.EnemyXp = enemyBhevior.xp;
            ApplicationData.EnemyGold = enemyBhevior.gold;

            SceneManager.LoadScene("FightScene");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Sign")) return;
        
        var signBehavior = _otherObject.gameObject.GetComponent<SignBehavior>();
        signBehavior.signUI.SetActive(false);
        
        if (_messageSystem.messagePanel.activeSelf)
        {
            _messageSystem.HideMessage();
        }

        _otherObject = null;
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.A) || _otherObject == null) return;
        
        if (_otherObject.CompareTag("Sign"))
        {
            var signBehavior = _otherObject.gameObject.GetComponent<SignBehavior>();
            _messageSystem.ShowMessage(signBehavior.panelText);
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
