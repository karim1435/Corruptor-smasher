using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Attacker
{
    public class Movement:MonoBehaviour
    {
        protected float speedMove;
        protected bool canMove = true;

        private EnemyDie enemyDie;
        private Enemy enemy;
        
        protected virtual void Start()
        {
            enemy = GetComponent<Enemy>();
            speedMove = enemy.MoveSpeed;

            enemyDie = GetComponent<EnemyDie>();
            enemyDie.onReportMove += SetMove;
        }
        void OnDisable()
        {
            enemyDie.onReportMove -= SetMove;
        }
        protected void SetMove()
        {
            canMove = false;
        } 
        public void StopMove(float delay)
        {
            SetMove();
            StartCoroutine(SilentMove(delay));
        }
        private IEnumerator SilentMove(float delay)
        {
            yield return new WaitForSeconds(delay);
            canMove = true;
        }
    }
}
