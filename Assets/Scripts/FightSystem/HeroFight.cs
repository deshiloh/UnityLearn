using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FightSystem
{
    public class HeroFight : MonoBehaviour
    {
        public int health;
        public int force;
        public GameObject heroPanel;
        private Vector3 _currentPosition;
        private PanelBehavior _panelBehavior;
        private EnemyFight _enemyFight;
        public bool canFight = true;
        public AudioClip basicAttackSound;
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            
            _currentPosition = transform.position;
            
            // Initialize Panel
            _panelBehavior = heroPanel.GetComponent<PanelBehavior>();
            _panelBehavior.maxValue = health;
            _panelBehavior.playerName = "Héro";

            // Enemy to attack
            var currentEnemy = GameObject.Find("Enemy");
            _enemyFight = currentEnemy.GetComponent<EnemyFight>();
        }

        public void AttackEnemy()
        {
            if (_enemyFight.health >=0 && canFight)
            {
                StartCoroutine("PlayAttak");
            }
        }

        IEnumerator PlayAttak()
        {
            iTween.MoveTo(gameObject, new Vector3(transform.position.x + 2, transform.position.y, 0), 0.45f);
            
            _audioSource.PlayOneShot(basicAttackSound);
            
            _enemyFight.GetDamage(force);
            canFight = false;
            
            yield return new WaitForSeconds(0.50f);
            iTween.MoveTo(gameObject, _currentPosition, 0.45f);
            
            _enemyFight.canFight = true;
            _enemyFight.AttackHero();
        }

        public void GetDamage(int amount)
        {
            health -= amount;
            
            _panelBehavior.UpdateSlider(health);

            if (health == 0)
            {
                print("PERDU");
            }
        }
    }
}