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
        private EnemyDie enemyDie;
        private Enemy enemy;
        protected bool canMove = true;
        protected virtual void Start()
        {
            enemyDie = GetComponent<EnemyDie>();
            enemy = GetComponent<Enemy>();
            enemyDie = GetComponent<EnemyDie>();
            speedMove = enemy.MoveSpeed;
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
        public IEnumerator SilentMove(float delay)
        {
            canMove = false;
            yield return new WaitForSeconds(delay);
            canMove = true;
        }
    }
}
