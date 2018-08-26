using UnityEngine;
using System.Collections;

public class EnemyDie : MonoBehaviour
{
    private EnemyHealth enemyHealth;
    private SpriteRenderer currentSprite;
    private Animator anim;

    private Enemy enemy;
    public delegate void ReportDie();
    public event ReportDie onReportMove;

    
    Spawner spawn;

    void Start()
    {
        spawn = FindObjectOfType<Spawner>();
        anim = GetComponent<Animator>();
        currentSprite = GetComponent<SpriteRenderer>();
        enemyHealth = GetComponent<EnemyHealth>();
        enemy = GetComponent<Enemy>();
        enemyHealth.OnZeroHealth += Dead;
    }
    void OnDisable()
    {
        enemyHealth.OnZeroHealth -= Dead;
    }
    public virtual void Dead()
    {
        if (onReportMove != null)
            onReportMove();
        anim.SetTrigger("IsDead");
        GameManager.instance.AddScore();
        Destroy(gameObject,0.5f);
    }

}
