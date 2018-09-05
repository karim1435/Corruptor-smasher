using UnityEngine;
using System.Collections;
using Assets.Scripts.Manager;

public class EnemyDie : MonoBehaviour
{
    public delegate void ReportDie();
    public event ReportDie onReportMove;

    private EnemyHealth enemyHealth;
    private SpriteRenderer currentSprite;
    private Animator anim;

    private Enemy enemy;

    protected GameAudio gameAudio;

    void Start()
    {
        anim = GetComponent<Animator>();

        currentSprite = GetComponent<SpriteRenderer>();

        enemy = GetComponent<Enemy>();

        enemyHealth = GetComponent<EnemyHealth>();
        enemyHealth.OnZeroHealth += Dead;

        gameAudio = FindObjectOfType<GameAudio>();
    }
    void OnDisable()
    {
        enemyHealth.OnZeroHealth -= Dead;
    }
    public virtual void Dead()
    {
        if (onReportMove != null)
            onReportMove();
        OnDeathAnimation();
      
    }
    private void OnDeathAnimation()
    {
        anim.SetTrigger("IsDead");
        OnDestroyEnemy();
    }
    private void OnDestroyEnemy()
    {
        Destroy(gameObject, 0.5f);
    }
    
}
