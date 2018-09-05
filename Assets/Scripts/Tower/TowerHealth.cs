using UnityEngine;
using System.Collections;
using Assets.Assets;
using Assets.Scripts.Collectible_Item;
using System;
using Assets.Scripts.Manager;

public class TowerHealth : MonoBehaviour {

    public delegate void ReportHp();
    public event ReportHp OnZeroHp;

    private float intialHp;
    private float currentHp;

    private Tower tower;
    public float CurrentHp { get { return currentHp; } }

    GameAudio gameAudio;
    void Start()
    {
        tower = GetComponent<Tower>();
        intialHp = tower.Hp;
        currentHp = intialHp;
        tower.onCollisionEnemy += OnTrigger;

        gameAudio = FindObjectOfType<GameAudio>();
    }
    void OnDisable()
    {
        tower.onCollisionEnemy -= OnTrigger;
    }
    public void BonusHealth(float health)
    {
        if (currentHp >= intialHp) return;
        currentHp += health;
    }
    private void OnTrigger(Collider2D other)
    {
        if (other.tag == Tag.Enemy)
        {
            float attackPower = other.GetComponent<Enemy>().AttackPower;
            AttackHp(attackPower);
            Destroy(other.gameObject);
        }
    }
    private void AttackHp(float damage)
    {
        PlayLostlifeEffect();
        currentHp -= damage;
        CheckHp();
    }
    private void CheckHp()
    {
        if (currentHp<=0)
        {
            if (OnZeroHp != null)
                OnZeroHp();
        }
    }
    private void PlayLostlifeEffect()
    {
        SoundManager.Instance.PlayEffect(gameAudio.lostLife);
    }
}
