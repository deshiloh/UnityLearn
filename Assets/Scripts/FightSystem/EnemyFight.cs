using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FightSystem
{
    public class EnemyFight : MonoBehaviour
    {
        public int health;
        public int force;
        public GameObject enemyPanel;
        public bool canFight;
        public GameObject heroToAttack;
        
        private PanelBehavior _panelBehavior;
        private int _maxHealth;
        private float _currentPourcentHealth;
        private GameObject _mobInMap;
        private Vector3 _currentPosition;
        private HeroFight _heroFight;
        
        private void Awake()
        {
            _currentPosition = transform.position;
            
            _panelBehavior = enemyPanel.GetComponent<PanelBehavior>();
            _panelBehavior.maxValue = health;
            _panelBehavior.playerName = "Squeletton";

            _heroFight = heroToAttack.GetComponent<HeroFight>();
        }

        public void GetDamage(int amount)
        {
            health -= amount;

            _panelBehavior.UpdateSlider(health);
            
            if (health <= 0)
            {
                Destroy(gameObject);
                ApplicationData.HasBeenKilled = true;
                SceneManager.LoadScene(PlayerPrefs.GetString("ActualScene"));
            }
        }

        public void AttackHero()
        {
            if (!canFight) return;
            StartCoroutine("PlayAttak");
        }

        IEnumerator PlayAttak()
        {
            yield return new WaitForSeconds(1f);
            iTween.MoveTo(gameObject, new Vector3(_currentPosition.x - 1.2f, _currentPosition.y, 0), 1);
            
            _heroFight.GetDamage(force);

            yield return new WaitForSeconds(1f);
            iTween.MoveTo(gameObject, _currentPosition, 1);
            canFight = false;
            _heroFight.canFight = true;
        }
    }
}